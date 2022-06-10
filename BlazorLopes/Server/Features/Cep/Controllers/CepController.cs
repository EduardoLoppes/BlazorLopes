using BlazorLopes.Shared.Features.Cep.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorLopes.Server.Features.Cep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        [HttpGet("{cep}")]
        public Endereco RetornarEndereco(string cep)
        {
            var endereco = new Endereco();
            
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://viacep.com.br/ws/");

                try
                {
                    var json = http.GetStringAsync($"{cep}/json");
                    endereco = JsonConvert.DeserializeObject<Endereco>(json.Result);
                }
                catch
                {
                    endereco.erro = true;
                }
                
            }
            
            return endereco;
        }
    }
}
