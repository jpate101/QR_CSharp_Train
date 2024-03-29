﻿using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //check for single input 
            if (args.Length != 1)
            {
                Console.WriteLine("incorrect number of arguments");
               System.Environment.Exit(1);
            }
            //convert text files to string array seperated by \n in lines variable
            string[] lines = File.ReadAllLines(args[0]);
            //pass lines into train object/class 
            Train train = new Train(lines);
            //runTrain func will print msg to console 
            train.runTrain();
        }
    }
}