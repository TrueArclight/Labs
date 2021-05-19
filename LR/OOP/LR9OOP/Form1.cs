using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR9OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void close_button_MouseEnter(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.Gray;
        }

        private void close_button_MouseLeave(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.White;
        }
        Point lastPoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = loginfield.Text;
            String passUser = passfield.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if (isworker()) {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `workers` WHERE `Login` = @ul AND `Password` = @up", db.getConnection());
                command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@up", MySqlDbType.VarChar).Value = passUser;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    MainForm main = new MainForm();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Not Connected");
                }
            }
            else
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @ul AND `Password` = @up", db.getConnection());
                command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@up", MySqlDbType.VarChar).Value = passUser;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    MainFormUser main = new MainFormUser();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Not Connected");
                }
            }
        }
        private Boolean isworker()
        {
            if (isWorker.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
