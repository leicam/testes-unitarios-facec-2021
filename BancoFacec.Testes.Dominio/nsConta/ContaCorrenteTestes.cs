using BancoFacec.Dominio.nsEntidades;
using BancoFacec.Dominio.nsExceptions;
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

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrete_Creditar_ExpectedBusinessRuleExceptionContaBloqueada()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);
            contaCorrente.Bloquear();

            // Act
            // Assert
            Assert.ThrowsException<BusinessRuleException>(
                () => contaCorrente.Creditar(10.00m),
                "Não foi gerada exception no momento de creditar um valor para conta corrente quando a conta está bloqueada. Verifique!");
        }

        #endregion Creditar

        #region Construtor

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrente_Construtor_ExceptedSucesso()
        {
            try
            {
                //Arrange
                //Act
                var conta = new ContaCorrente("Juliano", 100.00m);
            }
            catch(Exception ex)
            {
                //Assert
                Assert.Fail($"Não foi possivel efetuar a criação do objeto de ContaCorrente. Verifique!\n{ex.Message}");
            }
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrente_Construtor_ExceptedArgumentNullException()
        {
            //Arrange
            //Act
            //Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new ContaCorrente(null, 100.00m),
                "Não foi gerada exception para passagem de nome de cliente null. Verifique!");
        }

        #endregion Construtor

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

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void ContaCorrete_Debitar_ExpectedBusinessRuleExceptionContaBloqueada()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Juliano", 100.00m);
            contaCorrente.Bloquear();

            // Act
            // Assert
            Assert.ThrowsException<BusinessRuleException>(
                () => contaCorrente.Debitar(10.00m),
                "Não foi gerada exception no momento de debitar um valor para conta corrente quando a conta está bloqueada. Verifique!");
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