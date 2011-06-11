using CaixaEletronico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class CaixaEletronicoManagerTest
    {
        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void QuandoSaco01()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(1);
        }

        [TestMethod, ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void QuandoSaco03()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(3);
        }

        [TestMethod]
        public void QuandoSaco08()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(8);
            var esperado = new[] { 2, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void QuandoSaco14()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(14);
            var esperado = new[] { 10, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void QuandoSaco21()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(21);
            var esperado = new[] { 10, 5, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado, "Não conseguiu sacar");
        }

        [TestMethod]
        public void QuandoSaco23()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(23);
            var esperado = new[] { 10, 5, 2, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado, "Não conseguiu sacar");
        }

        [TestMethod]
        public void QuandoSaco31()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(31);
            var esperado = new[] { 20, 5, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado, "Não conseguiu sacar");
        }

        [TestMethod]
        public void QuandoSaco33()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(33);
            var esperado = new[] { 20, 5, 2, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado, "Não conseguiu sacar");
        }

        [TestMethod]
        public void QuandoSaco37()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(37);
            var esperado = new[] { 20, 10, 5, 2, };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado, "Não conseguiu sacar");
        }

        [TestMethod]
        public void QuandoSaco41()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(41);
            var esperado = new[] { 20, 10, 5, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado, "Não conseguiu sacar");
        }

        [TestMethod]
        public void QuandoSaco43()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(43);
            var esperado = new[] { 20, 10, 5, 2, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado, "Não conseguiu sacar");
        }

        [TestMethod]
        public void QuandoSaco40()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(40);
            var esperado = new[] { 20, 20 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void QuandoSaco57()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(57);
            var esperado = new[] { 50, 5, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void QuandoSaco58()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(58);
            var esperado = new[] { 50, 2, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void QuandoSaco59()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(59);
            var esperado = new[] { 50, 5, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        public void QuandoSaco351()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(351);
            var esperado = new[] { 100, 100, 100, 20, 20, 5, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        public void QuandoSaco353()
        {
            var caixa = new CaixaEletronicoManager();
            int[] notas = caixa.Sacar(353);
            var esperado = new[] { 100, 100, 100, 20, 20, 5, 2, 2, 2, 2 };
            bool resultado = GetResultado(notas, esperado);
            Assert.IsTrue(resultado);
        }

        private bool GetResultado(int[] notas, int[] esperado)
        {
            bool resultado = notas.Length == esperado.Length;
            for (int i = 0; i < notas.Length && resultado; i++)
                resultado = notas[i] == esperado[i];
            return resultado;
        }
    }
}