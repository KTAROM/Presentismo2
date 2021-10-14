using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo2.Biblioteca.Entidades
{
    public class Preceptor:Persona
    {
        private int _legajo;

        public Preceptor(int legajo, string nombre, string apellido):base (nombre, apellido)
        {
            this._legajo = legajo;
        }
        internal override string Display()
        {
            return "APELLIDO " + this._apellido + " LEGAJO: " + this._legajo;
        }
    }
}
