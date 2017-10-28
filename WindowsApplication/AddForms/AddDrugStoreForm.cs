using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Core.Entities.Component;
using Services;

namespace WindowsApplication
{
    public partial class AddDrugStoreForm : Form
    {
        public AddDrugStoreForm(MainForm parent, ProdajnoMesto prodajnoMesto = null, bool add = true, bool details = false)
        {
            InitializeComponent();
            _parent = parent;
            ProdajnoMesto = prodajnoMesto;
            Add = add;

            comboBoxApotekarskaUstanova.DataSource = ServiceProvider.Get<ApotekarskaUstanovaService>().GetDataTable();
            listBoxZaposleni.DataSource = ServiceProvider.Get<ZaposleniService>().GetDataTable();
            listBoxLekovi.DataSource = ServiceProvider.Get<LekService>().GetDataTable();
            listBoxRecepti.DataSource = ServiceProvider.Get<ReceptService>().GetDataTable();

            comboBoxApotekarskaUstanova.DisplayMember = Constants.ConcatenatedField;
            listBoxZaposleni.DisplayMember = Constants.ConcatenatedField;
            listBoxLekovi.DisplayMember = Constants.ConcatenatedField;
            listBoxRecepti.DisplayMember = Constants.ConcatenatedField;

            if (Add) return;

            if (ProdajnoMesto == null) throw new Exception("ProdajnoMesto == null");

            buttonAdd.Text = @"Sacuvaj promene";
            textBoxNaziv.Text = ProdajnoMesto.Naziv;
            textBoxAdresa.Text = ProdajnoMesto?.Lokacija?.Adresa;
            textBoxMesto.Text = ProdajnoMesto?.Lokacija?.Mesto;
            comboBoxApotekarskaUstanova.Text = ProdajnoMesto.ApotekarskaUstanova.Id + @" : " +
                                               ProdajnoMesto.ApotekarskaUstanova.Naziv;

            var ids = (from Entity x in ProdajnoMesto.ZaposleniList select x.Id).ToList();
            _parent.FillDefault(listBoxZaposleni, ids);

            ids = (from Entity x in ProdajnoMesto.LekList select x.Id).ToList();
            _parent.FillDefault(listBoxLekovi, ids);

            ids = (from Entity x in ProdajnoMesto.ReceptList select x.Id).ToList();
            _parent.FillDefault(listBoxRecepti, ids);

            if (!details) return;

            _parent.DisableAll(this);
            tableLayoutPanel1.Controls.Remove(buttonAdd);
            labelSubject.Text = @"Detaljne informacije";
        }

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FillPrescriptionArgs(ProdajnoMesto prodajnoMesto)
        {
            prodajnoMesto.Naziv = textBoxNaziv.Text;
            prodajnoMesto.Lokacija = new Lokacija {Adresa = textBoxAdresa.Text, Mesto = textBoxMesto.Text};

            if (comboBoxApotekarskaUstanova.Text != "")
            {
                var id = int.Parse(((DataRowView) comboBoxApotekarskaUstanova.SelectedItem)["Id"].ToString());
                prodajnoMesto.ApotekarskaUstanova = ServiceProvider.Get<ApotekarskaUstanovaService>().Get(id);
            }

            if (listBoxZaposleni.SelectedItem != null)
                prodajnoMesto.ZaposleniList = _parent.GetSelectedEntities(listBoxZaposleni)?
                .Select(ServiceProvider.Get<ZaposleniService>().Get).ToList();

           
            if (listBoxLekovi.SelectedItem != null)
                prodajnoMesto.LekList = _parent.GetSelectedEntities(listBoxLekovi)?
                 .Select(ServiceProvider.Get<LekService>().Get).ToList();

            if (listBoxRecepti.SelectedItem != null)
                prodajnoMesto.ReceptList = _parent.GetSelectedEntities(listBoxRecepti)?
                 .Select(ServiceProvider.Get<ReceptService>().Get).ToList();
        }

        private void AddNewPrescription(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                var obj = new ProdajnoMesto();
                FillPrescriptionArgs(obj);
                ServiceProvider.Get<ProdajnoMestoService>().Create(obj);
            }
            else
            {
                FillPrescriptionArgs(ProdajnoMesto);
                ServiceProvider.Get<ProdajnoMestoService>().Update(ProdajnoMesto);
            }
            _parent.UpdateDrugStoreGrid();
            Dispose();
        }

        #region Fields

        private readonly MainForm _parent;
        public ProdajnoMesto ProdajnoMesto;
        public bool Add { get; }

        #endregion
    }
}