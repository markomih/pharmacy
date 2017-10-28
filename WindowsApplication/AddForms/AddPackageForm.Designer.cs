namespace WindowsApplication
{
    partial class AddPackageForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPonisti = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSastav = new System.Windows.Forms.TextBox();
            this.comboBoxTip = new System.Windows.Forms.ComboBox();
            this.listBoxKontraindikacija = new System.Windows.Forms.ListBox();
            this.listBoxLekovi = new System.Windows.Forms.ListBox();
            this.numericKolicina = new System.Windows.Forms.NumericUpDown();
            this.labelSubject = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelSubject, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(100000, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonPonisti, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSastav, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTip, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxKontraindikacija, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLekovi, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericKolicina, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 229);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.MaximumSize = new System.Drawing.Size(100000, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sastav";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.MaximumSize = new System.Drawing.Size(100000, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kolicina";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPonisti
            // 
            this.buttonPonisti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPonisti.Location = new System.Drawing.Point(3, 203);
            this.buttonPonisti.Name = "buttonPonisti";
            this.buttonPonisti.Size = new System.Drawing.Size(133, 23);
            this.buttonPonisti.TabIndex = 43;
            this.buttonPonisti.Text = "Ponisti";
            this.buttonPonisti.UseVisualStyleBackColor = true;
            this.buttonPonisti.Click += new System.EventHandler(this.buttonPonisti_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(142, 203);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(133, 23);
            this.buttonAdd.TabIndex = 44;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.AddNewPakovanje);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 47;
            this.label4.Text = "Tip";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 50);
            this.label5.TabIndex = 48;
            this.label5.Text = "Kontraindikacija";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 50);
            this.label6.TabIndex = 49;
            this.label6.Text = "Lekovi";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSastav
            // 
            this.textBoxSastav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSastav.Location = new System.Drawing.Point(142, 3);
            this.textBoxSastav.Multiline = true;
            this.textBoxSastav.Name = "textBoxSastav";
            this.textBoxSastav.Size = new System.Drawing.Size(133, 19);
            this.textBoxSastav.TabIndex = 55;
            // 
            // comboBoxTip
            // 
            this.comboBoxTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTip.FormattingEnabled = true;
            this.comboBoxTip.Location = new System.Drawing.Point(142, 53);
            this.comboBoxTip.Name = "comboBoxTip";
            this.comboBoxTip.Size = new System.Drawing.Size(133, 21);
            this.comboBoxTip.TabIndex = 57;
            // 
            // listBoxKontraindikacija
            // 
            this.listBoxKontraindikacija.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxKontraindikacija.FormattingEnabled = true;
            this.listBoxKontraindikacija.Location = new System.Drawing.Point(142, 78);
            this.listBoxKontraindikacija.Name = "listBoxKontraindikacija";
            this.listBoxKontraindikacija.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxKontraindikacija.Size = new System.Drawing.Size(133, 44);
            this.listBoxKontraindikacija.TabIndex = 58;
            // 
            // listBoxLekovi
            // 
            this.listBoxLekovi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLekovi.FormattingEnabled = true;
            this.listBoxLekovi.Location = new System.Drawing.Point(142, 128);
            this.listBoxLekovi.Name = "listBoxLekovi";
            this.listBoxLekovi.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxLekovi.Size = new System.Drawing.Size(133, 44);
            this.listBoxLekovi.TabIndex = 59;
            // 
            // numericKolicina
            // 
            this.numericKolicina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericKolicina.Location = new System.Drawing.Point(142, 28);
            this.numericKolicina.Name = "numericKolicina";
            this.numericKolicina.Size = new System.Drawing.Size(133, 20);
            this.numericKolicina.TabIndex = 60;
            // 
            // labelSubject
            // 
            this.labelSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSubject.Location = new System.Drawing.Point(3, 0);
            this.labelSubject.MaximumSize = new System.Drawing.Size(100000, 0);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(278, 26);
            this.labelSubject.TabIndex = 1;
            this.labelSubject.Text = "Unesite podatke za dodavanje Pakovanja";
            this.labelSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddPackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AddPackageForm";
            this.Text = "AddPackageForm";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericKolicina)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPonisti;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSastav;
        private System.Windows.Forms.ComboBox comboBoxTip;
        private System.Windows.Forms.ListBox listBoxKontraindikacija;
        private System.Windows.Forms.ListBox listBoxLekovi;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.NumericUpDown numericKolicina;
    }
}