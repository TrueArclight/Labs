
namespace LR9OOP
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRegister = new System.Windows.Forms.Button();
            this.PassField = new System.Windows.Forms.TextBox();
            this.LoginField = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.close_button = new System.Windows.Forms.Label();
            this.registration_label = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.TextBox();
            this.SurnameField = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Rank = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.Black;
            this.buttonRegister.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Comic Sans MS", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRegister.Location = new System.Drawing.Point(0, 473);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(407, 94);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = " Зарегистрироваться";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // PassField
            // 
            this.PassField.Font = new System.Drawing.Font("Comic Sans MS", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassField.Location = new System.Drawing.Point(85, 400);
            this.PassField.Name = "PassField";
            this.PassField.PasswordChar = '*';
            this.PassField.Size = new System.Drawing.Size(711, 67);
            this.PassField.TabIndex = 9;
            this.PassField.UseSystemPasswordChar = true;
            // 
            // LoginField
            // 
            this.LoginField.Font = new System.Drawing.Font("Comic Sans MS", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginField.Location = new System.Drawing.Point(85, 327);
            this.LoginField.Name = "LoginField";
            this.LoginField.Size = new System.Drawing.Size(711, 67);
            this.LoginField.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.close_button);
            this.panel1.Controls.Add(this.registration_label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 100);
            this.panel1.TabIndex = 11;
            // 
            // close_button
            // 
            this.close_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_button.AutoSize = true;
            this.close_button.BackColor = System.Drawing.Color.Black;
            this.close_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close_button.ForeColor = System.Drawing.Color.White;
            this.close_button.Location = new System.Drawing.Point(779, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(30, 29);
            this.close_button.TabIndex = 2;
            this.close_button.Text = "X";
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            this.close_button.MouseEnter += new System.EventHandler(this.close_button_MouseEnter);
            this.close_button.MouseLeave += new System.EventHandler(this.close_button_MouseLeave);
            // 
            // registration_label
            // 
            this.registration_label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.registration_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registration_label.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registration_label.ForeColor = System.Drawing.SystemColors.Control;
            this.registration_label.Location = new System.Drawing.Point(0, 0);
            this.registration_label.Name = "registration_label";
            this.registration_label.Size = new System.Drawing.Size(809, 100);
            this.registration_label.TabIndex = 0;
            this.registration_label.Text = "Регистрация";
            this.registration_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.registration_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.registration_label_MouseDown);
            this.registration_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.registration_label_MouseMove);
            // 
            // NameField
            // 
            this.NameField.Font = new System.Drawing.Font("Comic Sans MS", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameField.Location = new System.Drawing.Point(86, 108);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(711, 67);
            this.NameField.TabIndex = 12;
            this.NameField.Enter += new System.EventHandler(this.NameField_Enter);
            this.NameField.Leave += new System.EventHandler(this.NameField_Leave);
            // 
            // SurnameField
            // 
            this.SurnameField.Font = new System.Drawing.Font("Comic Sans MS", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameField.Location = new System.Drawing.Point(86, 181);
            this.SurnameField.Name = "SurnameField";
            this.SurnameField.Size = new System.Drawing.Size(711, 67);
            this.SurnameField.TabIndex = 13;
            this.SurnameField.Enter += new System.EventHandler(this.SurnameField_Enter);
            this.SurnameField.Leave += new System.EventHandler(this.SurnameField_Leave);
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.Black;
            this.EnterButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EnterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.EnterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterButton.Font = new System.Drawing.Font("Comic Sans MS", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EnterButton.Location = new System.Drawing.Point(402, 473);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(407, 94);
            this.EnterButton.TabIndex = 15;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::LR9OOP.Properties.Resources.name;
            this.pictureBox3.Location = new System.Drawing.Point(10, 108);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(66, 67);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LR9OOP.Properties.Resources.userpick;
            this.pictureBox2.Location = new System.Drawing.Point(9, 327);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LR9OOP.Properties.Resources._lock;
            this.pictureBox1.Location = new System.Drawing.Point(9, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Rank
            // 
            this.Rank.Font = new System.Drawing.Font("Comic Sans MS", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rank.Location = new System.Drawing.Point(85, 254);
            this.Rank.Name = "Rank";
            this.Rank.Size = new System.Drawing.Size(711, 67);
            this.Rank.TabIndex = 16;
            this.Rank.Enter += new System.EventHandler(this.Rank_Enter);
            this.Rank.Leave += new System.EventHandler(this.Rank_Leave);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 564);
            this.Controls.Add(this.Rank);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.SurnameField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.PassField);
            this.Controls.Add(this.LoginField);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.TextBox LoginField;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label registration_label;
        private System.Windows.Forms.Label close_button;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.TextBox SurnameField;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.TextBox Rank;
    }
}