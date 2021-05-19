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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'barbershopDataSet3.prices' table. You can move, or remove it, as needed.
            this.pricesTableAdapter.Fill(this.barbershopDataSet3.prices);

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

        private void AddActionButton_MouseEnter(object sender, EventArgs e)
        {
            AddActionButton.ForeColor = Color.Gray;
        }

        private void AddActionButton_MouseLeave(object sender, EventArgs e)
        {
            AddActionButton.ForeColor = Color.White;
        }
        DB db = new DB();
        MySqlCommand command;
        private void AddActionButton_Click(object sender, EventArgs e)
        {
            if (priceBox.Text == "Цена" || FavourBox.Text == "Услуга")
            {
                MessageBox.Show("Enter data");
                return;
            }
            command = new MySqlCommand("INSERT INTO `prices` (`Price`, `Name`) VALUES (@price, @favor);", db.getConnection());
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = priceBox.Text;
            command.Parameters.Add("@favor", MySqlDbType.VarChar).Value = FavourBox.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Услуга добавлена");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
            this.Refresh();
            db.closeConnection();
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

        private void FavourBox_Enter(object sender, EventArgs e)
        {
            FavourBox.Text = "";
        }

        private void priceBox_Enter(object sender, EventArgs e)
        {
            priceBox.Text = "";
        }

        private void priceBox_Leave(object sender, EventArgs e)
        {
            if (priceBox.Text == "")
                priceBox.Text = "Цена";
        }

        private void FavourBox_Leave(object sender, EventArgs e)
        {
            if (FavourBox.Text == "")
                FavourBox.Text = "Услуга";
        }

        private void UpdateButton_MouseEnter(object sender, EventArgs e)
        {
            UpdateButton.ForeColor = Color.Gray;
        }

        private void UpdateButton_MouseLeave(object sender, EventArgs e)
        {
            UpdateButton.ForeColor = Color.White;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void deteleFavorButton_MouseEnter(object sender, EventArgs e)
        {
            deteleFavorButton.ForeColor = Color.Gray;
        }

        private void deteleFavorButton_MouseLeave(object sender, EventArgs e)
        {
            deteleFavorButton.ForeColor = Color.White;
        }

        private void deteleFavorButton_Click(object sender, EventArgs e)
        {
            if ( FavourBox.Text == "Услуга")
            {
                MessageBox.Show("Enter data");
                return;
            }
            command = new MySqlCommand("DELETE FROM `prices` WHERE `prices`.`name` = @favor;", db.getConnection());
            command.Parameters.Add("@favor", MySqlDbType.VarChar).Value = FavourBox.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Услуга удалена");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
            db.closeConnection();
        }

        private void checkInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Journal j = new Journal();
            j.Show();
        }
    }
}
