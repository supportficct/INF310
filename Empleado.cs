using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otra
{
    class Empleado
    {
        #region Atributos
        public String Nombre;
        public int Edad;
        public int Salario;
        public string Sexo;      
        #endregion
        public String nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public int edad
        {
            get { return Edad; }
            set { Edad = value; }
        }

        public int salario
        {
            get { return Salario; }
            set { Salario = value; }
        }

        public String sexo
        {
            get { return Sexo; }
            set { Sexo = value; }
        }

        #region Métodos
        public Empleado()
        {
            nombre = "";
            edad = 0;
            salario = 0;
            sexo = "";
        }
        #endregion
    }
}
