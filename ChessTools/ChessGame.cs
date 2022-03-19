﻿using System;

namespace ChessTools
{

    public class ChessGame
    {

        
        public string Event { get;  set; } 
        public string Site { get;  set; } 
        public string Date { get; set; } 
        public string Round { get;  set; }
        public string White { get;  set; } 
        public string Black { get;  set; }
        public string WhiteElo { get;  set; }
        public string BlackElo { get; set; }
        public string ECO { get; set; }
        public string Result { get;  set; }
        public DateTime EventDate { get;  set; } 
        public string Moves { get; set; }
        public ChessGame() {  }


    }
}
