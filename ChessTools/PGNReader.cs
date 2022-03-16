using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ChessTools
{
    class PGNReader
    {
        public List<ChessGame> games;

        PGNReader()
        {
            games = new List<ChessGame>();

        }

        /*
         * 
    The tagged data for a game [...] always comes before the moves.
    After all the tagged data is a blank line, followed by the moves. The moves can contain newlines.
    The end of the moves (and game) is indicated by another blank line.
    All games will have the required tags listed above, but they may not be in any particular order.
    The values inside tags can not contain [ or ] characters, but they can contain other special characters, such as " or \.
    The name of the tag will always directly follow the '[' character, followed by a space, followed by the value value which is always enclosed in quotes.

         */
        /// <summary>
        /// Reads a line makes a chess game object and adds it to the lists
        /// </summary>
        /// <param name="filename"></param>
        public void ReadLines(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            ChessGame game = new ChessGame();
            foreach (string line in lines)
            {


                string temp = "";
                if (line[0] == '[')
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        int leftBCount = 0;
                        int rightBCount = 0;
                        //Check brackets
                        if (line[i] == '[')
                        {
                            leftBCount++;
                        }
                        else if (line[i] == ']')
                        {
                            rightBCount++;
                        }
                        if (line[i] == '"')
                        {
                            while (line[i] != ']')
                            {
                                temp += line[i];
                                i++;
                            }
                            if (line[line.Length - 1] != ']')
                            {
                                throw new Exception("No Closing bracket");
                            }
                            if (line[line.Length - 2] != '"')
                            {
                                throw new Exception("There are no closing quotes");
                            }
                        }

                        if (leftBCount != rightBCount && leftBCount > 1 || rightBCount > 1)
                        {
                            throw new Exception("Brackets Not allowed");
                        }

                    }
                }
                else if (line == "")
                    continue;
                else
                {
                    temp += line;
                }

                if (game.ValsNull())
                {

                }

            }
        }

        

    }
}
