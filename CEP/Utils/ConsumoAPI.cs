using CEP.Models;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CEP.Utils

{
    public class ConsumoAPI
    {
        public HttpResponseMessage response;
        public string responseBody;

        static readonly HttpClient client = new HttpClient();
         public async Task GetEnderecos(string Cep) {
            
            
            
            try
            {
                response = await client.GetAsync("https://viacep.com.br/ws/" + Cep+"/json/");
        
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
             


                Endereco endereco = JsonSerializer.Deserialize<Endereco>(responseBody);
                 
                EnderecoRepository enderecoRepository = new EnderecoRepository();
                enderecoRepository.SalvaEndereco(endereco);
          
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            
        }
    }


}
