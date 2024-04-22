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
    public partial class formControlDeReservaciones : Form
    {
        int numRes =0;
        int fila;
        public formControlDeReservaciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formSeleccionDeProceso formBack = new formSeleccionDeProceso();
            formBack.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dataGridView1.CurrentRow.Index;
            textBox2.Text = dataGridView1[1, fila].Value.ToString();
            textBox1.Text = dataGridView1[2, fila].Value.ToString();
            textBox3.Text = dataGridView1[3, fila].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fecha = dateTimePicker1.Value.ToString(); string nombre = textBox1.Text; string dni = textBox2.Text; string tel = textBox3.Text;
            string tipoMesa = "";

            if (radioButton1.Checked)
            {
                tipoMesa = "Mesa para 1";
            }
            else if (radioButton2.Checked)
            {
                tipoMesa = "Mesa para 2";
            }
            else if (radioButton3.Checked)
            {
                tipoMesa = "Mesa para 3";
            }
            else if (radioButton4.Checked)
            {
                tipoMesa = "Mesa para 4";
            }

            if(nombre == "" || dni == "" || tel == "" || tipoMesa == "")
            {
                MessageBox.Show(" INGRESE DATOS EN TODOS LOS CAMPOS ANTES DE CONTINUAR ");
            }
            else
            {
                dataGridView1.Rows.Add(numRes, dni, nombre, tel, fecha, tipoMesa);
                numRes++;
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(fila);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1[1, fila].Value = textBox2.Text;
            dataGridView1[2, fila].Value = textBox1.Text;
            dataGridView1[3, fila].Value = textBox3.Text;
        }
    }
}

