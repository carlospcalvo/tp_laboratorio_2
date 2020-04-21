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
            double num;
            double aux;
            double cont = Convert.ToDouble(binario.Length-1);
            double acumulador = 0;
            bool flag = false;
            bool isNumeric = Double.TryParse(binario, out num);
            

            if (isNumeric == true && num >= 0)
            { 
                foreach(char c in binario)
                {
                    //toma el valor de un dígito
                    Double.TryParse(c.ToString(), out aux); 
                    if (aux == 1)
                    {
                        flag = true;
                        //si ese dígito es 1, suma 2 ^ índice al acumulador (ej: en el último índice suma 2^0 = 1) 
                        acumulador += Math.Pow(2, cont); 
                    }
                    else if (aux ==0)
                    {
                        //si el dígito es 0 no hace nada, únicamente mantiene el flag en true
                        flag = true; 
                    }
                    else
                    {
                        /* si un dígito es igual o mayor a 2, setea el flag en false 
                          y rompe el foreach para salir y mostrar que es un valor inválido. */
                        flag = false; 
                        break; 
                    }
                    cont--;
                }
                if (flag == true)
                {
                    /* si se recorrió el string sin problemas, el acumulador se parsea a string 
                    para retornarlo como resultado.*/
                    rta = acumulador.ToString(); 
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
            bool isNumeric = Double.TryParse(numero, out Double num);
            if (isNumeric == true)
            {
                rta = DecimalBinario(num);
            }
            else
            {
                rta = "Valor invalido.";
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
            string rta;
            long num = (long)numero;
            
            if (num >= 0)
            {
                //Convierte un int a string pasándolo a base 2 (binario)   
                rta = Convert.ToString(num, 2); 
            }
            else
            {
                rta = "Valor invalido.";
            }
            return rta;
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
            double num;
            double.TryParse(strNumero, out num);
            return num;
        }

        #endregion

    }
}
