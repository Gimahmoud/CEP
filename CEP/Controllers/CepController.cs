using CEP.Models;
using CEP.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CEP.Controllers
{
    [Route("/")]
    [ApiController]
    public class CepController : Controller
    {

        public IActionResult Index() { 
            return View();  
        }


        [HttpGet("get-endereco/{cep}")]
        public async Task<IActionResult> GetEndereco(string cep)
        {
            ConsumoAPI consumoAPI = new ConsumoAPI();
            await consumoAPI.GetEnderecos(cep);
            return Ok(consumoAPI.responseBody);
        }



        [HttpGet("delete-endereco/{cep}")]
        public IActionResult DeleteEndereco(string cep)
        {
            try
            {
                EnderecoRepository enderecoRepository = new EnderecoRepository();
                enderecoRepository.Deletar(cep);

                return Ok("Endereço deletado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
