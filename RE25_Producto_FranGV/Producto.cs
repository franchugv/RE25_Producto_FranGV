﻿namespace RE25_Producto_FranGV
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

        // MÉTODOS

        public virtual string ToString()
        {
            string cadena = "";

            cadena = $"{Nombre}\n";
            cadena += $"{PrecioBase}\n";
            cadena += $"{PrecioIva()}\n";

            return cadena;


        }

        // ABSTRACTO
        protected abstract float PrecioIva();
        
        // VALIDACIÓN
        private string ValidarNombre(string cadena)
        {
            // remover espacios de antes y despues
            cadena = cadena.ToLower().Trim();

            // validación
            if (string.IsNullOrEmpty(cadena)) throw new CadenaVaciaException();

            if (!cadena.All(char.IsAsciiLetterOrDigit)) throw new TextoIncorrectoException();
            
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
        public TextoIncorrectoException() : base("Formatoo de tecto incorrecto") { }
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