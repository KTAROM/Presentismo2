using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo2.Excepciones
{
    public class Existente: Exception
    {
        public Existente(string mensaje) : base(mensaje)
        {
        }
    }
}
