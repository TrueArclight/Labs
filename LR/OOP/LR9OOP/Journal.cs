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
    public partial class Journal : Form
    {
        public Journal()
        {
            InitializeComponent();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'barbershopDataSet.journal' table. You can move, or remove it, as needed.
            this.journalTableAdapter.Fill(this.barbershopDataSet.journal);

        }

        private void changeUser_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void close_button_MouseEnter(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.Gray;
        }

        private void close_button_MouseLeave(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.White;
        }

        private void changeUser_button_MouseEnter(object sender, EventArgs e)
        {
            changeUser_button.ForeColor = Color.Gray;
        }

        private void changeUser_button_MouseLeave(object sender, EventArgs e)
        {
            changeUser_button.ForeColor = Color.White;
        }
        Point lastPoint;

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void UpdateButton_MouseEnter(object sender, EventArgs e)
        {
            UpdateButton.ForeColor = Color.Gray;
        }

        private void UpdateButton_MouseLeave(object sender, EventArgs e)
        {
            UpdateButton.ForeColor = Color.White;
        }

        private void DelButton_MouseEnter(object sender, EventArgs e)
        {
            DelButton.ForeColor = Color.Gray;
        }

        private void DelButton_MouseLeave(object sender, EventArgs e)
        {
            DelButton.ForeColor = Color.White;
        }

        private void AddButton_MouseEnter(object sender, EventArgs e)
        {
            AddButton.ForeColor = Color.Gray;
        }

        private void AddButton_MouseLeave(object sender, EventArgs e)
        {
            AddButton.ForeColor = Color.White;
        }
        DB db = new DB();
        MySqlCommand command;
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "Инициалы" || NumberBox.Text == "Количество" || FavNameBox.Text == "Услуга" || PriceBox.Text == "Ценность")
            {
                MessageBox.Show("Enter data");
                return;
            }
            command = new MySqlCommand("INSERT INTO `journal` (`Name`, `FavorName`, `NumFavors`, `Price`) VALUES (@name, @favname, @numbers, @price);", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameBox.Text;
            command.Parameters.Add("@favname", MySqlDbType.VarChar).Value = FavNameBox.Text;
            command.Parameters.Add("@numbers", MySqlDbType.Int32).Value = NumberBox.Text;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = PriceBox.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись добавлена");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
            db.closeConnection();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Journal j = new Journal();
            j.Show();
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            NameBox.Text = "";
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
                NameBox.Text = "Инициалы";
        }

        private void FavNameBox_Enter(object sender, EventArgs e)
        {
            FavNameBox.Text = "";
        }

        private void FavNameBox_Leave(object sender, EventArgs e)
        {
            if (FavNameBox.Text == "")
                FavNameBox.Text = "Услуга";
        }

        private void NumberBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Text = "";
        }

        private void NumberBox_Leave(object sender, EventArgs e)
        {
            if (NumberBox.Text == "")
                NumberBox.Text = "Количество";
        }

        private void PriceBox_Enter(object sender, EventArgs e)
        {
            PriceBox.Text = "";
        }

        private void PriceBox_Leave(object sender, EventArgs e)
        {
            if (PriceBox.Text == "")
                PriceBox.Text = "Ценность";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "Инициалы")
            {
                MessageBox.Show("Enter data");
                return;
            }
            command = new MySqlCommand("DELETE FROM `journal` WHERE `journal`.`name` = @name;", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameBox.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись удалена");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
            db.closeConnection();
        }
    }
}

