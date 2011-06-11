using System.Collections.Generic;
using System.Linq;
using System;

namespace CaixaEletronico
{
    public class CaixaEletronicoManager
    {
        private readonly int[] _notas = { 2, 5, 10, 20, 50, 100 };

        public int[] Sacar(int value)
        {
            if (value <= 1 || value == 3)
                throw new InvalidOperationException("Não posso sacar esse valor");

            var lista = new List<int>();
            int valor = value;
            while (valor > 0)
            {
                var notas = _notas.Where(x => x <= valor).ToArray();
                var primeira = valor % 5 != 0;
                int n = primeira ? notas[0] : notas[notas.Length - 1];
                valor = valor - n;
                lista.Add(n);
            }
            return lista.OrderByDescending(x => x).ToArray();
        }
    }
}