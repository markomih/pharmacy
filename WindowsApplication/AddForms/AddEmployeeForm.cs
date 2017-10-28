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
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm(MainForm parent, Zaposleni zaposleni = null, bool add = true, bool details = false)
        {
            InitializeComponent();
            Add = add;
            Zaposleni = zaposleni;
            _parent = parent;

            comboBoxProdajnoMesto.DataSource = ServiceProvider.Get<ProdajnoMestoService>().GetDataTable();
            listBoxRecepti.DataSource = ServiceProvider.Get<ReceptService>().GetDataTable();

            comboBoxProdajnoMesto.DisplayMember = Constants.ConcatenatedField;
            listBoxRecepti.DisplayMember = Constants.ConcatenatedField;

            if (add) return;
            // ako je EDIT
            if (Zaposleni == null) throw new Exception("Zaposleni == null; => Add Zaposleni");

            buttonAdd.Text = Constants.ButtonEditText;

            textBoxLIme.Text = Zaposleni.Ime?.LIme;
            textBoxPrezime.Text = Zaposleni.Ime?.Prezime;
            textBoxEmail.Text = Zaposleni?.Kontakt?.Email;
            textBoxTelefon.Text = Zaposleni?.Kontakt?.BrojTelefona;
            textBoxAdresa.Text = Zaposleni?.Lokacija?.Adresa;
            textBoxMesto.Text = Zaposleni?.Lokacija?.Mesto;
            textBoxJmbg.Text = Zaposleni?.Jmbg;
            dateTimeDatumZaposljavanja.Value = Zaposleni.DatumZaposljavanja;
            checkBoxFFaramaceut.Checked = Zaposleni.FFarmaceut;

            if (Zaposleni.FFarmaceut)
            {
                dateTimeDatumObnoveLicence.Enabled = true;
                dateTimeDatumDiplomiranja.Enabled = true;
                if (Zaposleni.DatumObnoveLicence != null)
                    dateTimeDatumObnoveLicence.Value = (DateTime) Zaposleni.DatumObnoveLicence;
                if (Zaposleni.DatumDiplomiranja != null)
                    dateTimeDatumDiplomiranja.Value = (DateTime) Zaposleni.DatumDiplomiranja;
            }

            Zaposleni.ProdajnoMesto = ServiceProvider.Get<ProdajnoMestoService>().Get(Zaposleni.ProdajnoMesto.Id);
            comboBoxProdajnoMesto.Text = Zaposleni.ProdajnoMesto.Id + @" : " + Zaposleni.ProdajnoMesto.Naziv;
            //var Recepti = DataProvider.GetAll<Recept>().ToList();
            //Zaposleni.ReceptList = DataProvider.GetAll<Recept>().ToList();
            var ids = (from Recept x in Zaposleni.ReceptList select x.Id).ToList();
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

        private void FillEmployeeArgs(Zaposleni zaposleni)
        {
            zaposleni.Ime = new Ime {LIme = textBoxLIme.Text, Prezime = textBoxPrezime.Text};
            zaposleni.Kontakt = new Kontakt {Email = textBoxEmail.Text, BrojTelefona = textBoxTelefon.Text};
            zaposleni.Lokacija = new Lokacija {Adresa = textBoxAdresa.Text, Mesto = textBoxMesto.Text};
            zaposleni.Jmbg = textBoxJmbg.Text;
            zaposleni.DatumZaposljavanja = dateTimeDatumZaposljavanja.Value;
            zaposleni.FFarmaceut = checkBoxFFaramaceut.Checked;

            if (zaposleni.FFarmaceut)
            {
                zaposleni.DatumObnoveLicence = dateTimeDatumObnoveLicence.Value;
                zaposleni.DatumDiplomiranja = dateTimeDatumDiplomiranja.Value;
            }

            var prodajnoMestoId = int.Parse(((DataRowView) comboBoxProdajnoMesto.SelectedItem)["Id"].ToString());
            zaposleni.ProdajnoMesto = ServiceProvider.Get<ProdajnoMestoService>().Get(prodajnoMestoId);

            if (listBoxRecepti.SelectedItem != null)
                zaposleni.ReceptList = _parent.GetSelectedEntities(listBoxRecepti)?
                    .Select(ServiceProvider.Get<ReceptService>().Get).ToList();
        }

        private void AddNewEmployee(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                var zaposleni = new Zaposleni();
                FillEmployeeArgs(zaposleni);

                ServiceProvider.Get<ZaposleniService>().Create(zaposleni);
            }
            else
            {
                FillEmployeeArgs(Zaposleni);
                ServiceProvider.Get<ZaposleniService>().Update(Zaposleni);
            }
            _parent.UpdateEmployeeGrid();
            Dispose();
        }

        private void checkBoxFFaramaceut_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeDatumObnoveLicence.Enabled = checkBoxFFaramaceut.Checked;
            dateTimeDatumDiplomiranja.Enabled = checkBoxFFaramaceut.Checked;
        }

        #region Fields

        private readonly MainForm _parent;
        public Zaposleni Zaposleni;
        public bool Add { get; }

        #endregion
    }
}