using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evento
{
    public partial class Form1 : Form
    {
        public delegate void CambiarSaldoEventHandler(string strCliente, string strCuenta, double dblSaldo);
        public event CambiarSaldoEventHandler CambioSaldo;

        double valor;
        public Form1()
        {
            InitializeComponent();
            this.CambioSaldo += MetodoGestor;
        }


        public void Depositar(double dblCantidad)
        {
            if(dblCantidad > 0)
            {
                valor = double.Parse(txtSaldo.Text) + dblCantidad;
                CambioSaldo(txtCliente.Text, txtCuenta.Text,valor);

            }
            else
            {
                MessageBox.Show("Cantidad Invalida");
            }
        }


        public void Retirar(double dblCantidad)
        {
            if(double.Parse(txtSaldo.Text) >= dblCantidad)
            {
                valor = double.Parse(txtSaldo.Text) - dblCantidad;
                CambioSaldo(txtCliente.Text, txtCuenta.Text, valor);

            }
            else
            {
                MessageBox.Show("Saldo Insuficiente");
            }
        }

        public void MetodoGestor(string strCliente, string strCuenta, double dblSaldo)
        {
            MessageBox.Show("Estimado(a)" + strCliente + ":\nSe le notifica que el saldo de su cuenta"
                +strCuenta + "se ha modificado\nNuevo Saldo:" + dblSaldo.ToString("C"));
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            Depositar(double.Parse(txtDeposito.Text));
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            Retirar(double.Parse(txtRetiro.Text));
        }
    }
}
