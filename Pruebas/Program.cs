﻿
using RE25_Producto_FranGV;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Producto> listaProductos = new List<Producto>();


            listaProductos.Add(new Carne("Ternera", 20, "lomo"));

            listaProductos[0].Cantidad = 10;

            listaProductos.Add(new Bebida("Vino", 30, "Baena"));

            listaProductos[1].Cantidad = 10;


            Console.WriteLine($"{listaProductos[0].ToString()}\n");


            Console.WriteLine($"\n{listaProductos[1].ToString()}");

        }
    }
}
