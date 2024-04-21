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
    public partial class formLogin : Form
    {
        string[] users = { "JeremyVill", "AngelAban", "SebastianVal" };
        string[] passwords = { "111", "222", "333" };
        int[] attemps = { 0, 0, 0 };
        bool[] blockeds = { false, false, false };
        public formLogin()
        {
            InitializeComponent();
            for (int i = 0; i < users.Length; i++)
            {
                dataGridView1.Rows.Add(users[i], passwords[i]);
            }
        }
        private void blockAccounts(int index)
        {
            if (attemps[index] >= 3)
            {
                blockeds[index] = true;
                MessageBox.Show("!!! Tu cuenta fue bloqueada !!!");
            }
        }
        private void btn_log_in_Click(object sender, EventArgs e)
        {
            string user = usernameBox.Text;
            string password = passwordBox.Text;

            int i = Array.IndexOf(users, user);

            if (i != -1)
            {
                if (!blockeds[i])
                {
                    if (password == passwords[i])
                    {
                        usernameBox.Clear();
                        passwordBox.Clear();
                        this.Hide();
                        formSeleccionDeProceso formProceso = new formSeleccionDeProceso();
                        formProceso.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(" !! Contraseña incorrecta !! ");
                        passwordBox.Clear();
                        passwordBox.Focus();
                        attemps[i]++;
                        blockAccounts(i);
                    }
                }
                else
                {
                    MessageBox.Show("! Tu cuenta fue bloqueada por seguridad !");
                    usernameBox.Clear();
                    passwordBox.Clear();
                    usernameBox.Focus();
                }
            }
            else
            {
                MessageBox.Show(" ! El usuario no existe ! ");
                usernameBox.Clear();
                passwordBox.Focus();
            }
        }
    }
    }
