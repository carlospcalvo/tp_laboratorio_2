using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formulario
{
    public partial class FrmPpal : Form
    {
        private GroupBox groupBox1;
        private ListBox lstEstadoEnViaje;
        private ListBox lstEstadoIngresado;
        private ListBox lstEstadoEntregado;
        private Label lblEstadoEntregado;
        private Label lblEstadoEnViaje;
        private Label lblEstadoIngresado;
        private RichTextBox rtbMostrar;
        private GroupBox groupBox2;
        private Button btnMostrarTodos;
        private Button btnAgregar;
        private Label label1;
        private TextBox txtDireccion;
        private Label lblTrackingID;
        private MaskedTextBox mtxtTrackingID;
        private ContextMenuStrip cmsListas;
        private ToolStripMenuItem mostrarToolStripMenuItem;
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete aux = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            //suscribo al evento
            aux.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
            try
            {
                correo += aux;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtDireccion.Text = "";
            mtxtTrackingID.Text = "";
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                if(item.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(item);
                }
                else
                {
                    lstEstadoEntregado.Items.Add(item);
                }
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
    }
}
