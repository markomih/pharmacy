using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Core.Entities.Component;
using Services;

namespace WindowsApplication
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm(MainForm parent, Kupac kupac = null, bool add = true, bool details = false)
        {
            InitializeComponent();
            Add = add;
            Kupac = kupac;
            _parent = parent;

            numericPazar.Maximum = 100000;

            listBoxRecepti.DataSource = ServiceProvider.Get<ReceptService>().GetDataTable();
            listBoxRecepti.DisplayMember = Constants.ConcatenatedField;

            if (add) return;

            if (Kupac == null) throw new Exception("Kupac == null; => Add Kupac");

            buttonAdd.Text = Constants.ButtonEditText;

            textBoxLIme.Text = Kupac.Ime?.LIme;
            textBoxPrezime.Text = Kupac.Ime?.Prezime;
            textBoxEmail.Text = Kupac?.Kontakt?.Email;
            textBoxTelefon.Text = Kupac?.Kontakt?.BrojTelefona;
            numericPazar.Value = (decimal) Kupac.Pazar;

            var ids = (from Entity x in Kupac.ReceptList select x.Id).ToList();
            _parent.FillDefault(listBoxRecepti, ids);


            if (!details) return;

            _parent.DisableAll(this);
            tableLayoutPanel1.Controls.Remove(buttonAdd);
            labelSubject.Text = @"Detaljne informacije";
        }

        #region button Dispose Event

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region Fill object

        private void FillCustomerArgs(Kupac kupac)
        {
            if (listBoxRecepti.SelectedItem != null)
                kupac.ReceptList = _parent.GetSelectedEntities(listBoxRecepti)?
                    .Select(ServiceProvider.Get<ReceptService>().Get).ToList();

            kupac.Pazar = (double) numericPazar.Value;
            kupac.Ime = new Ime {LIme = textBoxLIme.Text, Prezime = textBoxPrezime.Text};
            kupac.Kontakt = new Kontakt {Email = textBoxEmail.Text, BrojTelefona = textBoxTelefon.Text};
        }

        #endregion

        #region button Add Event

        private void AddNewKupac(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                var o = new Kupac();
                FillCustomerArgs(o);
                ServiceProvider.Get<KupacService>().Create(o);
            }
            else
            {
                FillCustomerArgs(Kupac);
                ServiceProvider.Get<KupacService>().Update(Kupac);
            }
            _parent.UpdateCustomerGrid();
            Dispose();
        }

        #endregion

        #region Fields

        private readonly MainForm _parent;
        public Kupac Kupac;
        public bool Add { get; }

        #endregion
    }
}