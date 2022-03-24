using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazoredAirlinesDemo.Pages.Airlines;

namespace BlazoredAirlinesDemo.Pages.Passengers
{
    public class Passenger
    {
        public string _Id { get; set; } = "";

        public string? Name { get; set; }

        public int Trips { get; set; }

        public IEnumerable<Airline> Airline { get; set; } = new List<Airline>();


    }

    public class PaginatedPassenger
    {
        public int TotalPassengers { get; set; }

        public IEnumerable<Passenger> Data { get; set; } = new List<Passenger>();
    }

}