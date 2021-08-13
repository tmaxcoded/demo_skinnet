using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(Storecontext context, ILoggerFactory loggerFactory){
            try
            {
                if(!context.ProductBrands.Any()){
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands){
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }


                 if(!context.productTypes.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach(var item in types){
                        context.productTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }


                 if(!context.Products.Any()){
                    var products = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var productTypes = JsonSerializer.Deserialize<List<Product>>(products);

                    foreach(var item in productTypes){
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            } catch(Exception ex){
               var logger = loggerFactory.CreateLogger<StoreContextSeed>();
               logger.LogError(ex.Message);
            }
        }
    }
}