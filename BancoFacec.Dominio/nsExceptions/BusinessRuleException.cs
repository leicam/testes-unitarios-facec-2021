using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFacec.Dominio.nsExceptions
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException() { }
        public BusinessRuleException(string message) : base(message) { }
    }
}