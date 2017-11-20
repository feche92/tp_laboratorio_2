using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {

        /// <summary>
        /// serializa los datos en la direccion que se le pasan como parametros
        /// </summary>
        /// <param name="archivo">direccion del archivo</param>
        /// <param name="datos">datos a serializar</param>
        /// <returns>retorna true si esta todo bien o false en caso de error</returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                TextWriter escritor = new StreamWriter(archivo);
                xml.Serialize(escritor, datos);
                escritor.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// desarializa los datos previamente serializados en la direccion del archivo xml que se le pasa como parametro
        /// </summary>
        /// <param name="archivo">direccion del archivo a desarializar</param>
        /// <param name="datos">guarda los datos desarializados</param>
        /// <returns>retorna true si salio todo bien o false caso contrario</returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                TextReader lector = new StreamReader(archivo);
                datos = (T)xml.Deserialize(lector);
                lector.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
                return false;
            }
        }
    }
}
