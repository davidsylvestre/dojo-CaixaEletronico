using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                CaixaEletronico caixaEletronico = new CaixaEletronico();

                //caixaEletronico.Caixas.Add(new Caixa { Quantidade = 1, Valor = 100 });
                //caixaEletronico.Caixas.Add(new Caixa { Quantidade = 1, Valor = 50 });
                //caixaEletronico.Caixas.Add(new Caixa { Quantidade = 0, Valor = 20 });
                //caixaEletronico.Caixas.Add(new Caixa { Quantidade = 0, Valor = 10 });
                //caixaEletronico.Caixas.Add(new Caixa { Quantidade = 0, Valor = 5 });
                //caixaEletronico.Caixas.Add(new Caixa { Quantidade = 1, Valor = 2 });
                //caixaEletronico.Caixas.Add(new Caixa { Quantidade = 1, Valor = 1 });




                caixaEletronico.Caixas.FirstOrDefault(x => x.Quantidade == 10);




                string notasDisponiveis = NotasDisponiveis(caixaEletronico);

                if (notasDisponiveis == "")
                {
                    Console.WriteLine("Estamos sem dinheiro no momento");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"Notas disponiveis: {notasDisponiveis}");

                Console.WriteLine("\nDigite o valor a ser sacado:\n");

                int valor = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\nNotas sacadas: {NotasSaque(caixaEletronico.Sacar(valor))}");

                ExibirCaixa(caixaEletronico);

                Console.ReadLine();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
                Console.ReadLine();
            }
        }

        static void ExibirCaixa(CaixaEletronico caixaEletronico)
        {
            Console.WriteLine("\nInformações do caixa eletronico:\n");
            foreach (Caixa caixa in caixaEletronico.Caixas)
            {
                Console.WriteLine($"Nota: {caixa.Valor}, Quantidade: {caixa.Quantidade}");
            }
        }

        static string NotasDisponiveis(CaixaEletronico caixaEletronico)
        {
            List<int> notas = caixaEletronico.Caixas
                                                .FindAll(x => x.Quantidade > 0)
                                                .Select(caixa => caixa.Valor)
                                                .ToList();

            return NotasSaque(notas);
        }

        static string NotasSaque(List<int> valores)
        {
            return string.Join(", ", valores);
        }
    }
}
