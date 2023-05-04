using CEP.Utils;
using Npgsql;

namespace CEP.Models
{
    public class EnderecoRepository
    {
        public NpgsqlConnection _connection { get; set; }
        public EnderecoRepository()
        {
            _connection = ConexaoBanco.ConectaBanco();
        }
        public void SalvaEndereco(Endereco endereco)
        {
            using(_connection)
            {
                string sql = @$"INSERT INTO endereco(cep,logradouro,complemento,bairro,localidade,uf,ibge,gia,ddd,siafi)
                              VALUES ('{endereco.cep}', '{endereco.logradouro}', '{endereco.complemento}', '{endereco.bairro}',
                               '{endereco.localidade}', '{endereco.uf}', '{endereco.ibge}', '{endereco.gia}', '{endereco.ddd}','{endereco.siafi}')";


                var cmd = _connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }


        internal void Deletar(string cep)
        {
            using (_connection)
            {
                string sql = $@"DELETE FROM ENDERECO WHERE  replace(cep,E'-','') = replace('{cep}',E'-','')";
                var cmd = _connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();  
            }
        }
    }
}
