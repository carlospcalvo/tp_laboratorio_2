using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace TP_02_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la pantalla
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight - 2);

            // Nombre del alumno
            Console.Title = "Carlos Calvo Nazabal - 2A";

            Estacionamiento estacionamiento = new Estacionamiento(6);
            //se renombraron las variables para que tengan la inicial del tipo (ej: a1 -> Auto, m1 -> Moto, c1 -> Camioneta)
            Moto m1 = new Moto(Vehiculo.EMarca.BMW, "ASD012", ConsoleColor.Black);
            Moto m2 = new Moto(Vehiculo.EMarca.Honda, "ASD913", ConsoleColor.Red);
            Automovil a1 = new Automovil(Vehiculo.EMarca.Toyota, "HJK789", ConsoleColor.White);
            Automovil a2 = new Automovil(Vehiculo.EMarca.Chevrolet, "IOP852", ConsoleColor.Blue, Automovil.ETipo.Sedan);
            Camioneta c1 = new Camioneta(Vehiculo.EMarca.Ford, "QWE968", ConsoleColor.Gray);
            Camioneta c2 = new Camioneta(Vehiculo.EMarca.Renault, "TYU426", ConsoleColor.DarkBlue);
            Camioneta c3 = new Camioneta(Vehiculo.EMarca.BMW, "IOP852", ConsoleColor.Green);
            Camioneta c4 = new Camioneta(Vehiculo.EMarca.BMW, "TRE321", ConsoleColor.Green);

            // Agrego 8 ítems (los últimos 2 no deberían poder agregarse ni el a1 repetido) y muestro
            estacionamiento += m1;
            estacionamiento += m2;
            estacionamiento += a1;
            estacionamiento += a1;
            estacionamiento += a2;
            estacionamiento += c1;
            estacionamiento += c2;
            estacionamiento += c3;
            estacionamiento += c4;

            Console.WriteLine(estacionamiento.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Quito 2 items y muestro
            estacionamiento -= m1;
            estacionamiento -= new Moto(Vehiculo.EMarca.Honda, "ASD913", ConsoleColor.Red);

            Console.WriteLine(estacionamiento.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Vuelvo a agregar m2
            estacionamiento += m2;

            // Muestro solo Moto
            Console.WriteLine(estacionamiento.Mostrar(estacionamiento, Estacionamiento.ETipo.Moto));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.Beep();
            Console.Clear();

            // Muestro solo Automovil
            Console.WriteLine(estacionamiento.Mostrar(estacionamiento, Estacionamiento.ETipo.Automovil));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Camioneta
            Console.WriteLine(estacionamiento.Mostrar(estacionamiento, Estacionamiento.ETipo.Camioneta));
            Console.WriteLine("<-------------PRESIONE UNA TECLA PARA SALIR------------->");
            Console.ReadKey();
        }
    }
}
