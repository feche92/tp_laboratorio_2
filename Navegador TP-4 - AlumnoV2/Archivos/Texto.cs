using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(this.archivo,true);
                escritor.WriteLine(datos);
                escritor.Close();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool leer(out List<string> datos)
        {
            try
            {
                List<string> auxiliar = new List<string>();
                StreamReader lector = new StreamReader(archivo);
                while (!lector.EndOfStream)
                {
                    auxiliar.Add(lector.ReadLine());
                }
                datos = auxiliar;
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
            

            
        }
    }
}
