using IgorMonteiroTheMainWords.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IgorMonteiroTheMainWords
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bem vindo.");
                Console.WriteLine("Realizando a primeira etapa do teste.");
                Console.WriteLine("lendo os 10 últimos posts do blog: https://www.minutoseguros.com.br/blog/feed/");
                var reader = new RSSReader();
                Console.WriteLine("...........");
                var itens = reader.GetLastTenPosts();
                Console.WriteLine($"Encontrado {itens.Count} novos posts no blog.");
                Console.WriteLine("Realizando a segunda etapa do teste, 'O seu programa deverá avaliar quais as dez principais palavras abordadas nesses tópicos.'");
                Console.WriteLine("...........");
                var words = reader.GetTopTenWordsInRssTopic(itens);
                Console.WriteLine("As palavras mais encontradas foram:");
                foreach (var item in words)
                {
                    Console.WriteLine($"{item.Word} encontrada {item.Quantity} vezes");
                }
                Console.WriteLine("Desafio finalizado.");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro na execução do desafio.");
            }
        }
    }
}
