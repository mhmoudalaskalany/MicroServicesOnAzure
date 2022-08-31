using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Data;
using Shopping.Api.Models;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductContext.Products;
        }


        [HttpGet]
        public Response<KeyVaultSecret> GetVaultKey()
        {
            var client = new SecretClient(new Uri("https://mahmoud.vault.azure.net/"),
                credential: new DefaultAzureCredential());
            KeyVaultSecret secret2 = client.SetSecret("test2", "test2 secret");
            var secret1 = client.GetSecret("test");
            return secret1;
        }
    }
}