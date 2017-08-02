// www.google.com.tw/amp/s/nathanbrixius.wordpress.com/2010/04/26/traveling-salesman-problems-using-solver-foubdation-c-code/amp/


using Sysyem;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SolverFoundation.Services;

namespace Microsoft.SolverFoundation.Samples.travelingSalesman{
   class Program{
      //TSP coordinate.
      public class Coordinate{
         public int Name { get; set; }
         // X-coordinate (from TSPLIB)
         public double x { get; set; }

         // Y-coordinate (from TSPLIB)
         public double y { get; set; }

         public Coordinate(int name, double x, double y){
            Name = name;
            X = x;
            Y = y;
         }

         // Latitude in radians
         public double Latitude{
            get{ return}
         }

      }
   }


}
