using BancoFacec.Dominio.nsEntidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFacec.Testes.Dominio.nsConta
{
    [TestClass]
    public class ContaCorrenteTestes
    {
        private const string _owner = "Juliano";
        private const string _category = "IConta";

        #region Bloquear

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrente_Bloquear_ExpectedSucesso()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            // Act
            contaCorrente.Bloquear();

            // Assert
            Assert.AreEqual(true, contaCorrente.IsBloqueada);
        }

        #endregion Bloquear

        #region Creditar

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrete_Creditar_ExpectedSucesso()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            // Act
            contaCorrente.Creditar(10.00m);

            // Assert
            Assert.AreEqual(110.00m, contaCorrente.Saldo);
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrete_Creditar_ExpectedArgumentOutOfRangeExceptionValorZerado()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => contaCorrente.Creditar(0.00m), 
                "Não foi gerada exception para valor zero como parâmetro. Verifique!");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrete_Creditar_ExpectedArgumentOutOfRangeExceptionValorNegativo()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => contaCorrente.Creditar(-1.00m),
                "Não foi gerada exception para valor zero como parâmetro. Verifique!");
        }

        #endregion Creditar

        #region Debitar

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrente_Debitar_ExpectedSucesso()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            //Act
            contaCorrente.Debitar(10.00m);

            //Assert
            Assert.AreEqual(90.00m, contaCorrente.Saldo);
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrete_Debitar_ExpectedArgumentOutOfRangeExceptionValorZerado()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => contaCorrente.Debitar(0.00m),
                "Não foi gerada exception para valor zero como parâmetro. Verifique!");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrete_Debitar_ExpectedArgumentOutOfRangeExceptionValorNegativo()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => contaCorrente.Debitar(-1.00m),
                "Não foi gerada exception para valor zero como parâmetro. Verifique!");
        }

        #endregion Debitar

        #region Desbloquear

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrente_Desbloquear_ExpectedSucesso()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);

            // Act
            contaCorrente.Bloquear();
            contaCorrente.Desbloquear();

            // Assert
            Assert.AreEqual(false, contaCorrente.IsBloqueada);
        }

        #endregion Desbloquear
    }
}