﻿namespace WebApplication1.Models
{
    public class FlightPostModel
    {
        public DateTime Date { get; set; }
        public DateTime LeavingTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TerminalNum { get; set; }
    }
}
