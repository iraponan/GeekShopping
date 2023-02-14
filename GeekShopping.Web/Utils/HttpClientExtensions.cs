﻿using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils {
    public static class HttpClientExtensions {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage httpResponse) {
            if (!httpResponse.IsSuccessStatusCode) {
                throw new ApplicationException($"Algo aconteceu de errado ao chamar a API: " + $"{httpResponse.ReasonPhrase}");
            }
            var dataAsString = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait( false );
            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<HttpRequestMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data) {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpClient.PostAsync(url, content);
        }
        
        public static Task<HttpRequestMessage> PuAsJson<T>(this HttpClient httpClient, string url, T data) {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpClient.PutAsync(url, content);
        }
    }
}
