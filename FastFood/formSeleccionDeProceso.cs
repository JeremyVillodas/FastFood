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
    public partial class formSeleccionDeProceso : Form
    {
        public formSeleccionDeProceso()
        {
            InitializeComponent();
        }

        private void formSeleccionDeProceso_Load(object sender, EventArgs e)
        {

        }

        private void btn_sign_off_Click(object sender, EventArgs e)
        {
            this.Hide();
            formLogin formLogin = new formLogin();
            formLogin.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formContolPedidoPorMesa formNext = new formContolPedidoPorMesa();
            formNext.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            formControlDeDelivery formNext = new formControlDeDelivery();
            formNext.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            formControlDeReservaciones formNext = new formControlDeReservaciones();
            formNext.ShowDialog();
        }
    }
}
