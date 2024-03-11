namespace RE25_Producto_FranGV
{
    public abstract class Producto
    {

        // CONSTANTES

        private const string NOMBRE_DAFAULT = "ne";
        private const float PRECIO_DEFAULT = -1;

        // MIEMBROS

        protected string _nombre;
        protected float _precioBase;
        protected int _cantidad;

        // CONSTRUCTORES

        public Producto()
        {
            _nombre = NOMBRE_DAFAULT;
            _precioBase = PRECIO_DEFAULT;
        }

        public Producto(string name, float product)
        {
            Nombre = name;
            PrecioBase = product;
        }

        // PROPIEDADES

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                // Pasar a minuscula
                // Validación
                value = ValidarNombre(value);
                _nombre = value;
            }
        }

        public float PrecioBase
        {
            get
            {
                return _precioBase;
            }
            set
            {
                ValidarPrecio(value);
                _precioBase = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                _cantidad = value;
            }
        }

        // precios

        public float PrecioProducto
        {
            get
            {
                return (float)Math.Round(precioProducto(), 2);
            }
        }

        public float PrecioIva
        {
            get
            {
                // solo lectura
                return (float)Math.Round(precioIva(), 2);
            }
        }

        public float PrecioIVAProducto
        {
            get
            {
                return (float)Math.Round(precioIVAProducto(), 2);
            }
        }



        // MÉTODOS

        public virtual string ToString()
        {
            string cadena = "";

            cadena = $"{Nombre}\n";
            cadena += $"{PrecioBase}\n";
            cadena += $"{PrecioIva}\n";

            return cadena;
        }


        // PRECIOS

        private float precioIVAProducto()
        {
            return PrecioIva / Cantidad;
        }

        private float precioProducto()
        {
            return PrecioBase / Cantidad;
        }


        // ABSTRACTO
        protected abstract float precioIva();
        

        // VALIDACIÓN
        protected static string ValidarNombre(string cadena)
        {
            // remover espacios de antes y despues
            cadena = cadena.ToLower().Trim();

            // validación
            if (string.IsNullOrEmpty(cadena)) throw new CadenaVaciaException();


            foreach (char caracter in cadena)
            {
                if (!(char.IsLetterOrDigit(caracter) || char.IsWhiteSpace(caracter)))
                    throw new TextoIncorrectoException();
            }

            return cadena;
        }

        protected static string ValidarCadena(string cadena)
        {
            cadena = cadena.Trim().ToLower();

            if (string.IsNullOrEmpty(cadena)) throw new CadenaVaciaException();

            //if (!cadena.All(char.IsAsciiLetter) || cadena.All(char.IsWhiteSpace)) 
              //  throw new TextoIncorrectoException();

            foreach (char caracter in cadena)
            {
                if (!(char.IsLetter(caracter) || char.IsWhiteSpace(caracter)))
                    throw new TextoIncorrectoException();
            }

            return cadena;
        }

        private void ValidarPrecio(float num)
        {
            // CONSTANTES
            const float PRECIO_MIN = 0;

            if (num < PRECIO_MIN) throw new ValorMenorException();
        }

    }

    // Excepciones personalizadas

    public class TextoIncorrectoException : Exception
    {
        public TextoIncorrectoException() : base("Formato de texto incorrecto") { }
        public TextoIncorrectoException(string mensaje) : base(mensaje) { }
    }

    public class ValorMenorException : Exception
    {
        public ValorMenorException() : base("El valor es menor al rango establecido")
        { }
        public ValorMenorException(string mensaje) : base(mensaje) { }
    }

    public class CadenaVaciaException : Exception
    {
        public CadenaVaciaException() : base("Error: cadena vacía") { }
        public CadenaVaciaException(string mensaje) : base(mensaje) { }
    }
}
