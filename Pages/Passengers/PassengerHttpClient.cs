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
        private readonly ILogger<PassengerHttpClient> _logger;
        public PassengerHttpClient(HttpClient http, ILogger<PassengerHttpClient> logger)
        {
            _logger = logger;
            _http = http;
        }

        public async Task<TableData<Passenger>> Paginate(TableState state)
        {
            _logger.LogInformation("@table", state);

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
    }
}