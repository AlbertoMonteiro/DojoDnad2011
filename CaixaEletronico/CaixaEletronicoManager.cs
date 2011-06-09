using System;
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
                var primeira = (((valor - notas[0]) % 2) == 1);
                var segunda = DivisorDe10(valor);
                int n = primeira && segunda ? notas[1] : notas[0];
                valor = valor - n;
                lista.Add(n);
            }
            return lista.OrderByDescending(x => x).ToArray();
        }

        private bool DivisorDe10(int valor1)
        {
            var a = ((valor1 % 5 == 3) || (valor1 % 5 == 1));
            var b = new[] { 10, 5, 1, 2, 0 }.Contains((valor1 - (valor1 % 5)) / 10);
            return a && b;
        }
    }
}