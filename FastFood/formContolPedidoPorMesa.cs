using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFood
{
    public partial class formContolPedidoPorMesa : Form
    {
        string MesaSeleccionada = "";
        string MetodoDePago = "";
        int numPedido = 0;
        

        class plato
        {
            public string nombre;
            public int cantidad;

            public plato(string nombre, int cantidad)
            {
                this.nombre = nombre;
                this.cantidad = cantidad;
            }
        }

        Dictionary<int, List<plato>> pedidos = new Dictionary<int, List<plato>>();

        public formContolPedidoPorMesa()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formSeleccionDeProceso formBack = new formSeleccionDeProceso();
            formBack.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nombrePlato.Text == "" || cantidaPlato.Text == "")
            {
                MessageBox.Show(" No ingresaste la cantidad o el nombre del plato");
            }
            else
            {
                string nombrePlato = this.nombrePlato.Text;
                    int cantidad = int.Parse(cantidaPlato.Text);

                plato newPlato = new plato(nombrePlato, cantidad);


                if (!pedidos.ContainsKey(numPedido))
                {
                    pedidos[numPedido] = new List<plato>();
                }

                pedidos[numPedido].Add(newPlato);

                this.nombrePlato.Clear();
                cantidaPlato.Clear();

                button4.Enabled = pedidos.Any();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                MesaSeleccionada = "MESA 1";
            }
            else if (radioButton2.Checked)
            {
                MesaSeleccionada = "MESA 2";
            }
            else if (radioButton3.Checked)
            {
                MesaSeleccionada = "MESA 3";
            }
            else if (radioButton4.Checked)
            {
                MesaSeleccionada = "MESA 4";
            }
            else if (radioButton5.Checked)
            {
                MesaSeleccionada = "MESA 5";
            }
            else if (radioButton6.Checked)
            {
                MesaSeleccionada = "MESA 6";
            }

            if (Efectivo.Checked)
            {
                MetodoDePago = Efectivo.Text;
            }
            else if (Tarjeta.Checked)
            {
                MetodoDePago = Tarjeta.Text;
            }


            if (MesaSeleccionada == "" || MetodoDePago == "")
            {
                MessageBox.Show(" INGRESE LOS DATOS DEL PEDIDO (MESA Y METODO DE PAGO) ANTES DE CONTINUAR");
            }
            else
            {
                dataGridView1.Rows.Add(MesaSeleccionada, numPedido, MetodoDePago);
            }
            numPedido += 1;
            button4.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numPed;
            if (!int.TryParse(textBox3.Text, out numPed))
            {
                MessageBox.Show("Ingrese un número de pedido válido.");
                return;
            }

            dataGridView2.Rows.Clear();

            if (pedidos.ContainsKey(numPed))
            {
                foreach (var plato in pedidos[numPed])
                {
                    dataGridView2.Rows.Add(plato.nombre, plato.cantidad);
                }
            }
            else
            {
                MessageBox.Show("El número de pedido ingresado no existe.");
            }
        }
        int fila;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            fila = dataGridView2.CurrentRow.Index;
            nombrePlato.Text = dataGridView2[0,fila].Value.ToString();
            cantidaPlato.Text = dataGridView2[1,fila].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombrePlato.Text) && int.TryParse(cantidaPlato.Text, out int cantidad))
                {

                    int numPedido = int.Parse(textBox3.Text);
                    var platoActual = pedidos[numPedido][fila];
                    platoActual.nombre = nombrePlato.Text;
                    platoActual.cantidad = cantidad;

                    dataGridView2[0, fila].Value = nombrePlato.Text;
                    dataGridView2[1, fila].Value = cantidad;
                    nombrePlato.Clear();
                    cantidaPlato.Clear();
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad y un nombre de plato válidos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el plato: " + ex.Message);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                int numPedido = int.Parse(textBox3.Text);

                pedidos[numPedido].RemoveAt(fila);

                dataGridView2.Rows.RemoveAt(fila);
                nombrePlato.Clear();
                cantidaPlato.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el plato: " + ex.Message);
            }
        }
    }
}
