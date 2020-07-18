using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos

        private double numero;

        #endregion

        #region Propiedades
        private string SetNumero
        {
            set 
            { 
                this.numero = this.ValidarNumero(value); 
            }
        }
        
        #endregion
        
        #region Métodos


        /// <summary>
        /// Convierte un string que representa un número binario en un string que representa su notación decimal.
        /// </summary>
        /// <param name="binario"> string: Número binario a ser convertido </param>
        /// <returns> string: Notación decimal del número pasado como parámetro </returns>
        public string BinarioDecimal(string binario)
        {
            string rta = "Valor invalido.";
            int num;
            bool isNumeric = EsBinario(binario);

            if (isNumeric == true)
            {
                num = Convert.ToInt32(binario, 2);

                if (num >= 0)
                {
                    rta = num.ToString();
                }
                else
                {
                    num = Math.Abs(num);
                    rta = num.ToString();
                }
            }

            return rta;
        }

        /// <summary>
        /// Convierte un string que representa un número decimal en un string que representa el mismo número en notación binaria.
        /// </summary>
        /// <param name="numero"> string: número decimal a ser convertido en binario </param>
        /// <returns> string: notación binaria del número decimal pasado como parámetro </returns>
        public string DecimalBinario(string numero)
        {
            string rta;
            bool isNumeric = Int32.TryParse(numero, out int num);
            if (isNumeric == true)
            {
                rta = DecimalBinario(num);
            }
            else
            {
                rta = "Valor inválido.";
            }
            return rta;
        }

        /// <summary>
        /// Convierte un double en un string que representa el mismo número en notación binaria
        /// </summary>
        /// <param name="numero"> Double: número a ser convertido en binario </param>
        /// <returns> string: notación binaria del número decimal pasado como parámetro </returns>
        public string DecimalBinario(double numero)
        {
            string rta = "Valor Invalido";
            int aux = (int)numero;
            int bin;

            if (aux < 0)
            {
                aux = Math.Abs(aux);
            }

            if (aux >= 0)
            {
                rta = "";
                
                if(aux == 0)
                {
                    rta = "0";
                }
                else
                {
                    while (aux >= 1)
                    {
                        bin = aux % 2;
                        aux /= 2;
                        rta = (bin.ToString() + rta);
                    }
                }                
            }
            return rta;
        }

        private bool EsBinario(string numero)
        {
            bool aux = true;

            foreach(char c in numero)
            {
                if(!(c == '1' || c == '0'))
                {
                    aux = false;
                    break;
                }
            }
            return aux;
        }

        #endregion

        #region Constructores

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Sobrecarga de Operadores

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        #endregion

        #region Validación

        /// <summary>
        /// Permite validar si un string ingresado como parámetro es un número
        /// </summary>
        /// <param name="strNumero"> string: la cadena a ser evaluada </param>
        /// <returns> double: si la cadena era un numero, lo devuelve como double; si no, devuelve 0 </returns>
        private double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double num);
            return num;
        }

        #endregion

    }
}
