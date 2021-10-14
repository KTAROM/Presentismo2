using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo2.Biblioteca.Entidades
{
    public class AlumnoOyente: Alumno
    {
        public AlumnoOyente(int registro, string nombre, string apellido): base(nombre, apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this.Registro = registro;
        }
    }
}
