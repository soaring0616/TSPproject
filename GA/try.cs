using System;
using System.Linq;
using System.IO;


public class Example{
  

   public static void Main(){
      // built-in cities
      float[][] cities = new float [10][];


      int generation=20,size=10;   // note generation <= size!/2
      Random rnd = new Random();
      int[] array = new int[size];
      int tmp=1;
      int[] check = Enumerable.Repeat(0,size).ToArray();

      for(int j=0;j<generation;j++){
         Console.Write((j+1)+"th\t");
         check = Enumerable.Repeat(0,size).ToArray();
         for(int i=0; i<size; i++){
            do{
               tmp=rnd.Next(1,size+1);
            }while(check[tmp-1]!=0);
            check[tmp-1]=1;
            array[i]=tmp;
         }

         for(int i=0; i<size; i++){
            Console.Write($array[i]+" ");
         }
     
      Console.WriteLine();
      }
   }
}
