using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo2.Biblioteca.Entidades
{
    public abstract class Alumno : Persona
    {
        private int _registro;

        public int Registro
        {
            get { return this._registro; }
            set { this._registro = value; }
        }

       public Alumno (string nombre, string apellido): base(nombre,apellido)
           {
            this._apellido = apellido;
            this._nombre = nombre;
        }
           
    internal override string Display()
    {
            return "NOMBRE: " + this._apellido + "( " + this._registro + " )";
    }

    }
}
