using AutoMapper;
using Geekshopping.ProductAPI.Data.ValueObjects;
using Geekshopping.ProductAPI.Model;

namespace Geekshopping.ProductAPI.Config {
    public class MappingConfig {
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
