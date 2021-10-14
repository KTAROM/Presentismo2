using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo2.Biblioteca.Entidades
{
    public class AlumnoRegular:Alumno
    {
        private string _email;

        public AlumnoRegular(int registro, string nombre, string apellido, string email): base(nombre, apellido)
        {
            this._apellido = apellido;
            this._nombre = nombre;
            this.Registro = registro;
            this._email = email;
        }
    }
}
