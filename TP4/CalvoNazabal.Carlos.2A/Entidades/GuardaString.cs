using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool aux = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            try
            {
                using (StreamWriter sw = new StreamWriter(path + @"\" + archivo , true))
                {
                    sw.WriteLine(texto);
                }
                aux = true;
            }
            catch (Exception)
            {
                throw new Exception("No se pudo guardar el archivo de texto.");
            }

            return aux;
        }


    }
}
