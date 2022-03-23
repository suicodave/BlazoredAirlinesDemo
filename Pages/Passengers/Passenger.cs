using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazoredAirlinesDemo.Pages.Passengers
{
    public class Passenger
    {
        public string? Name { get; set; }

        public int Trips { get; set; }
    }

    public class PaginatedPassenger
    {
        public int TotalPassengers { get; set; }

        public IEnumerable<Passenger> Data { get; set; } = new List<Passenger>();
    }
}