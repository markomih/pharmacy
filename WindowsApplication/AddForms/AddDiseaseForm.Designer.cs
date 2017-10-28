namespace WindowsApplication
{
    partial class AddDiseaseForm
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
            this.buttonPonisti = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLatinskiNaziv = new System.Windows.Forms.TextBox();
            this.listBoxKontraindikacije = new System.Windows.Forms.ListBox();
            this.listBoxLekovi = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOpis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNarodniNaziv = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(313, 310);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPonisti, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLatinskiNaziv, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxKontraindikacije, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLekovi, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOpis, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNarodniNaziv, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 273);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.MaximumSize = new System.Drawing.Size(100000, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Latinski Naziv";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPonisti
            // 
            this.buttonPonisti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPonisti.Location = new System.Drawing.Point(3, 228);
            this.buttonPonisti.Name = "buttonPonisti";
            this.buttonPonisti.Size = new System.Drawing.Size(147, 42);
            this.buttonPonisti.TabIndex = 43;
            this.buttonPonisti.Text = "Ponisti";
            this.buttonPonisti.UseVisualStyleBackColor = true;
            this.buttonPonisti.Click += new System.EventHandler(this.buttonPonisti_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(156, 228);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(148, 42);
            this.buttonAdd.TabIndex = 44;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.AddNewDisease);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 45);
            this.label1.TabIndex = 46;
            this.label1.Text = "Kontraindikacije";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 45);
            this.label4.TabIndex = 47;
            this.label4.Text = "Lekovi";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxLatinskiNaziv
            // 
            this.textBoxLatinskiNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLatinskiNaziv.Location = new System.Drawing.Point(156, 3);
            this.textBoxLatinskiNaziv.Multiline = true;
            this.textBoxLatinskiNaziv.Name = "textBoxLatinskiNaziv";
            this.textBoxLatinskiNaziv.Size = new System.Drawing.Size(148, 39);
            this.textBoxLatinskiNaziv.TabIndex = 48;
            // 
            // listBoxKontraindikacije
            // 
            this.listBoxKontraindikacije.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxKontraindikacije.FormattingEnabled = true;
            this.listBoxKontraindikacije.Location = new System.Drawing.Point(156, 93);
            this.listBoxKontraindikacije.Name = "listBoxKontraindikacije";
            this.listBoxKontraindikacije.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxKontraindikacije.Size = new System.Drawing.Size(148, 39);
            this.listBoxKontraindikacije.TabIndex = 50;
            // 
            // listBoxLekovi
            // 
            this.listBoxLekovi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLekovi.FormattingEnabled = true;
            this.listBoxLekovi.Location = new System.Drawing.Point(156, 138);
            this.listBoxLekovi.Name = "listBoxLekovi";
            this.listBoxLekovi.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxLekovi.Size = new System.Drawing.Size(148, 39);
            this.listBoxLekovi.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 180);
            this.label3.MaximumSize = new System.Drawing.Size(100000, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opis";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxOpis
            // 
            this.textBoxOpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOpis.Location = new System.Drawing.Point(156, 183);
            this.textBoxOpis.Multiline = true;
            this.textBoxOpis.Name = "textBoxOpis";
            this.textBoxOpis.Size = new System.Drawing.Size(148, 39);
            this.textBoxOpis.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 45);
            this.label5.TabIndex = 52;
            this.label5.Text = "Nardni Naziv";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNarodniNaziv
            // 
            this.textBoxNarodniNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNarodniNaziv.Location = new System.Drawing.Point(156, 48);
            this.textBoxNarodniNaziv.Multiline = true;
            this.textBoxNarodniNaziv.Name = "textBoxNarodniNaziv";
            this.textBoxNarodniNaziv.Size = new System.Drawing.Size(148, 39);
            this.textBoxNarodniNaziv.TabIndex = 53;
            // 
            // labelSubject
            // 
            this.labelSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSubject.Location = new System.Drawing.Point(3, 0);
            this.labelSubject.MaximumSize = new System.Drawing.Size(100000, 0);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(307, 31);
            this.labelSubject.TabIndex = 1;
            this.labelSubject.Text = "Unesite podatke za dodavanje novou Bolest";
            this.labelSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddDiseaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 310);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AddDiseaseForm";
            this.Text = "AddDiseaseForm";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPonisti;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox textBoxLatinskiNaziv;
        private System.Windows.Forms.TextBox textBoxOpis;
        private System.Windows.Forms.ListBox listBoxKontraindikacije;
        private System.Windows.Forms.ListBox listBoxLekovi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNarodniNaziv;
    }
}