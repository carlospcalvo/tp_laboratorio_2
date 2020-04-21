using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static public class Calculadora
    {
        #region Métodos
        
        /// <summary>
        /// Permite sumar, restar, multiplicar y dividir dos objetos de la clase Numero
        /// </summary>
        /// <param name="num1"> Numero: sumando n°1, minuendo, factor n° 1 o dividendo </param>
        /// <param name="num2"> Numero: sumando n°2, sustraendo, factor n° 2 o divisor </param>
        /// <param name="operador"> string: operador que define qué cálculo se hará </param>
        /// <returns> Double: suma, diferencia, producto o cociente </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double rta;

            switch (ValidarOperador(operador))
            {
                case "-":
                    rta = num1 - num2;
                    break;
                case "*":
                    rta = num1 * num2;
                    break;
                case "/":
                    if((num2 / num1 ) != 0)
                    {
                        rta = num1 / num2;
                    }
                    else
                    {
                        rta = double.MinValue;
                    }
                    break;
                default:
                    rta = num1 + num2;
                    break;
            }

            return rta;
        }

        /// <summary>
        /// Permite validar el operador elegido.
        /// </summary>
        /// <param name="operador"> string: cadena a evaluar como operador </param>
        /// <returns> string: en caso de ser un operador, devuelve el mismo; si no, devuelve el operador "+" </returns>
        private static string ValidarOperador(string operador)
        {
            string rta;

            switch (operador)    
            {
                case "-":
                    rta = "-";
                    break;
                case "*":
                    rta = "*";
                    break;
                case "/":
                    rta = "/";
                    break;
                default:
                    rta = "+";
                    break;
            }
            return rta;
        }
        #endregion
    }
}
