using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    public class CaixaEletronico
    {
        public List<Caixa> Caixas { get; set; }

        public CaixaEletronico()
        {
            Caixas = new List<Caixa>();
        }

        public List<int> Sacar(int valor)
        {
            int valorRestante = valor;

            List<int> notas = new List<int>();

            while (valorRestante > 0)
            {
                Caixa nota = Caixas.Find(x => x.Valor <= valorRestante && x.Quantidade > 0);

                if (nota == null)
                {
                    throw new Exception("\nNão tem como sacar isso, carai");
                }

                nota.Quantidade -= 1;

                valorRestante -= nota.Valor;

                notas.Add(nota.Valor);
            }

            return notas;
        }
    }
}
