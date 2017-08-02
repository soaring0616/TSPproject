using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace ConsoleApplication8{

    class Program{
        static int[,] ConvertMatrix(int[] flat, int m, int n){
            if (flat.Length != m * n){
                throw new ArgumentException("Invalid length");
            }
            int[,] ret = new int[m, n];
                // BlockCopy uses byte lengths: a double is 8 bytes
            Buffer.BlockCopy(flat, 0, ret, 0, flat.Length * sizeof(int));
            return ret;
        }
        public static void Main(string[] args){
            int m, n,i,j;
            Console.Write("Enter Number Of Rows And Columns Of Matrices A and B : ");
            int[] RowCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
            m = RowCol[0];
            n = RowCol[1];

            Console.Write("\nEnter The First Matrix : ");
            int[] d1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix1 = ConvertMatrix(d1, m, n);
            
            Console.Write("\nEnter The Second Matrix : ");
            int[] d2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix2 = ConvertMatrix(d2, m, n);
            
            Console.Clear();
            Console.WriteLine("\nMatrix A : ");
            for (i = 0; i < m; i++){
                for (j = 0; j < n; j++){
                    Console.Write(matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nMatrix B: ");
            for (i = 0; i < m; i++){
                for (j = 0; j < n; j++){
                    Console.Write(matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }
            int[,] C = new int[10, 10];
            for (i = 0; i < m; i++){
                for (j = 0; j < n; j++){
                    C[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            Console.WriteLine("\nSum Matrix: ");
            for (i = 0; i < m; i++){
                for (j = 0; j < n; j++){
                    Console.Write(C[i, j] + " ");
 
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
    

}
