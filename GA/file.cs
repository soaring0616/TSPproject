using System;
using System.IO;
using System.Text;

class Test{
    public static void Main(){
        /* 
         *******  Method 1  *******/
        string path = @"example.txt";
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText);
        

        /*
         *******  Method 2   *******
        string[] lines = System.IO.File.ReadAllLines(@"example.txt");

        System.Console.WriteLine("Contents of example.txt = ");
        foreach (string line in lines){
            // Use a tab to indent each line of the file.
            Console.WriteLine("\t" + line);
        }

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
        */

    }
}


/*
using System;
using System.IO;


class Test{
    public static void Main() {
        int size,i=0;
        string[][] jaggedArray = new string[size][];
        try{
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("example.txt")) {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null){
                    jaggedArray[i]= new string[](line);
                    i++;
                }
            }
        }
        catch (Exception e) 
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}

*/
