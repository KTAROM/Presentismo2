using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo2.Excepciones
{
    public class SinAlumnos:Exception
    {
        public SinAlumnos(string mensanje): base( mensanje)
        {

        }
    }
}
