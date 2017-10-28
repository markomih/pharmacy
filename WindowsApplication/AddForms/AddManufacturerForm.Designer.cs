namespace WindowsApplication
{
    partial class AddManufacturerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNaziv = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listBoxLekovi = new System.Windows.Forms.ListBox();
            this.buttonPonisti = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(292, 302);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNaziv, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLekovi, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonPonisti, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(286, 266);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 37);
            this.label1.TabIndex = 35;
            this.label1.Text = "Naziv";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNaziv
            // 
            this.textBoxNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNaziv.Location = new System.Drawing.Point(146, 3);
            this.textBoxNaziv.Multiline = true;
            this.textBoxNaziv.Name = "textBoxNaziv";
            this.textBoxNaziv.Size = new System.Drawing.Size(137, 31);
            this.textBoxNaziv.TabIndex = 36;
            this.textBoxNaziv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 37);
            this.label12.MaximumSize = new System.Drawing.Size(100000, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 151);
            this.label12.TabIndex = 11;
            this.label12.Text = "Lekovi";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxLekovi
            // 
            this.listBoxLekovi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLekovi.FormattingEnabled = true;
            this.listBoxLekovi.Location = new System.Drawing.Point(146, 40);
            this.listBoxLekovi.Name = "listBoxLekovi";
            this.listBoxLekovi.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxLekovi.Size = new System.Drawing.Size(137, 145);
            this.listBoxLekovi.TabIndex = 40;
            // 
            // buttonPonisti
            // 
            this.buttonPonisti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPonisti.Location = new System.Drawing.Point(3, 228);
            this.buttonPonisti.MaximumSize = new System.Drawing.Size(100000, 0);
            this.buttonPonisti.Name = "buttonPonisti";
            this.buttonPonisti.Size = new System.Drawing.Size(137, 35);
            this.buttonPonisti.TabIndex = 31;
            this.buttonPonisti.Text = "Ponisti";
            this.buttonPonisti.UseVisualStyleBackColor = true;
            this.buttonPonisti.Click += new System.EventHandler(this.buttonPonisti_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(146, 228);
            this.buttonAdd.MaximumSize = new System.Drawing.Size(100000, 0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(137, 35);
            this.buttonAdd.TabIndex = 29;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.AddNewManufacturer);
            // 
            // labelSubject
            // 
            this.labelSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubject.Location = new System.Drawing.Point(3, 0);
            this.labelSubject.MaximumSize = new System.Drawing.Size(100000, 0);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(286, 30);
            this.labelSubject.TabIndex = 1;
            this.labelSubject.Text = "Unesite podatke za dodavanje novog Proizvodjaca";
            this.labelSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddManufacturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 302);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AddManufacturerForm";
            this.Text = "AddManufacturerForm";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNaziv;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBoxLekovi;
        private System.Windows.Forms.Button buttonPonisti;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelSubject;
    }
}