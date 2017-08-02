using System;

public class Example{
   public static void Main(){
      Random rnd = new Random();
      Console.WriteLine("\n20 random integers from -100 to 100");
      for(int ctr=1; ctr<=20; ctr++) {
         Console.Write("{0,6}", rnd.Next(-100, 101));
         if(ctr%5==0) Console.WriteLine();
      }

      Console.WriteLine("\n20 random integers from 1000 to 10001");
      for(int ctr=1; ctr<=20; ctr++) {
         Console.Write("{0,6}", rnd.Next(1000, 10001));
         if(ctr%5==0) Console.WriteLine();
      }

      Console.WriteLine("\n20 random integers from 1 to 11");
      for(int ctr=1; ctr<=20; ctr++) {
         Console.Write("{0,6}", rnd.Next(1, 11));
         if(ctr%5==0) Console.WriteLine();
      }


   }
}
