using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE25_Producto_FranGV
{

    public enum TipoUnidad : byte {Botella, Caja3, Caja6, Caja12}

    public class Bebida : Producto
    {


        // CONSTANTES
        private const float IVA_BEBIDA = 1.21f;
        private const string NOMBRE_DEFAULT = "Fino Baena";
        private const string DENOMINACION_ORIGEN_DEFAULT = "Montilla Moriles";


        // MIEMBROS

        private string _denominacionOrigen;
        private TipoUnidad _tipoUnidad;

        // CONSTRUCTORES

        public Bebida() : base()
        {
            _nombre = NOMBRE_DEFAULT;
            _denominacionOrigen = DENOMINACION_ORIGEN_DEFAULT;
            _tipoUnidad = TipoUnidad.Botella;
            // _precioBase = -1; Constructor base
            // _cantidad = 0; Constructor base
        }

        public Bebida(string name, float price, string denominacion) : this()
        {
            Nombre = name;
            PrecioBase = price;
            DenominacionOrigen = denominacion;
        }

        // PROPIEDADES

        public override float Cantidad
        {
            
            get
            {
                return _cantidad;
            }
            set
            {
                base.Cantidad = value;     
                _cantidad = QuitarDecimales(value);
            }

        }


        public string DenominacionOrigen
        {
            get
            {
                return _denominacionOrigen;
            }
            set
            {
                _denominacionOrigen = ValidarCadena(value);
                //_denominacionOrigen = value;
               
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
            return PrecioBase * IVA_BEBIDA;
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

        private float QuitarDecimales(float num)
        {
            // Quita decimales
            num = (float)Math.Floor(num);

            return num;
        }
    }
}



