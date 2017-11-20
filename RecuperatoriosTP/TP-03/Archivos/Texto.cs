using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {

        /// <summary>
        /// guarda los datos en la direccion del archivo que se la pasen como parametros
        /// </summary>
        /// <param name="archivo">direccion donde se va a guardar los datos</param>
        /// <param name="datos">datos a ser guardado</param>
        /// <returns>retorna true si se guardo bien o false en caso de error</returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter file = new StreamWriter(archivo);
                file.WriteLine(datos);
                file.Close();                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// lee los datos de la direccion del archivo que se le pasa como parametro
        /// </summary>
        /// <param name="archivo">direccion del archivo a ser leida</param>
        /// <param name="datos">guarda los datos de la ubicacion del archivo</param>
        /// <returns>retorna true si esta todo bien o false en caso de error</returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                StreamReader file = new StreamReader(archivo);
                datos = file.ReadToEnd();
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = "";
                return false;
            }
        }
    }
}
