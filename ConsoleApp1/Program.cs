using ConsoleApp1;

namespace VETOR_CJ3022374
{
    internal class Program
    {
        static void PrintMatrix(int[,] screen) {
            Console.Write("  ");
            for (int i = 1; i <= 4; i++)
            {
                Console.Write("  {0} ", i);
            }
            Console.WriteLine("\n ------------------");

            //impressão
            for (int j = 0; j < 4; j++)
            {
                Console.Write(" {0} ", j + 1);
                for (int k = 0; k < 4; k++)
                {
                    Console.Write(" {0} |", screen[j, k]);
                }
                Console.WriteLine("\n  -----------------");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[,] tela = new int[4, 4];
            int[,] jogo = new int[4, 4];
            int acertos = 0;
            Player p1 = new Player("Gustavo");
            Player p2 = new Player("João");


            Console.WriteLine("Nome: {0}", p1.Name);
            Console.WriteLine("Pontuação: {0}", p1.Score);
            
            Environment.Exit(0);


            Random gerador = new Random();
            DateTime inicio = DateTime.Now;

            int lin, col;

            //vamos gerar os pares de numeros e adicionar na matriz jogo
            for (int i = 1; i <= 8; i++)
            {
                for (int n = 1; n <= 2; n++)
                {
                    do
                    {

                        lin = gerador.Next(0, 4);
                        col = gerador.Next(0, 4);
                    } while (jogo[lin, col] != 0);

                    jogo[lin, col] = i;
                }
            }
            do
            {
                // Imprimir matrix
                Program.PrintMatrix(tela);
                

                int lin1, col1;
                Console.WriteLine("Entre com a linha [1, 4]");
                lin1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Entre com a coluna [1, 4]");
                col1 = int.Parse(Console.ReadLine());

                lin1--; // diminuir, pois o usuário não sane
                col1--; //que existe linha e coluna zero
                tela[lin1, col1] = jogo[lin1, col1];

                //impressão
               Program.PrintMatrix(tela);
                int lin2, col2;
                Console.WriteLine("Entre com a linha [1, 4]");
                lin2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Entre com a coluna [1, 4]");
                col2 = int.Parse(Console.ReadLine());

                lin2--; // diminuir, pois o usuário não sabe
                col2--; //que existe linha e coluna zero
                tela[lin2, col2] = jogo[lin2, col2];

               
                Program.PrintMatrix(tela);

                if (tela[lin1, col1] == tela[lin2, col2])
                {
                    acertos++;
                }

                else // caso não tenha acertado o par
                {
                    tela[lin1, col1] = 0;
                    tela[lin2, col2] = 0;
                }
              
               
                    Console.WriteLine("Digite a para parar ou precione qualquer tecla para continuar: ");
                    string input = Console.ReadLine();

                  
                    
                        if (input == "a")
                        {
                            Console.WriteLine("Jogo encerr.");
                            break;
                        }
                       
                        
                    


            } while (acertos < 8);
        }
    }
}