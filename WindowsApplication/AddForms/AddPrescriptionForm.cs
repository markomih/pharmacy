using System;
using System.Data;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Services;

namespace WindowsApplication
{
    public partial class AddPrescriptionForm : Form
    {
        public AddPrescriptionForm(MainForm parent, Recept recept = null, bool add = true, bool details = false)
        {
            InitializeComponent();
            Recept = recept;
            Add = add;
            _parent = parent;

            numericDozaLeka.Maximum = 100000;
            numericKolicinaLeka.Maximum = 100000;

            comboBoxProdajnoMesto.DataSource = ServiceProvider.Get<ProdajnoMestoService>().GetDataTable();
            comboBoxFarmaceut.DataSource = ServiceProvider.Get<ZaposleniService>().GetFarmaceutDataTable();
            comboBoxLekar.DataSource = ServiceProvider.Get<LekarService>().GetDataTable();
            comboBoxKupac.DataSource = ServiceProvider.Get<KupacService>().GetDataTable();
            comboBoxLek.DataSource = ServiceProvider.Get<LekService>().GetDataTable(true);

            comboBoxProdajnoMesto.DisplayMember = Constants.ConcatenatedField;
            comboBoxFarmaceut.DisplayMember = Constants.ConcatenatedField;
            comboBoxLekar.DisplayMember = Constants.ConcatenatedField;
            comboBoxKupac.DisplayMember = Constants.ConcatenatedField;
            comboBoxLek.DisplayMember = Constants.ConcatenatedField;

            if (add) return;

            // ako je edit 

            if (Recept == null) throw new Exception("Recept == null; => Add Recept");

            buttonAdd.Text = Constants.ButtonEditText;

            Recept.Farmaceut = ServiceProvider.Get<ZaposleniService>().Get(Recept.Farmaceut.Id);
            Recept.Lekar = ServiceProvider.Get<LekarService>().Get(Recept.Lekar.Id);
            Recept.Kupac = ServiceProvider.Get<KupacService>().Get(Recept.Kupac.Id);
            Recept.Lek = ServiceProvider.Get<LekService>().Get(Recept.Lek.Id);

            comboBoxProdajnoMesto.Text = Recept.ProdajnoMesto.Id + @":" + Recept.ProdajnoMesto?.Naziv;
            comboBoxFarmaceut.Text = Recept.Farmaceut?.Id + @":" + Recept.Farmaceut?.Ime?.LIme;
            comboBoxKupac.Text = Recept.Lekar?.Id + @":" + Recept?.Lekar?.Ime?.LIme;
            comboBoxKupac.Text = Recept.Kupac?.Id + @":" + Recept?.Kupac?.Ime?.LIme;
            comboBoxKupac.Text = Recept.Lek?.Id + @":" + Recept?.Lek?.NazivLeka?.HemijskiNaziv;

            dateTimeDatumRealizacije.Value = Recept.DatumRealizacije;
            dateTimeDatumVazenja.Value = Recept.DatumVazenja;

            numericKolicinaLeka.Value = Recept.KolicinaLeka;
            numericDozaLeka.Value = Recept.Doza;

            if (!details) return;

            _parent.DisableAll(this);
            tableLayoutPanel1.Controls.Remove(buttonAdd);
            labelSubject.Text = @"Detaljne informacije";
        }

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FillPrescriptionArgs(Recept recept)
        {
            var id = int.Parse(((DataRowView) comboBoxProdajnoMesto.SelectedItem)["Id"].ToString());
            recept.ProdajnoMesto = ServiceProvider.Get<ProdajnoMestoService>().Get(id);

            id = int.Parse(((DataRowView) comboBoxFarmaceut.SelectedItem)["Id"].ToString());
            recept.Farmaceut = ServiceProvider.Get<ZaposleniService>().Get(id);

            id = int.Parse(((DataRowView) comboBoxLekar.SelectedItem)["Id"].ToString());
            recept.Lekar = ServiceProvider.Get<LekarService>().Get(id);

            id = int.Parse(((DataRowView) comboBoxKupac.SelectedItem)["Id"].ToString());
            recept.Kupac = ServiceProvider.Get<KupacService>().Get(id);

            id = int.Parse(((DataRowView) comboBoxLek.SelectedItem)["Id"].ToString());
            recept.Lek = ServiceProvider.Get<LekService>().Get(id);

            recept.KolicinaLeka = (int) numericKolicinaLeka.Value;
            recept.Doza = (int) numericDozaLeka.Value;

            recept.DatumRealizacije = dateTimeDatumRealizacije.Value;
            recept.DatumVazenja = dateTimeDatumVazenja.Value;
        }

        private void AddNewRecept(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                var r = new Recept();
                FillPrescriptionArgs(r);
                ServiceProvider.Get<ReceptService>().Create(r);
            }
            else
            {
                FillPrescriptionArgs(Recept);
                ServiceProvider.Get<ReceptService>().Update(Recept);
            }
            _parent.UpdatePrescriptionGrid();
            Dispose();
        }

        #region Fields

        private readonly MainForm _parent;
        public Recept Recept;
        public bool Add { get; }

        #endregion
    }
}