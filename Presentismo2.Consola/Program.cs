using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentismo2.Biblioteca.Entidades;
using Presentismo2.Biblioteca;
using Presentismo2.Excepciones;

namespace Presentismo2.Consola
{
    class Program
    {
        private static Presentismo _presentismo;
        static Program()
        {
            _presentismo = new Presentismo();

        }
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();
          
            bool estado;
            do
            {
                Console.Clear();
                DesplegarOpcionesMenu();
                string opcionMenu = Console.ReadLine();
                estado = true;
                switch (opcionMenu.ToUpper())
                {
                    case "1":
                        TomarAsistencia(preceptorActivo);
                        break;
                    case "2":
                        MostrarAsistencia();
                        break;
                    case "X":
                        // SALIR
                        estado = false;
                        break;
                    default:
                        Utils.MsjErr();
                        Console.ReadKey();
                        break;
                }
            } while (estado);
        }
        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
        }
        static void TomarAsistencia(Preceptor p)
        {

            DateTime fecha1 = Utils.PedirFecha("Ingrese la fecha en la cual se tomará asistencia");
            // Ingreso fecha
            string fecha = Utils.ConvertirFecha(fecha1);
            fecha1 = DateTime.Now;
            List<Asistencia> asistencia1 = null;
            try
            {
                List<Alumno> Alumnos1 = _presentismo.GetListaAlumnos(fecha);
                asistencia1 = new List<Asistencia>();
                bool respuesta;
                foreach (Alumno alum in Alumnos1)
                {
                    if (alum is AlumnoOyente)
                    {
                        Console.WriteLine("El alumno "+alum.ToString()+" es OYENTE");
                        
                    }
                    else if (alum is AlumnoRegular)
                    {
                        Console.WriteLine(alum.ToString());
                        respuesta = Utils.PedirSoN("Indique si el alumno esta presente S/N");
                        Asistencia asist1 = new Asistencia(fecha, fecha1, p, alum, respuesta);
                        asistencia1.Add(asist1);

                    }
                }
                Console.ReadKey();
                _presentismo.AgregarAsistencia(asistencia1, fecha);
            }
            catch (Existente ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();

            }

           
           
            // Listar los alumnos
            // para cada alumno solo preguntar si está presente
            // agrego la lista de asistencia
            // Error: mostrar el error y que luego muestre el menu nuevamente
        }
        static void MostrarAsistencia()
        {
            DateTime fecha1 = Utils.PedirFecha("Ingrese la fecha que desea consultar");
            string fecha = Utils.ConvertirFecha(fecha1);
            List<Asistencia> asistfecha;
            try
            {
                asistfecha=_presentismo.GetAsistenciasPorFecha(fecha);
                foreach(Asistencia asist in asistfecha)
                {
                    Console.WriteLine(asist.ToString());
;               }
                Console.ReadKey();

            }
            catch( Inconsistente ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            // ingreso fecha
            // muestro el toString de cada asistencia
        }
    }
}

