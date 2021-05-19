
namespace LR9OOP
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.close_button = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barbershopDataSet3 = new LR9OOP.barbershopDataSet3();
            this.panel2 = new System.Windows.Forms.Panel();
            this.changeUser_button = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkInfo = new System.Windows.Forms.Button();
            this.pricesTableAdapter = new LR9OOP.barbershopDataSet3TableAdapters.pricesTableAdapter();
            this.UpdateButton = new System.Windows.Forms.Label();
            this.AddActionButton = new System.Windows.Forms.Label();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.FavourBox = new System.Windows.Forms.TextBox();
            this.deteleFavorButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barbershopDataSet3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_button.AutoSize = true;
            this.close_button.BackColor = System.Drawing.Color.Black;
            this.close_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close_button.ForeColor = System.Drawing.Color.White;
            this.close_button.Location = new System.Drawing.Point(765, 9);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(30, 29);
            this.close_button.TabIndex = 3;
            this.close_button.Text = "X";
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            this.close_button.MouseEnter += new System.EventHandler(this.close_button_MouseEnter);
            this.close_button.MouseLeave += new System.EventHandler(this.close_button_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 304);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.priceDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pricesBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(783, 304);
            this.dataGridView1.TabIndex = 0;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pricesBindingSource
            // 
            this.pricesBindingSource.DataMember = "prices";
            this.pricesBindingSource.DataSource = this.barbershopDataSet3;
            // 
            // barbershopDataSet3
            // 
            this.barbershopDataSet3.DataSetName = "barbershopDataSet3";
            this.barbershopDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.changeUser_button);
            this.panel2.Controls.Add(this.close_button);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(807, 100);
            this.panel2.TabIndex = 5;
            // 
            // changeUser_button
            // 
            this.changeUser_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeUser_button.AutoSize = true;
            this.changeUser_button.BackColor = System.Drawing.Color.Black;
            this.changeUser_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeUser_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeUser_button.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeUser_button.ForeColor = System.Drawing.Color.White;
            this.changeUser_button.Location = new System.Drawing.Point(656, 81);
            this.changeUser_button.Name = "changeUser_button";
            this.changeUser_button.Size = new System.Drawing.Size(151, 19);
            this.changeUser_button.TabIndex = 12;
            this.changeUser_button.Text = "Сменить пользователя";
            this.changeUser_button.Click += new System.EventHandler(this.changeUser_button_Click);
            this.changeUser_button.MouseEnter += new System.EventHandler(this.changeUser_button_MouseEnter);
            this.changeUser_button.MouseLeave += new System.EventHandler(this.changeUser_button_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(807, 100);
            this.label1.TabIndex = 4;
            this.label1.Text = "Главная информация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 450);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(807, 100);
            this.panel4.TabIndex = 7;
            // 
            // checkInfo
            // 
            this.checkInfo.BackColor = System.Drawing.Color.Black;
            this.checkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.checkInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.checkInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkInfo.Font = new System.Drawing.Font("Comic Sans MS", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkInfo.Location = new System.Drawing.Point(0, 0);
            this.checkInfo.Name = "checkInfo";
            this.checkInfo.Size = new System.Drawing.Size(807, 100);
            this.checkInfo.TabIndex = 11;
            this.checkInfo.Text = "Посмотреть журнал";
            this.checkInfo.UseVisualStyleBackColor = false;
            this.checkInfo.Click += new System.EventHandler(this.checkInfo_Click);
            // 
            // pricesTableAdapter
            // 
            this.pricesTableAdapter.ClearBeforeFill = true;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.AutoSize = true;
            this.UpdateButton.BackColor = System.Drawing.Color.Black;
            this.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(5, 428);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(68, 19);
            this.UpdateButton.TabIndex = 13;
            this.UpdateButton.Text = "Обновить";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            this.UpdateButton.MouseEnter += new System.EventHandler(this.UpdateButton_MouseEnter);
            this.UpdateButton.MouseLeave += new System.EventHandler(this.UpdateButton_MouseLeave);
            // 
            // AddActionButton
            // 
            this.AddActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddActionButton.AutoSize = true;
            this.AddActionButton.BackColor = System.Drawing.Color.Black;
            this.AddActionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddActionButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddActionButton.ForeColor = System.Drawing.Color.White;
            this.AddActionButton.Location = new System.Drawing.Point(79, 428);
            this.AddActionButton.Name = "AddActionButton";
            this.AddActionButton.Size = new System.Drawing.Size(114, 19);
            this.AddActionButton.TabIndex = 14;
            this.AddActionButton.Text = "Добавить услугу";
            this.AddActionButton.Click += new System.EventHandler(this.AddActionButton_Click);
            this.AddActionButton.MouseEnter += new System.EventHandler(this.AddActionButton_MouseEnter);
            this.AddActionButton.MouseLeave += new System.EventHandler(this.AddActionButton_MouseLeave);
            // 
            // priceBox
            // 
            this.priceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priceBox.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceBox.Location = new System.Drawing.Point(588, 418);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(100, 26);
            this.priceBox.TabIndex = 15;
            this.priceBox.Text = "Цена";
            this.priceBox.Enter += new System.EventHandler(this.priceBox_Enter);
            this.priceBox.Leave += new System.EventHandler(this.priceBox_Leave);
            // 
            // FavourBox
            // 
            this.FavourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FavourBox.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FavourBox.Location = new System.Drawing.Point(694, 418);
            this.FavourBox.Name = "FavourBox";
            this.FavourBox.Size = new System.Drawing.Size(100, 26);
            this.FavourBox.TabIndex = 16;
            this.FavourBox.Text = "Услуга";
            this.FavourBox.Enter += new System.EventHandler(this.FavourBox_Enter);
            this.FavourBox.Leave += new System.EventHandler(this.FavourBox_Leave);
            // 
            // deteleFavorButton
            // 
            this.deteleFavorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deteleFavorButton.AutoSize = true;
            this.deteleFavorButton.BackColor = System.Drawing.Color.Black;
            this.deteleFavorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deteleFavorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deteleFavorButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deteleFavorButton.ForeColor = System.Drawing.Color.White;
            this.deteleFavorButton.Location = new System.Drawing.Point(199, 428);
            this.deteleFavorButton.Name = "deteleFavorButton";
            this.deteleFavorButton.Size = new System.Drawing.Size(106, 19);
            this.deteleFavorButton.TabIndex = 17;
            this.deteleFavorButton.Text = "Удалить услугу";
            this.deteleFavorButton.Click += new System.EventHandler(this.deteleFavorButton_Click);
            this.deteleFavorButton.MouseEnter += new System.EventHandler(this.deteleFavorButton_MouseEnter);
            this.deteleFavorButton.MouseLeave += new System.EventHandler(this.deteleFavorButton_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 550);
            this.Controls.Add(this.deteleFavorButton);
            this.Controls.Add(this.FavourBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.AddActionButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barbershopDataSet3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label close_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button checkInfo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private barbershopDataSet3 barbershopDataSet3;
        private System.Windows.Forms.BindingSource pricesBindingSource;
        private barbershopDataSet3TableAdapters.pricesTableAdapter pricesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label changeUser_button;
        private System.Windows.Forms.Label UpdateButton;
        private System.Windows.Forms.Label AddActionButton;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.TextBox FavourBox;
        private System.Windows.Forms.Label deteleFavorButton;
    }
}