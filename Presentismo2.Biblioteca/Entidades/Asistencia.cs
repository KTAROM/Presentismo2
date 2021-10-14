using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo2.Biblioteca.Entidades
{
    public class Asistencia
    {
        private string _fechaReferencia;
        private DateTime _fechaHoraReal;
        private Preceptor _preceptor;
        private Alumno _alumno;
        private bool _estaPresente;

        public string FechaReferencia
        {
            get { return this._fechaReferencia; }
        }

        public override string ToString()
        {
            string presente;
            if (_estaPresente) { presente = "SI"; }
            else { presente = "NO"; }

            return this.FechaReferencia +"\n"+ _alumno.Display() + " esta presente " + presente + " por " 
                + _preceptor.Display()+"\nRegistrado el "+_fechaHoraReal;
              
        }
        public Asistencia(string fechaRef, DateTime fechaReal, Preceptor precep,Alumno alumno, bool presente)
        {
            this._fechaReferencia = fechaRef;
            this._fechaHoraReal = fechaReal;
            this._preceptor = precep;
            this._alumno = alumno;
            this._estaPresente = presente;
        }
    }
}
