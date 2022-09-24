using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //get text from input file 
            if (args.Length != 1)
            {
                //Console.WriteLine("incorrect number of input arguments");
                System.Environment.Exit(1);
            }
            else 
            {
                //Console.WriteLine("Reading input from " + args[0] + " file.\n");
            }
            string[] lines = File.ReadAllLines(args[0]);
            //end of get text from input 

            //get stations from input file or create train object 
            Train train = new Train(lines);
            train.runTrain();
            //end of get stations from input file 
        }
    }
}