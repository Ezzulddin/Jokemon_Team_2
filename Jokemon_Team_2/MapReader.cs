using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Jokemon_Team_2
{
    static class MapReader
    {
        // a property to be able to set and get the map size
        public static int mapsize { get; set; }

        public static char[,] tileArray;

        public static char[,] ReadFile(string inFileName)
        {
            StreamReader sRead = new StreamReader(inFileName);
            string line = "";
            tileArray = new char[10, 10];
            int counter = 0;

            do
            {
                //gab a line of text and store into th variables 
                line = sRead.ReadLine();
                //iterates throught the characters in the line
                for (int i = 0; i < line.Length; i++)
                {
                    //store the value of the character into the tile array 
                    tileArray[i, counter] = line[i];
                }

                //if the counter is less then the length of the line
                if (counter < line.Length - 1)
                {
                    //increase thee counter by one 
                    counter++;
                }


            } while (sRead.EndOfStream); //do this while it has not hit the end of the stream

            sRead.Close();

            return tileArray;
        }

    }
}
