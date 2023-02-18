using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services {
    public class ProductService : IProductService {
        private readonly HttpClient httpClient;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient httpClient) {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts(string token) {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id, string token) {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model, string token) {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) {
                return await response.ReadContentAs<ProductModel>();
            }
            else {
                throw new Exception("Algo aconteceu de errado ao chamar a API.");
            }
            
        }
        public async Task<ProductModel> UpdateProduct(ProductModel model, string token) {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PuAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) {
                return await response.ReadContentAs<ProductModel>();
            }
            else {
                throw new Exception("Algo aconteceu de errado ao chamar a API.");
            }
        }

        public async Task<bool> DeleteProductById(long id, string token) {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode) {
                return await response.ReadContentAs<bool>();
            }
            else {
                throw new Exception("Algo aconteceu de errado ao chamar a API.");
            }
        }
    }
}
