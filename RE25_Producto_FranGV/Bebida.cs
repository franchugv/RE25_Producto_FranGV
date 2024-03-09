using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE25_Producto_FranGV
{

    public enum TipoUnidad :byte {Botella, Caja3, Caja6, Caja12}

    public class Bebida : Producto
    {


        // CONSTANTES

        private const string NOMBRE_DEFAULT = "Fino Baena";
        private const string DENOMINACION_ORIGEN_DEFAULT = "Montilla Moriles";


        // MIEMBROS

        private string _denominacionOrigen;
        private TipoUnidad _tipoUnidad;

        // CONSTRUCTORES

        public Bebida() : base()
        {
            _nombre = NOMBRE_DEFAULT;
            DenominacionOrigen = DENOMINACION_ORIGEN_DEFAULT;
            _tipoUnidad = TipoUnidad.Botella;
            _precioBase = -1;
            _cantidad = 0;
        }

        public Bebida(string name, float price, string denominacion) : this()
        {
            Nombre = name;
            PrecioBase = price;
            DenominacionOrigen = denominacion;
        }

        // PROPIEDADES

        public string DenominacionOrigen
        {
            get
            {
                return _denominacionOrigen;
            }
            set
            {
                _denominacionOrigen = value;
               
            }
        }

        public TipoUnidad TipoUnidad
        {
            get 
            { 
                return _tipoUnidad;
            }
        }


        // MÉTODOS

        protected override float precioIva()
        {
            return PrecioBase * 1.21f;
        }

        public override string ToString()
        {
            string cadena = "";

            cadena = $"Nombre: {Nombre}({DenominacionOrigen})\n";
            cadena += $"Precio Base: {PrecioBase} Euros\n";
            cadena += $"Precio Botella: {PrecioProducto} Euros/{TipoUnidad}\n";
            cadena += $"Precio + IVA la botella: {PrecioIVAProducto} Euros/Botella + IVA\n";
            cadena += $"Cantidad: {Cantidad} {TipoUnidad}\n";
            cadena += $"Precio IVA: {PrecioIva} Euros + IVA\n";

            return cadena;
        }
    }
}



