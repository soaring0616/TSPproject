using System;
using System.Linq;

namespace Demo{
   internal class Program{
      private static void Main(){
         int[] items = Console.Readline().Split().Select(int.Parse).ToArray();
         int sum = items.Sum()
         Console.WriteLine("0",sum);
      }
   }
}
