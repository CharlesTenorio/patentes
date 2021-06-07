using System;

namespace Projetobanco
{
    class Program
    {
        static void Main(string[] args)
        {
            Patente patente = new Patente();
            RepoPatent repoPatent = new RepoPatent();
           do
            {
                Console.Clear();
               
               
                // Perguntar qual é a ação que o usuário deseja
                Console.WriteLine("Escolha uma opção:");
                // Mudando a cor de fundo do texto para Azul
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_______________________ Patente __________________________________");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1 - Inserir Patente");
                Console.WriteLine("2 - Deletar Patente");
                Console.WriteLine("3 - Listar Patente");
                Console.WriteLine("4 - Consultar Patente");
                Console.WriteLine("5 - Alterar Patente");
                Console.WriteLine("6 - Contar Patente");
                Console.ResetColor();
                 
                 try
                 {
                     switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine("Informe o nome da patente:");
                            patente.NomePatente = Console.ReadLine();
                            repoPatent.Inserir(patente);

                            Console.WriteLine("Dados Salvo");
                            break;
                        
                        case '2':
                            Console.Clear();
                            Console.WriteLine("Informe o ID da Patente que você Excluir alterar:");  
                            int cod = int.Parse(Console.ReadLine());
                            repoPatent.Deletar(cod);

                            
                            break;

                        case '3':
                            Console.Clear();
                            repoPatent.Listar("");
                            
                            break;
                        case '4':
                            Console.Clear();
                            Console.WriteLine("Informe Nome da patente pra busca:"); 
                            string Nome= Console.ReadLine();
                            repoPatent.Listar(Nome);
                            
                            break; 
                        
                        case '5':  
                          Console.Clear();
                          Console.WriteLine("Informe o ID da Patente que você deseja alterar:");  
                          
                          patente.IdPatente = int.Parse(Console.ReadLine());
                          Console.WriteLine("Informe o Novo nome da Patente:");  
                          patente.NomePatente=Console.ReadLine();
                          repoPatent.Alterar(patente);
                          break;  


                        case '6':
                            Console.Clear();
                            repoPatent.ObterQuantidadeDePatentes();
                            
                            break; 

                        default:
                            Console.Clear();
                            Console.WriteLine("Opção Indisponível!");
                            break;

                    }        
                 }
                catch (Exception ex)
                {
                 throw ex;
                }
            }
             while (Console.ReadKey().KeyChar == 's');
        }
    }
}
