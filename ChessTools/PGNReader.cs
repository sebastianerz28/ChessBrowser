using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ChessTools
{
    public class PGNReader
    {
        public List<ChessGame> games;

        public PGNReader()
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
            int emptyLine = 0;
            foreach(string line in lines)
            {
                
                string data;
                if (line.StartsWith("[Event \""))
                {
                    data = extractData(line);
                    game.Event = data;
                }
                else if (line.StartsWith("[Site \""))
                {
                    data = extractData(line);
                    game.Site = data;
                }
                else if (line.StartsWith("[Date \""))
                {
                    data = extractData(line);
                    game.Date = data;
                }
                else if (line.StartsWith("[Round \""))
                {
                    data = extractData(line);
                    game.Round = data;
                }
                else if (line.StartsWith("[White \""))
                {
                    data = extractData(line);
                    game.White = data;
                }
                else if (line.StartsWith("[Black \""))
                {
                    
                    data = extractData(line);
                    game.Black = data;
                }
                else if (line.StartsWith("[Result \""))
                {
                    data = extractData(line);
                    if(data == "1-0")
                    {
                        data = "W";

                    }
                    else if (data == "0-1")
                    {
                        data = "B";
                    }
                    else
                    {
                        data = "D";
                    }
                    game.Result = data;
                }
                else if (line.StartsWith("[WhiteElo \""))
                {
                    data = extractData(line);
                    game.WhiteElo = data;
                }
                else if (line.StartsWith("[BlackElo \""))
                {
                    data = extractData(line);
                    game.BlackElo = data;
                }
                else if (line.StartsWith("[ECO \""))
                {
                    data = extractData(line);
                    game.ECO = data;
                }
                else if (line.StartsWith("[EventDate \""))
                {
                    data = extractData(line);
                    if (data.Contains("?"))
                    {
                        game.EventDate = DateTime.MinValue;
                        continue;
                    }
                    game.EventDate = DateTime.Parse(data);
                }
                else if(line == "")
                {
                    emptyLine++;
                }
                else
                {
                    game.Moves += line;
                }


                    if (emptyLine == 2)
                {
                    games.Add(game);
                    emptyLine = 0;
                    game = new ChessGame();
                }
            }
            
        }

        public string extractData(string line)
        {
            string temp = "";
            if (line[line.Length - 1] != ']')
            {
                throw new Exception("No Closing bracket");
            }
            if (line[line.Length - 2] != '"')
            {
                throw new Exception("There are no closing quotes");
            }
            for (int i = 0; i < line.Length; i++)
            {
                
                if (line[i] == '"')
                {
                    i++;
                    while (line[i] != '"')
                    {
                        temp += line[i];
                        i++;
                    }
                    
                }
            }
            return temp;
        }

        

    }
}
