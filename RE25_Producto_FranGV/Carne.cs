using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE25_Producto_FranGV
{

    public enum UnidadCarne : byte { Kilogramos, Bandeja }

    public class Carne : Producto
    {

        // CONSTANTES

        private const float IVA_CARNE = 1.1f;
        private const UnidadCarne UNIDAD_DEF = UnidadCarne.Kilogramos;
        private const string NOMBRE_DEFAULT = "Pollo"; 
        private const string PARTE_ANIMAL_DEFAULT = "Filetes Pechuga";
        private const byte CANTIDAD_DEFAULT = 0;


        // MIEMBROS

        private string _parteAnimal;
        private UnidadCarne _tipoUnidadCarne;
        protected float _cantidad;




        // CONSTRUCTORES

        public Carne() : base() 
        {
            _nombre = NOMBRE_DEFAULT;
            _parteAnimal = PARTE_ANIMAL_DEFAULT;
            _tipoUnidadCarne = UNIDAD_DEF;
            // _cantidad = CANTIDAD_DEFAULT Constructor base;
        }

        public Carne(string name, float price, string parteAnimal) : this()
        {
            Nombre = name;
            PrecioBase = price;
            ParteAnimal = parteAnimal;
        }

        // PROPIEDADES

        

        public string ParteAnimal
        {
            get
            {
                return _parteAnimal;
            }
            set
            {
                _parteAnimal = ValidarCadena(value);
                //_parteAnimal = value;
            }
        }

        public UnidadCarne TipoUnidadCarne
        {
            get
            {
                return _tipoUnidadCarne;
            }
           
        }

        // MÉTODOS



        protected override float precioIva()
        {
            return PrecioBase * IVA_CARNE;
        }

        public override string ToString()
        {
            string cadena = "";

            cadena = $"Nombre: {ParteAnimal}\n";
            cadena += $"Precio Base: {PrecioBase} Euros\n";
            cadena += $"Precio KG: {PrecioProducto} Euros/{TipoUnidadCarne}\n";
            cadena += $"Precio + IVA el Kg: {PrecioIVAProducto} Euros/Kg + IVA\n";
            cadena += $"Cantidad: {Cantidad} {TipoUnidadCarne}\n";
            cadena += $"Precio IVA: {PrecioIva} Euros + IVA\n";

            return cadena;
        }

        // VALIDACIÓN


    }

    // EXCEPCIONES PERSONALIZADAS

    public class TipoUnidadErrorException : Exception
    {
        public TipoUnidadErrorException() :base($"Tipo de unidad erronea") { }
        public TipoUnidadErrorException(string mensaje) : base(mensaje) { }
    }
}
