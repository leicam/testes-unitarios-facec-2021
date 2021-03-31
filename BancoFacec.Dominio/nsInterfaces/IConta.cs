using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFacec.Dominio.nsInterfaces
{
    public interface IConta
    {
        void Bloquear();
        void Creditar(decimal valor);
        void Debitar(decimal valor);
        void Desbloquear();
    }
}