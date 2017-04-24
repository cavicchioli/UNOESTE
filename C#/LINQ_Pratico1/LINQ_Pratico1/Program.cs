using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Pratico1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria os dados
            IList<Fruta> fonteDados = criaDados();
            // Filtra baseado em uma única característica
            IEnumerable<string> resultado1 = from e in fonteDados
                                             where e.Cor == "vermelha"
                                             select e.Nome;

            Console.WriteLine("Filtrar por fruta - vermelha");
            foreach (string str in resultado1)
            {
                Console.WriteLine("Fruta {0}", str);
            }
            // Filtro usando o operador >
            IEnumerable<Fruta> resultado2 = from e in fonteDados
                                            where e.Preco > 5
                                            select e;

            Console.WriteLine("\nFiltrar para preco > 5");
            foreach (Fruta Fruta in resultado2)
            {
                Console.WriteLine("Fruta {0}", Fruta.Nome);
            }
            // Filtra usando duas caracteristicas
            IEnumerable<string> resultado3 = from e in fonteDados
                                             where e.Cor == "verde"
                                             && e.Preco > 5
                                             select e.Nome;

            Console.WriteLine("\nFiltrar para Fruta verde e preco > 5");
            foreach (string str in resultado3)
            {
                Console.WriteLine("Fruta {0}", str);
            }
            //
            // Aguarda para continuar.
            Console.WriteLine("\nOperação concluída. Pressione Enter");
            Console.ReadLine();
        }
        /// <summary>
        /// criaDados -cria uma coleção de frutas
        /// </summary>
        /// <returns></returns>
        static IList<Fruta> criaDados()
        {
            return new List<Fruta>()
          {
             new Fruta("maça", "verde", 7),
             new Fruta("laranja", "laranja", 10),
             new Fruta("uva", "verde", 4),
             new Fruta("figo", "marrom", 12),
             new Fruta("ameixa", "vermelha", 2),
             new Fruta("banana", "amarela", 10),
             new Fruta("morango", "vermelha", 7)
           };
        }
        /// <summary>
        /// Fruta - defina a classe fruta com: nome ,cor e preco
        /// </summary>
        class Fruta
        {
            public Fruta(string namearg, string corarg, int precoarg)
            {
                Nome = namearg;
                Cor = corarg;
                Preco = precoarg;
            }
            public string Nome { get; set; }
            public string Cor { get; set; }
            public int Preco { get; set; }
        }
    }
}
