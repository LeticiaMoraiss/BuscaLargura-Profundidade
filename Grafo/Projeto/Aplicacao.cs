using System;

namespace Grafo.Projeto
{
    class Aplicacao
    {
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();  //Instancia o objeto do tipo grafo
            string origem, destino;  //variaveis para receber origem e destino do usuario

            grafo.exibirCidades(); //exibe as cidades

            for (int parada = 0; parada != 1;)
            {
                Console.Write("\n\n\tAlguma rodovia em obra? (s/n): ");
                string resposta = Console.ReadLine();
                if (null == resposta)
                {
                    Console.Write("\n\tOpção invalida!\n");
                }
                switch (resposta)
                {
                    case "s":
                        do
                        {
                            Console.Write("\n\tInforme a linha: ");
                            origem = Console.ReadLine();
                        } while (origem == "" || origem == null);

                        do
                        {
                            Console.Write("\n\tInforme a coluna: ");
                            destino = Console.ReadLine();
                        } while (destino == "" || destino == null);

                        grafo.retiraCidade(Convert.ToInt32(origem) - 1, Convert.ToInt32(destino) - 1);
                        parada = 1;
                        break;

                    case "n":
                        parada = 1;
                        break;

                    default:
                        Console.Write("\n\tOpção invalida!\n");
                        break;
                }
            }

            Console.Clear(); //Limpa a tela
            grafo.exibirCidades(); //exibe as cidades

            do
            {
                Console.Write("\n\n\tInforme o número correspondente a cidade de origem: ");
                origem = Console.ReadLine();
            } while (origem == "" || origem == null);

            do
            {
                Console.Write("\n\n\tInforme o número correspondente a cidade de destino: ");
                destino = Console.ReadLine();
            } while (destino == "" || origem == null);

            grafo.exibirAlgoritmos();
            Console.Write("\n\n\tInforme o número correspondente ao tipo de busca: ");
            int busca = Convert.ToInt32(Console.ReadLine());

            for (int parada = 0; parada != 1;)
            {
                switch (busca)
                {
                    case 1:
                        parada = 1;
                        Console.Write("\n\n\tBuscando....\n");
                        Console.Write("\n\tBusca em profundidade: ");
                        grafo.buscaProfundidade(Convert.ToInt32(origem) - 1, Convert.ToInt32(destino) - 1);
                        break;

                    case 2:
                        parada = 1;
                        Console.Write("\n\n\tBuscando....\n");
                        Console.Write("\n\tBusca em largura: ");
                        grafo.buscaLargura(Convert.ToInt32(origem) - 1, Convert.ToInt32(destino) - 1);
                        break;

                    default:
                        Console.Write("\n\tOpção Invalida...\n");
                        break;
                }
            }

            Console.WriteLine("\n\n\n\tPressione 'ENTER' para continuar. . .");
            Console.ReadKey();
        }
    }
}
