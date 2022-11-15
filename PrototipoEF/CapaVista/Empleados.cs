using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            NavegadorVista.Navegador.idApp = "3002";
            TextBox[] Grupotextbox = {};
            TextBox[] Idtextbox = {};
            navegador1.textbox = Grupotextbox;
            navegador1.tabla = DgvEmpleados;
            navegador1.textboxi = Idtextbox;
            navegador1.actual = this;
            navegador1.cargar(DgvEmpleados, Grupotextbox, "PrototipoEF");
        }
    }
}
