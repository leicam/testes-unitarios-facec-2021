using BancoFacec.Dominio.nsEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFacec.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Gera ArgumentNullException
                //var contaCorrente = new ContaCorrente(null, 120.00m);

                var contaCorrente = new ContaCorrente("Juliano", 120.00m);

                contaCorrente.Creditar(35.00m);
                contaCorrente.Debitar(7.35m);

                Console.WriteLine(contaCorrente.ToString());

                // Gera BusinessRuleException
                //contaCorrente.Bloquear();
                //contaCorrente.Debitar(73.00m);

                contaCorrente.Bloquear();
                contaCorrente.Desbloquear();
                contaCorrente.Creditar(1500.99m);

                Console.WriteLine(contaCorrente.ToString());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}