﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundService.Services
{
    public class RandomStringProvider : IRandomStringProvider
    {
        private const string RandomStringUri =
                "https://www.random.org/strings/?num=1&len=8&digits=on&upperalpha=on&loweralpha=on&unique=on&format=plain&rnd=new";

        private readonly HttpClient _httpClient;

        public RandomStringProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task UpdateString(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetAsync(RandomStringUri, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    RandomString = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string RandomString { get; private set; } = string.Empty;
    }
}