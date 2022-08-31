using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Data;
using Shopping.Api.Models;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
            try
            {
                Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", "ee029988-2765-4892-865a-8576c0aa5038");
                Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", "KCU8Q~GXXV5vEciLRra6ExyAjx5-l6w2YnRF.aAt");
                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "2c0b3945-c02d-46a5-80a5-fe06ead80517");
                var azu = new DefaultAzureCredential();
                var client = new SecretClient(new Uri("https://mahmoud.vault.azure.net/"),
                    credential: azu);
                var secret1 = client.GetSecret("test");
                return secret1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}