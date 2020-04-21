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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        #region  Atributos

        public Numero auxiliar = new Numero();
        public double resultado;

        #endregion


        #region Constructor

        public FormCalculadora()
        {
            InitializeComponent();
        }

        #endregion


        #region Eventos de Botones

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            this.lblResultado.Text = Convert.ToString(resultado);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            resultado = -1;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            string strResultado = resultado.ToString();
            this.lblResultado.Text = auxiliar.DecimalBinario(strResultado);
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            bool isBinary = false;
            string strResultado = resultado.ToString();

            foreach (char c in strResultado)
            {
                if (c == '0' || c == '1')
                {
                    isBinary = true;
                }
                else
                {
                    isBinary = false;
                    break;
                }
            }
            if (isBinary == true)
            {
                strResultado = auxiliar.DecimalBinario(strResultado);
                this.lblResultado.Text = auxiliar.BinarioDecimal(strResultado);
            }
            else
            {
                MessageBox.Show("El resultado no es binario.");
            }
        }

        #endregion


        #region Metodos

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedItem = "+";
            this.lblResultado.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double rta;
            Numero aux1 = new Numero(numero1);
            Numero aux2 = new Numero(numero2);

            rta = Calculadora.Operar(aux1, aux2, operador);

            return rta;
        }

        #endregion

    }
}
