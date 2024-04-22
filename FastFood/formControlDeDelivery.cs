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
    public partial class formControlDeDelivery : Form
    {
        int numPedido = 0;
        int fila;
        int fila2;

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


        public formControlDeDelivery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formSeleccionDeProceso formBack = new formSeleccionDeProceso();
            formBack.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text; string direccion = textBox2.Text; string metodoPago = ""; string referencia = textBox3.Text;

            if (Efectivo.Checked)
            {
                metodoPago = "Efectivo";
            }
            else if (Transaccion.Checked)
            {
                metodoPago = "Transacción";
            }

            if (Nombre == "" || direccion == "" || metodoPago == "")
            {

                MessageBox.Show("!!! INGRESE TODOS LOS DATOS DEL CLIENTE !!!");
            }
            else
            {
                dataGridView1.Rows.Add(numPedido, Nombre, direccion, referencia, metodoPago);
                numPedido += 1;
                button4.Enabled = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nombre.Text == "" || cantida.Text == "")
            {
                MessageBox.Show(" No ingresaste la cantidad o el nombre del plato");
            }
            else
            {
                string nombrePlato = nombre.Text;
                int cantidad = int.Parse(cantida.Text);

                plato newPlato = new plato(nombrePlato, cantidad);


                if (!pedidos.ContainsKey(numPedido))
                {
                    pedidos[numPedido] = new List<plato>();
                }

                pedidos[numPedido].Add(newPlato);

                nombre.Clear();
                cantida.Clear();

                button4.Enabled = pedidos.Any();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numPed;
            if (!int.TryParse(textBox4.Text, out numPed))
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1[1, fila].Value.ToString();
            textBox2.Text = dataGridView1[2, fila].Value.ToString();
            textBox3.Text = dataGridView1[3, fila].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila2 = dataGridView2.CurrentRow.Index;
            nombre.Text = dataGridView2[0, fila2].Value.ToString();
            cantida.Text = dataGridView2[1, fila2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1[1, fila].Value = textBox1.Text;
            dataGridView1[2, fila].Value = textBox2.Text;
            dataGridView1[3, fila].Value = textBox3.Text;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombre.Text) && int.TryParse(cantida.Text, out int cantidad))
                {
                    int numPedidoActual = int.Parse(textBox4.Text);

                    if (pedidos.ContainsKey(numPedidoActual))
                    {
                        var platoActual = pedidos[numPedidoActual][fila2];
                        platoActual.nombre = nombre.Text;
                        platoActual.cantidad = cantidad;

                        dataGridView2[0, fila2].Value = nombre.Text;
                        dataGridView2[1, fila2].Value = cantida.Text;
                        nombre.Clear();
                        cantida.Clear();
                    }
                    else
                    {
                        MessageBox.Show("El número de pedido ingresado no existe.");
                    }
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

        private void button6_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.RemoveAt(fila);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                int numPedido = int.Parse(textBox4.Text);

                pedidos[numPedido].RemoveAt(fila);

                dataGridView2.Rows.RemoveAt(fila);
                nombre.Clear();
                cantida.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el plato: " + ex.Message);
            }
        }
    }
}