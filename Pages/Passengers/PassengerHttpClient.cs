using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazoredAirlinesDemo.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;

namespace BlazoredAirlinesDemo.Pages.Passengers
{
    public class PassengerHttpClient : IPaginatedHttpClient<Passenger>
    {
        private readonly HttpClient _http;
        public PassengerHttpClient(HttpClient http, ILogger<PassengerHttpClient> logger)
        {
            _http = http;
        }

        public async Task<TableData<Passenger>> Paginate(TableState state)
        {

            string path = "v1/passenger";

            var parameters = new Dictionary<string, string>
            {
                ["page"] = state.Page.ToString(),
                ["size"] = state.PageSize.ToString()
            };


            var result = await _http.GetFromJsonAsync<PaginatedPassenger>(QueryHelpers.AddQueryString(path, parameters));

            return new TableData<Passenger>
            {
                Items = result!.Data,
                TotalItems = result.TotalPassengers
            };
        }

        public async Task<bool> Create(CreatePassengerRequest request)
        {
            return (bool)(await _http.PostAsJsonAsync("v1/passenger", request)).IsSuccessStatusCode;
        }
    }
}