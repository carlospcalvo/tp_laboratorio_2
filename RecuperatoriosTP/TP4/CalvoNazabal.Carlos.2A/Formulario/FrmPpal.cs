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

        /// <summary>
        /// Inicializa el formulario
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        /// <summary>
        /// Agrega un paquete con los datos proporcionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete aux = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            //suscribo a los eventos
            aux.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
            aux.InformaExcepcion += new Paquete.DelegadoExcepcion(Paq_Excepcion);

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

        /// <summary>
        /// Actualiza el formulario al cambiar de estado algún paquete
        /// </summary>
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

        /// <summary>
        /// Muestra todos los paquetes en la sección izquierda inferior del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra el paquete seleccionado en la sección izquierda inferior del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Llama al método que actualiza el estado de los paquetes al lanzarse el evento correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Antes de cerrarse el formulario, cierra los hilos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /*
         * Agregué un evento para que muestre un mensaje en caso de haber un error con la base de datos,
         * el mismo evento (así como los delegados y métodos) no está detallado en los diagramas del TP, 
         * pero una de las consignas pide lo siguiente:
         *      "(PaqueteDAO - A) [...] A través de un MessageBox informar lo ocurrido al usuario de forma 
         *      clara. De ser necesario, utilizar un evento para este fin."
         */
         /// <summary>
         /// Al lanzarse el evento de excepción en la inserción a la base de datos, se muestra un mensaje informando el error.
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void Paq_Excepcion(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoExcepcion d = new Paquete.DelegadoExcepcion(Paq_Excepcion);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                MessageBox.Show("Error al agregar el paquete a la base de datos");
            }
        }

        /// <summary>
        /// Muestra un paquete o una lista de paquetes y los guarda en un archivo de texto en el escritorio 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                rtbMostrar.Text.Guardar("salida.txt");
            }
        }
    }
}
