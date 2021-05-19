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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            NameField.Text = "Введите имя";
            SurnameField.Text = "Введите фамилию";
            Rank.Text = "Введите должность";
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

        private void registration_label_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void registration_label_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void NameField_Enter(object sender, EventArgs e)
        {
            if (NameField.Text == "Введите имя")
            {
                NameField.Text = "";
            }
        }

        private void SurnameField_Enter(object sender, EventArgs e)
        {
            SurnameField.Text = "";
        }

        private void NameField_Leave(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                NameField.Text = "Введите имя";
            }
        }

        private void SurnameField_Leave(object sender, EventArgs e)
        {
            if (SurnameField.Text == "")
            {
                SurnameField.Text = "Введите фамилию";
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (NameField.Text == "Введите имя" || SurnameField.Text == "Введите фамилию" || LoginField.Text == "" || PassField.Text == "")
            {
                MessageBox.Show("Enter data");
                return;
            }
            if (isUserExists()) 
                return;
            DB db = new DB();
            MySqlCommand command;
            if (isUserWorker())
            {
                command = new MySqlCommand("INSERT INTO `workers` (`login`, `password`, `name`, `surname`, `rank`) VALUES (@login, @password, @name, @surname, @rank);", db.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginField.Text;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PassField.Text;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;
                command.Parameters.Add("@rank", MySqlDbType.VarChar).Value = Rank.Text;
            }
            else
            {
                command = new MySqlCommand("INSERT INTO `users` (`Login`, `Password`, `Name`, `Surname`) VALUES (@login, @password, @name, @surname);", db.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginField.Text;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PassField.Text;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;
            }
            db.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Registration completed");
            }
            else
            {
                MessageBox.Show("Registration failed");
            }
            db.closeConnection();
        }
        public Boolean isUserExists()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @login", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("This user already exist");
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean isUserWorker()
        {
            if (Rank.Text != "Введите должность")
            {
                return true;
            }
            else
                return false;
        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 LogIn = new Form1();
            LogIn.Show();
        }

        private void Rank_Enter(object sender, EventArgs e)
        {
            Rank.Text = "";
        }

        private void Rank_Leave(object sender, EventArgs e)
        {
            if (Rank.Text == "")
            {
                Rank.Text = "Введите должность";
            }
        }
    }
}
