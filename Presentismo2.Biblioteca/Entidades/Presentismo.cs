using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentismo2.Excepciones;

namespace Presentismo2.Biblioteca.Entidades
{
   public class Presentismo
    {
        private List<Preceptor> _preceptores;
        private List<Alumno> _alumnos;
        private List<Asistencia> _asistencias;
        private List<string> _fechas;

        private bool AsistenciaRegistrada( string fecha)
        {
            if (this._fechas== null)
            {
                throw new Inconsistente("No se han registrado asistencias");
            }
            else
            {
                foreach (string dia in this._fechas)
                {
                    if (dia == fecha)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int GetCantidadAlumnosRegulares()
        {
            int cantidad = 0;
            if(!_alumnos.Any())
            {
                throw new SinAlumnos("No hay alumnos registrados");
            }
            foreach(Alumno alum in _alumnos)
            {
                if(alum is AlumnoRegular)
                {
                    cantidad += 1;
                }
            }
            return cantidad;
        }

        public Preceptor GetPreceptorActivo()
        {
            Preceptor preceptorActivo = null;
           if(_preceptores!=null)
            {
                preceptorActivo = _preceptores.Last();
            }

            return preceptorActivo;
        }

        public List<Alumno> GetListaAlumnos(string fecha)
        {
           
            if (AsistenciaRegistrada(fecha))
            {
                throw new Existente("Ya ha sido registrada la asistencia de la fecha " + fecha);
            }

            return _alumnos;
        }
        public void AgregarAsistencia(List<Asistencia> asistencias, string fecha)
        {
            if(asistencias.Count()!=GetCantidadAlumnosRegulares())
            {
                throw new Inconsistente("Asistencia Inconsistente!!!");
            }
            this._fechas.Add(fecha);
            
            this._asistencias.AddRange(asistencias);

        }

        public List<Asistencia> GetAsistenciasPorFecha(string fecha)
        {
            if(!AsistenciaRegistrada(fecha))
            {
                throw new Inconsistente("No hay registros para la fecha " + fecha);
            }
            List<Asistencia> asistPorFecha = new List<Asistencia>();
            foreach(Asistencia asist in _asistencias)
            {
                if(asist.FechaReferencia==fecha)
                {
                    asistPorFecha.Add(asist);
                }
            }
            return asistPorFecha;
        }
        public Presentismo()
        {
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            _preceptores = new List<Preceptor>();
            _fechas = new List<string>();
            _alumnos.Add(new AlumnoRegular(123, "Carlos", "Juarez", "cjua@gmail.com"));
            _alumnos.Add(new AlumnoRegular(124, "Carla", "Jaime", "cjai@gmail.com"));
            _alumnos.Add(new AlumnoOyente(320, "Ramona", "Vals"));
            _alumnos.Add(new AlumnoOyente(321, "Alejandro", "Medina"));
            _preceptores.Add(new Preceptor(5, "Jorgelina", "Ramos"));
        }
    }
}
