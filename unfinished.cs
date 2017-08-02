using System.IO;
using System;
using System.Linq;

namespace TSP{
   class Program{
      public static int [,] matrix = new int [25,25];
      public static int [] visited_cities = new int[10];
      public static int limit;
      public static int cost=0;
      public static int nearest_city=999;

      static void Main(){

         Console.WriteLine("Enter Total Number of Cities:\t");

         int limit=Convert.ToInt32(Console.ReadLine());

         for(int i = 0; i < limit; i++){
            Console.WriteLine("\nEnter "+limit+" Elements in Row["+(i+1)+"]\n");
            int[] d = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for(int j = 0; j < limit; j++){
               matrix[i,j]=d[j];
            }
            visited_cities[i] = 0;
         }

         Console.WriteLine("\nEntered Cost Matrix\n");
         for(int i=0;i<limit;i++){
            Console.WriteLine();
               for(int j=0;j<limit;j++){
                  Console.Write(matrix[i,j]+" ");
               }
         }
     //    Console.Write("\n\nPath:\t");
         minimum_cost(0,limit);
     //    Console.Write("\n\nMinimum Cost: \t");
     //    Console.WriteLine(cost);
      }

     
      public static int tsp(int c,int l){
         int count;
         int minimum = 999;
         int temp=0;
         Console.WriteLine(l+" ");
         for(count = 0; count < l; count++){
            if((matrix[c,count] != 0) && (visited_cities==0) ){
               if(matrix[c,count] < minimum){
                  minimum = matrix[count,0] + matrix[c,count];
               }
             temp = matrix[c,count];
             nearest_city = count;
             }
             Console.WriteLine("c="+c+" count="+count+" tmp="+temp+" ncitiy="+nearest_city);
         }
         if(minimum != 999){
            cost = cost + temp;
         }
         return nearest_city;

      }
  
      public static void minimum_cost(int city,int ls){
         visited_cities[city]=1;
         Console.Write((city+1)+" ");
         nearest_city = tsp(city, ls);
         if(nearest_city == 999){
            nearest_city = 0;
            Console.Write((nearest_city + 1)+" ");
            cost = cost + matrix[city,nearest_city];
            return;
         }
         minimum_cost(nearest_city,ls);
         
      }
 
   }
}
