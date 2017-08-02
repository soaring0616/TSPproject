//kunuk dynamic program

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Knapsack{
   public class Program{
      private static void Main(string[] args){
         Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo();
         Action<object> write = Console.Write;
         var stopwatch = new Stopwatch();
         stopwatch.Start();

         write("Running ..\n\n");
         var rand = new Random();

         // -------------- Insert data here
         const int N = 10;
         const int maxWeight = 20;
         var items = new List<Item>();

         for( var i=0; i<N; i++ ){
            items.Add(new Item{ w=rand.Next(1,10), v=rand.Next(1,100)});
         }
         Knapsack.Init(items, maxWeight);
         Knapsack.Run();

         stopwatch.Stop();

         write("Done\n\n");

         Knapsack.PrintPicksMatrix(write);
         Knapsack.Print(write,true);

         write(string.Format("\n\nDuration: {0}\nPress a key to exit\n",
                             stopwatch.Elapsed.ToString()));

         Console.ReadKey();
      }
     
   }
   static class Knapsack{
      static int[][] M { get; set; } //matrix
      static int[][] P { get; set; } //picks
      static Item[] I { get; set; }  //items
      public static int MaxValue { get; private set; }
      static int W { get; set; } //max weight

      public static void Init(List<Item> items, int maxWeight){
         I = items.ToArray();
         W = maxWeight;
         var n = I.Length;
         M = new int[n][];
         P = new int[n][];
         for(var i=0; i<M) { M[i] = new int [W+1]; }
      }


   }
}


/*

  public static int KnapSack(){
      int[,] K = new int[itemsCount+1,capacity+1];
      for(int i=0; i<=itemsCount+1; ++i){
         for(int w=0; w<=capacity;++w){
            if(i==0||w==0){
               K[i, w]=0;
            }
            else if(weight[i-1]<w){
               K[i, w] = Math.Max(value[i-1]+K[i-1,w-weight[i-1]],K[i-1,w]);
            }
            else K[i, w] = K[i-1, w];
         }
      }
      return K[itemsCount,capacity];
   }

*/
