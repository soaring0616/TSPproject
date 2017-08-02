using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP{
   public class Tour{
      // Member variables
      public List<City> { get; private set; }
      public double distance { get; private set; }
      public double fitness { get; private set; }

      // ctor
      public Tour(List<> l){
         this.t = l;
         this.distance = this.calcDist();
         this.fitness = this.calcFit();
      }

      // Functionality
      public static Tour random(int n){
         List<City> t = new List<City>();
         for(int i=0; i<n; ++i) t.Add( City.random() );
         return new Tour(t);
      }

      public Tour shuffle(){
         List<City> tmp = new List<City>(this.t);
         int n = tmp.Count;
         while(n > l){
            n--;
            int k = Program.r.next(n+1);
            City v = tmp[k];
            tmp[k] = tmp[n];
            tmp[n] = v;
         }
         return new Tour(tmp);
      }

      public Tour crossover(Tour m){
         int i = Program.r.Next(0, m.t.Count);
         int j = Program.r.Next(i, m.t.Count);
         List<City> s = this.t.GetRange(i, j-i+1);
         List<City> ms = m.t.Except(s).ToList();
         List<City> c = ms.Take(i).Concat(s).Concat(ms.Skip(i)).ToList();
         return new Tour(c);
      }

      public Tour mutate(){
         List<City> tmp = new List<City>(this.t);
         if(Program.r.NextDouble() < Env.mutRate){
            int i = Program.r.Next(0, this.t.Count);
            int j = Program.r.Next(0, this.t.Count);
            City v = tmp[i];
            tmp[i] = tmp[j];
            tmp[j] = v;
         }
         return new Tour(tmp);
      }

      private double calcDist(){
         double total = 0;
         for(int i=0; i<this.t.Count; ++i){
            total+= this.t[i].diatanceTo(this.t[(i+1)%this.t.Count]);
         }
         return total;
         // Execution time is doubled by using linq in this case
         // return this.t.Sum( c => c.distanceTo(this.t[(this.t.IndexOf(c)+1)%this.t.Count]));
      }

      private double calcFit(){
         return (1/this.distance);
      }
   }


   public class Population{
      // Member variables
      public List<Tour> p { get; private set; }
      public double maxFit { get; private set; }

      // ctor
      public Population(List<Tour> l){
         this.p = l;
         this.maxFit = this.calcMaxFit();
      }

      // Functionality
      public static Population randomized(Tour t, int n){
         List<Tour> tmp = new List<Tour>();
         for(int i = 0; i<n; ++i) tmp.Add(t.shuffle());
         return new Population(tmp);
      }

      private double calcMaxFit(){
         return this.p.Max( t => t.fitness);
      }

      public Tour select(){
         while(true){
            int i = Program.r.Next(0, Env.popSize);
            if(Program.r.NextDouble() < this.p[i].fitness/this.maxFit) return new Tour(this.p[i].t);
         }
      }

      public Population genNewPop(int n){
         List<Tour> p = new List<Tour>();
         for(int i=0; i<n; ++i){
            Tour t = this.select().crossover( this.select() );
            foreach ( City c in t) t = t.mutate();
            p.Add(t);
         }
         return new Population(p);
      }

      public Population elite(int n){
         List<Tour> best = new List<Tour>();
         Population tmp = new Population(p);

         for(int i=0;i<n;++i){
            best.Add(tmp.findBest());
            tmp = new Population( tmp.p.Except(best).ToList() );
         }
         return new Population(best);
      }

      public Tour findBest(){
         foreach(Tour t in this.p){
            if(t.fitness == this.maxFit) return t;
         }
         // should never happen. it's here to shut up the compiler
         return null;
      }

      public Population evolve(){
         Population best = this.elite(Env.elitism);
         Population np = this.genNewPop(Env.popSize - Env.elitism);
         return new Population( best.p.Concat(np.p).ToList());
      }

   }

   public class City{
      // Member variables
      public double x {get; private set;}
      public double y {get; private set;}

      //ctor
      public City(double x, double y){
        this.x=x;
        this.y=y;
      }

      // Functionality
      public double distanceTo(City c){
        return Math.Sqrt(Math.Pow((c.x - this.x),2)+Math.Pow(c.y - this.y),2);
      }

      public static City random(){
        return new City(Program.r.NextDouble(), Program.r.NextDouble());
      }
   }

}

public class Program{
   public static Random r { get; private set; }

   public static void Main(){
   }

   public static void display(Population p, int gen){
      Tour best = p.findBest();
      System.Console.WriteLine("Generation {0}\n"+"Best fitness:  {1}\n"+"Best distance: {2}\n",gen, best.fitness, best.distance);
   }

}

public static class Env{
   public const double mutRate = 0.03;
   public const int elitism = 6;
   public const int popSite = 60;
   public const int numCities = 40;
}
