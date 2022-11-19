using FIAPSmartCity.Models;
using System.Data;
using System.Data.SqlClient;

namespace FIAPSmartCity.Repository
{
    public class TipoProdutoRepository
    {
        public IList<TipoProduto> Listar()
        {
            IList<TipoProduto> lista = new List<TipoProduto>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDTIPO, DESCRICAOTIPO, COMERCIALIZADO FROM TIPOPRODUTO  ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    TipoProduto tipoProd = new TipoProduto();
                    tipoProd.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoProd.DescricaoTipo = dataReader["DESCRICAOTIPO"].ToString();
                    tipoProd.Comercializado = dataReader["COMERCIALIZADO"].Equals("1");

                    // Adiciona o modelo da lista
                    lista.Add(tipoProd);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return lista;
        }

        public TipoProduto Consultar(int id)
        {

            TipoProduto tipoProd = new TipoProduto();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDTIPO, DESCRICAOTIPO, COMERCIALIZADO FROM TIPOPRODUTO WHERE IDTIPO = @IDTIPO ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IDTIPO", SqlDbType.Int);
                command.Parameters["@IDTIPO"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    tipoProd.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoProd.DescricaoTipo = dataReader["DESCRICAOTIPO"].ToString();
                    tipoProd.Comercializado = dataReader["COMERCIALIZADO"].Equals("1");
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return tipoProd;
        }

        public void Inserir(TipoProduto tipoProduto)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO TIPOPRODUTO ( DESCRICAOTIPO, COMERCIALIZADO ) VALUES ( @descr, @comerc ) ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@descr", SqlDbType.Text);
                command.Parameters["@descr"].Value = tipoProduto.DescricaoTipo;
                command.Parameters.Add("@comerc", SqlDbType.Text);
                command.Parameters["@comerc"].Value = Convert.ToInt32(tipoProduto.Comercializado);

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(TipoProduto tipoProduto)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE TIPOPRODUTO SET DESCRICAOTIPO = @descr , COMERCIALIZADO = @comerc WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@descr", SqlDbType.Text);
                command.Parameters.Add("@comerc", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@descr"].Value = tipoProduto.DescricaoTipo;
                command.Parameters["@comerc"].Value = Convert.ToInt32(tipoProduto.Comercializado);
                command.Parameters["@id"].Value = tipoProduto.IdTipo;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE TIPOPRODUTO WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
