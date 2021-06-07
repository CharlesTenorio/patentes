using System;
using MySqlConnector;
namespace Projetobanco
{
    internal class Conexao
    {
        public Conexao()
        {
        }

         string conecta = "Server=localhost;Port=3306;Database=testdb;Uid=sammy;Pwd=Linux@162;";
        public MySqlConnection con = null;

        public void AbirConexao(){
            try{
                 con = new MySqlConnection(conecta);
                 con.Open();

            }
            catch(Exception ex){
                throw ex;
            }

        }

         public void FecharConexao(){
             try{
                 con = new MySqlConnection(conecta);
                 con.Close();

            }
            catch(Exception ex){
                throw ex;
            }
        }
 
    }
}