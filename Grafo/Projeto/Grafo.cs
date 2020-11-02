using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grafo
{
    class Grafo
    {
        private const int NUM = 20;  //Número de cidades do mapa
        private static bool[] visitado = new bool[NUM];  //Vetor para identificar quais vertices foram visitados
        public int[,] matriz = new int[NUM, NUM] {
           //0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19
            {0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //0
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //1
            {1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //2
            {0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //3
            {0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //4
            {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //5
            {1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //6
            {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //7
            {0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0}, //8
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0}, //9
            {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}, //10
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0}, //11
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0}, //12
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0}, //13
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0}, //14
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0}, //15
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0}, //16
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0}, //17
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0}, //18
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}  //19
        };  //Matriz correspondente ao grafo retirado do mapa

        public void exibirCidades()
        {
            Console.Write("\n\t\t*** Cidades ***");
            Console.Write("\n\t 1 - Piemonte");
            Console.Write("\n\t 2 - Valle D'Aosta");
            Console.Write("\n\t 3 - Lombardia");
            Console.Write("\n\t 4 - Trentino-Alto Adige");
            Console.Write("\n\t 5 - Veneto");
            Console.Write("\n\t 6 - Friuli-Venezia Giulia");
            Console.Write("\n\t 7 - Liguria");
            Console.Write("\n\t 8 - Emilia-Romagna");
            Console.Write("\n\t 9 - Toscana");
            Console.Write("\n\t10 - Umbria");
            Console.Write("\n\t11 - Marche");
            Console.Write("\n\t12 - Lazio");
            Console.Write("\n\t13 - Abruzzo");
            Console.Write("\n\t14 - Molise");
            Console.Write("\n\t15 - Campania");
            Console.Write("\n\t16 - Puglia");
            Console.Write("\n\t17 - Basilicata");
            Console.Write("\n\t18 - Calabria");
            Console.Write("\n\t19 - Sicilia");
            Console.Write("\n\t20 - Sardegna");
        }  //Função para exibir os nomes das cidades

        public void exibirAlgoritmos()
        {
            Console.Write("\n\n\t*** Tipo de busca ***");
            Console.Write("\n\t1 - Busca em profundidade");
            Console.Write("\n\t2 - Busca em largura");
        }  //Função para exibir os algoritmos de busca

        public void retiraCidade(int origem, int destino)
        {
            matriz[origem, destino] = 0;
            matriz[destino, origem] = 0;
        }  //Função reponsavel por excluir as rodovias em obra

        public void limparVisitado()
        {
            for (int i = 0; i < NUM; i++)
            {
                visitado[i] = false;
            }
        }  //Função para limpar o vetor que salva se o vertice foi visitado ao não

        public void buscaProfundidade(int origem, int destino) //Executa a busca em profundidade
        {
            this.limparVisitado(); //Limpa o vetor dos visitados
            List<int> caminho = new List<int>(); //Cria a lista 
            Stack caminhoInverso = new Stack(); //Cria a pilha 

            if (!auxBuscaPronfundidade(origem, destino, caminhoInverso)) //Chama o metodo auxBuscaPronfundidade dentro de um if para que tome as providencias assim q a função retornar a resposta
            {
                Console.Write("Caminho não encontrado...\n\n");  //Se o retorno for "false" sinifica que o caminho não foi encontrado
            }
            else  //Se o retorno for "true"
            {
                foreach (int item in caminhoInverso)  //Percorre todos elementos da pilha
                {
                    caminho.Add(item);  //e add na lista
                }
                caminho.Reverse();  //inverte a ordem da lista pois como estava na pilha o ultimo a entrar ficara no topo, então é feito a inversão
                                    //para exibir na ordem correta

                foreach (int item in caminho)
                {
                    Console.Write(" " + item);  //exibe para o usuario o caminho percorrido 
                }

            }

        }

        private bool auxBuscaPronfundidade(int origem, int destino, Stack caminhoInverso) //metodo para informar o caminho feito com busca de profundidade
        {
            visitado[origem] = true; //Marca a posição como visitada para não ficar repetindo a mesma
            caminhoInverso.Push(origem + 1); //Insere o vertice na pilha

            if (visitado[destino] == true) //Se o vertice for visitado retorna "true"
            {
                return true;
            }

            for (int i = 0; i < NUM; i++)  //Verifica todas as colunas
            {
                if (matriz[origem, i] == 1) //Verifica se os vertices estão conectados
                {
                    if (visitado[i] == false) //Se não estiver visitado
                    {
                        if (auxBuscaPronfundidade(i, destino, caminhoInverso)) //Executa a recursividade dentro do if para pegar o retorno correto
                        {
                            return true;
                        }
                    }
                }
            }
            caminhoInverso.Pop(); //Retira da pilha caso não seja o caminho
            return false;
        }

        public void buscaLargura(int origem, int destino)  //Executa a busca em largura
        {
            this.limparVisitado();  //Limpa o vetor dos visitados
            List<int> caminho = new List<int>(); //Cria a lista para ficar no lugar da recursividade
            List<int> caminhoAux = new List<int>(); //Cria a lista que sera o caminho

            caminho.Add(origem); //Add o vertice na lista
            caminhoAux.Add(origem + 1); //Add o vertice na lista (+1 para exibir bonito para o usuario)

            if (!auxBuscaLargura(origem, destino, caminho, caminhoAux)) //Chama o metodo auxBuscaLargura dentro de um if para que tome as providencias assim q a função retornar a resposta
            {
                Console.Write("Caminho não encontrado...\n\n"); //Se for "false" o caminho não foi encontrado
            }
            else //Se for "true" o caminho foi encontrado
            {
                foreach (int item in caminhoAux) //Percorre todos os vertices add na lista
                {
                    Console.Write(" " + item); //e exibe para o usuario
                }
            }
        }

        private bool auxBuscaLargura(int origem, int destino, List<int> caminho, List<int> caminhoAux) //Metodo para informar o caminho feito na busca em largura
        {
            visitado[origem] = true;  //Marca o vertice origem como visitado
            if (visitado[destino] == true)  //Caso o vertice de destino ja tenha sido visitado
            {
                return true; //retorna "true" para finalizar o processo
            }

            for (; caminho.Count() > 0;) //Enquanto a lista não estiver vazia
            {
                for (int i = 0; i < NUM; i++) //Percorre todas as colunas
                {
                    if (matriz[origem, i] == 1 && visitado[i] == false) //Caso os vertices estejam conectados e não foi visitado ainda
                    {
                        visitado[i] = true; //marca o vertice como visitado
                        caminho.Add(i); //add ele na lista que substitui a recursividade
                        caminhoAux.Add(i + 1); //add ele na lista de exibição (+1 para ficar bonito para o usuario)
                        if (i == destino) // se o vertice visitado no momento for o vertice de destino
                        {
                            return true; //retorna "true" e finaliza o processo
                        }
                    }
                }
                caminho.RemoveAt(0); //Remove sempre o primeiro elemento da lista
                if (caminho.Count() > 0)
                {
                    origem = caminho.First(); //origem recebe o proximo elemento da lista apos a remoção acima
                }

            }

            return false;
        }

    }
}