using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico
{
    public class CaixaEletronicoManager
    {
        private int[] _notas = { 100, 50, 20, 10, 5, 2 };

        public int[] Sacar(int value)
        {
            var lista = new List<int>();
            int valor = value;
            while (valor > 0)
            {
                var notas = _notas.Where(x => x <= valor).ToArray();
                int n = ((((valor - notas[0]) % 2) == 1) && (valor <= 23)) ? notas[1] : notas[0];
                valor = valor - n;
                lista.Add(n);
            }
            return lista.OrderByDescending(x => x).ToArray();
        }
    }
}