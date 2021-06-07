using System;
using MySqlConnector;



namespace Projetobanco
{
    public class RepoPatent
    {
        Conexao conexao= new Conexao();
         string sql;
          MySqlCommand comando;
        public RepoPatent()
        {
        }

        public void Inserir(Patente patente)
        {
            try
            {
                conexao.AbirConexao();
                sql="INSERT INTO Patente (NomePatente) VALUES (@NomePatente)";
                comando = new MySqlCommand(sql, conexao.con);
                comando.Parameters.AddWithValue("@NomePatente", patente.NomePatente);
                //comando.Parameters.AddWithValue("@IdPatente", patente.IdPatente);
                comando.ExecuteNonQuery();
                conexao.FecharConexao();
            }

            catch (Exception ex)
            {
                throw ex;
            }
       
        }

       public void Alterar(Patente patente)
        {
            try
            {
                conexao.AbirConexao();
                sql = "UPDATE Patente SET NomePatente = @NomePatente WHERE id_Patente = @Id";
                MySqlCommand comando = new MySqlCommand(sql, conexao.con);
                comando.Parameters.AddWithValue("@Id", patente.IdPatente);
                comando.Parameters.AddWithValue("@NomePatente", patente.NomePatente);
                comando.ExecuteNonQuery();
                conexao.FecharConexao();
                Console.WriteLine("Dados Alterados com sucesso");
            }

            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Deletar(int id)
        {
            try
            {
                conexao.AbirConexao();
                sql = "DELETE FROM Patente WHERE id_Patente = @Id";
                 MySqlCommand comando = new MySqlCommand(sql, conexao.con);
                comando.Parameters.AddWithValue("@Id", id);
                comando.ExecuteNonQuery();
                conexao.FecharConexao();
                Console.WriteLine("Registro excluido com sucesso");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }

            
        }


        public void Listar(string nome = null)
        {
            try
            {
                conexao.AbirConexao();
               
                if (nome == "")
                {
                    // Comando retornando todos os clientes ser "WHERE"
                    sql = "SELECT * FROM Patente order by NomePatente";
                    comando = new MySqlCommand(sql, conexao.con);
                }
               
                else
                {
                    sql="SELECT * FROM Patente WHERE NomePatente LIKE @NomePatente";
                    comando = new MySqlCommand(sql, conexao.con);
                    comando.Parameters.AddWithValue("@NomePatente", string.Format($"%{nome}%"));

                }
               
                MySqlDataReader reader = comando.ExecuteReader();
                
                if (reader.HasRows){
                    while (reader.Read())
                    {
                       Console.WriteLine(reader.GetInt32("id_Patente")); 
                       Console.WriteLine(reader.GetString("NomePatente"));
                       
                    }
                  }
                  else{
                      Console.WriteLine("Registro Nao encontrados");

                  }
                                  
            }
          
            catch (Exception ex)
            {
                throw ex;
            }
                
        }


         public void ObterQuantidadeDePatentes()
        {
            long quantidade = 0;
            conexao.AbirConexao();
            sql = "SELECT COUNT(*) FROM Patente";
          
            try
            {
                // Abrindo a conexão com o banco de dados;
                conexao.AbirConexao();
                comando = new MySqlCommand(sql, conexao.con);
                quantidade = (long)comando.ExecuteScalar();
                Console.WriteLine(quantidade);
                conexao.FecharConexao();
            }
            // Tratando possíveis erros ...
            catch (Exception ex)
            {
                // Escalando o erro para a classe que chama este método
                throw ex;
            }
            
            
        }


 
    }
}