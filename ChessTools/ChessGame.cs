using System;

namespace ChessTools
{

    public class ChessGame
    {

        //Internal CTR
        public string Event { get;  set; } = "0";
        public string Site { get;  set; } = "1";
        public string Round { get;  set; } = "2";
        public string White { get;  set; } = "3";
        public string Black { get;  set; } = "4";
        public string WhiteElo { get;  set; } = "5";
        public string BlackElo { get; set; } = "6";
        public string Result { get;  set; } = "7";
        public string EventDate { get;  set; } = "8";
        public string Moves { get;  set; } = "9";

        
        private string[] data;
        public ChessGame() { data = new string[10]; }

        public void setVal(int index, string line)
        {
            data[index] = line;
        }

        public bool ValsNull()
        {
            foreach(string line in data)
            {
                if (line == null)
                    return false;
            }
            return true;
        }
    }
}
