using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico
{
    public class CaixaEletronicoManager
    {
        public int[] Sacar(int valor)
        {
            var valoresNotas = new[] { 100, 50, 20, 10, 5, 2 };
            var notas = new List<int>();
            foreach (var valorNota in valoresNotas)
                ProcessaValorNota(ref valor, valorNota, notas);
            if (0 == valor)
                return notas.ToArray();
            var ultimaNotaRemovida = 0;
            do
            {
                valor += ValorDasNotasASeremDescartadas(notas, ultimaNotaRemovida);
                RemoveNotasDescartaveis(notas, ultimaNotaRemovida);
                var notasPossiveis = NotasPossiveis(valoresNotas, valor);
                foreach (var valorNota in notasPossiveis)
                    ProcessaValorNota(ref valor, valorNota, notas);
                ultimaNotaRemovida++;
            } while (valor > 0);
            SubstituiNotasRedundantes(notas, valoresNotas);
            return notas.ToArray();
        }

        private void RemoveNotasDescartaveis(List<int> notas, int ultimaNotaRemovida)
        {
            if (ultimaNotaRemovida == 0)
            {
                notas.Clear();
                return;
            }
            if (notas.Any())
                for (int j = (notas.Count - 1); j >= ultimaNotaRemovida; j--)
                    notas.RemoveAt(j);
        }

        private void SubstituiNotasRedundantes(List<int> notas, int[] valoresNotas)
        {
            for (int i = 0; i < notas.Count - 1; i++)
            {
                var valorTemp = notas[i];
                for (int j = i + 1; j < notas.Count; j++)
                {
                    valorTemp += notas[j];
                    if (valoresNotas.Contains(valorTemp))
                    {
                        notas[i] = valorTemp;
                        notas.RemoveRange(i + 1, j);
                    }
                }
            }
        }

        private IEnumerable<int> NotasPossiveis(int[] valoresNotas, int valor)
        {
            return valoresNotas.Where(x => x <= valor).Skip(1);
        }

        private int ValorDasNotasASeremDescartadas(IList<int> notas, int pegarAte)
        {
            return notas.Skip(pegarAte).Sum(x => x);
        }

        private void ProcessaValorNota(ref int valor, int valorNota, List<int> notas)
        {
            while (valor >= valorNota)
            {
                notas.Add(valorNota);
                valor -= valorNota;
            }
        }
    }
}
