using BancoFacec.Dominio.nsExceptions;
using BancoFacec.Dominio.nsInterfaces;
using System;

namespace BancoFacec.Dominio.nsEntidades
{
    public class ContaCorrente : IConta
    {
        #region Propriedades

        public string NomeCliente { get; private set; }
        public bool IsBloqueada { get; private set; }
        public decimal Saldo { get; private set; }

        #endregion Propriedades

        #region Construtores

        public ContaCorrente(string nomeCliente, decimal saldo)
        {
            NomeCliente = nomeCliente ?? throw new ArgumentNullException(nameof(NomeCliente));
            Saldo = saldo;
        }

        #endregion Construtores

        #region Metodos Publicos

        public void Bloquear() => IsBloqueada = true;

        public void Creditar(decimal valor)
        {
            ValidarValor(valor);
            ValidarContaBloqueada();

            Saldo += valor;
        }

        public void Debitar(decimal valor)
        {
            ValidarValor(valor);
            ValidarContaBloqueada();

            Saldo -= valor;
        }

        public void Desbloquear() => IsBloqueada = false;
        public override string ToString() => $"Nome do Cliente: {NomeCliente} \nSaldo R$: {Saldo}";

        #endregion Metodos Publicos

        #region Metodos Privados

        private void ValidarValor(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException("Valor não pode ser negativo ou zero. Verifique!");
        }

        private void ValidarContaBloqueada()
        {
            if (IsBloqueada)
                throw new BusinessRuleException("Conta Corrente encontra-se bloqueada. Não é permitido efetuar movimentações.");
        }

        #endregion Metodos Privados
    }
}