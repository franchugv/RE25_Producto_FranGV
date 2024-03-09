using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE25_Producto_FranGV
{
    public class Carne : Producto
    {

        // CONSTANTES

        private const string TIPO_UNIDAD1 = "Kg";
        private const string TIPO_UNIDAD2 = "Bandeja";

        // MIEMBROS

        private string _parteAnimal;
        private string _tipoUnidad;




        // CONSTRUCTORES

        public Carne() : base() 
        {
            _nombre = "Pollo";
            _parteAnimal = "Filetes Pechuga";
            _tipoUnidad = "Kg";
            _precioBase = -1;
            _cantidad = 0;
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
                _parteAnimal = value;
            }
        }

        public string TipoUnidad
        {
            get
            {
                return _tipoUnidad;
            }
            set
            {
                // Validarlo
                ValidarTipoUnidad(value);
                _tipoUnidad = value;
            }
        }

        // MÉTODOS



        protected override float precioIva()
        {
            return PrecioBase * 1.10f;
        }

        public override string ToString()
        {
            string cadena = "";

            cadena = $"Nombre: {ParteAnimal}\n";
            cadena += $"Precio Base: {PrecioBase} Euros\n";
            cadena += $"Precio KG: {PrecioProducto} Euros/{TipoUnidad}\n";
            cadena += $"Precio + IVA el Kg: {PrecioIVAProducto} Euros/Kg + IVA\n";
            cadena += $"Cantidad: {Cantidad} {TipoUnidad}\n";
            cadena += $"Precio IVA: {PrecioIva} Euros + IVA\n";

            return cadena;
        }

        // VALIDACIÓN

        private void ValidarTipoUnidad(string cadena)
        {
            if (cadena != TIPO_UNIDAD1 || cadena != TIPO_UNIDAD2) throw new TipoUnidadErrorException();
        }

    }

    // EXCEPCIONES PERSONALIZADAS

    public class TipoUnidadErrorException : Exception
    {
        public TipoUnidadErrorException() :base($"Tipo de unidad erronea") { }
        public TipoUnidadErrorException(string mensaje) : base(mensaje) { }
    }
}
