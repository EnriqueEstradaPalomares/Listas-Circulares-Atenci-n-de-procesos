using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_Circulares_Atencion_de_Procesos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            CPU cpu = new CPU();
            cpu.start();
            limpiar();
            lblAtendidos.Text = cpu.retornaAtendidos();
            lblPendientes.Text = cpu.retornaPendientes();
            lblProcesos.Text = cpu.retornaTotales();
            lblCiclos.Text = cpu.retornaVacias();
            lblPend.Text = cpu.retornaTiempoPendientes();
        }

            private void limpiar()
            {
                textBox1.Clear();
                lblAtendidos.Text = "";
                lblCiclos.Text = "";
                lblPendientes.Text = "";
                lblProcesos.Text = "";
                lblPend.Text = "";
            }
    }
}
