using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebArbol
{
    public partial class MyFormulario : System.Web.UI.Page
    {
        Nodo objetoNodo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///lo primero que se ejecuta
            objetoNodo = new Nodo();
            String resp = objetoNodo.toString();
            Response.Write(resp);
        }

    }
}