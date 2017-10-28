using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Services;

namespace WindowsApplication
{
    public partial class AddManufacturerForm : Form
    {
        public AddManufacturerForm(MainForm parent, Proizvodjac proizvodjac = null, bool add = true,
            bool details = false)
        {
            InitializeComponent();
            Proizvodjac = proizvodjac;
            Add = add;
            _parent = parent;

            listBoxLekovi.DataSource = ServiceProvider.Get<LekService>().GetDataTable();
            listBoxLekovi.DisplayMember = Constants.ConcatenatedField;

            if (add) return;
            // ako je EDIT
            if (Proizvodjac == null) throw new Exception("Proizvodjac== null; => Add Proizvodjac");

            buttonAdd.Text = Constants.ButtonEditText;

            textBoxNaziv.Text = Proizvodjac?.Naziv;

            var ids = (from Lek x in Proizvodjac.LekList select x.Id).ToList();
            _parent.FillDefault(listBoxLekovi, ids);

            if (!details) return;

            _parent.DisableAll(this);
            tableLayoutPanel1.Controls.Remove(buttonAdd);
            labelSubject.Text = @"Detaljne informacije";
        }


        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FillManufacturerArgs(Proizvodjac proizvodjac)
        {
            proizvodjac.Naziv = textBoxNaziv.Text;
            if (listBoxLekovi.SelectedItem != null)
                proizvodjac.LekList = _parent.GetSelectedEntities(listBoxLekovi)?
                    .Select(ServiceProvider.Get<LekService>().Get).ToList();
        }

        private void AddNewManufacturer(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                var obj = new Proizvodjac();
                FillManufacturerArgs(obj);
                ServiceProvider.Get<ProizvodjacService>().Create(obj);
            }
            else
            {
                FillManufacturerArgs(Proizvodjac);
                ServiceProvider.Get<ProizvodjacService>().Update(Proizvodjac);
            }
            _parent.UpdateManufacturerGrid();
            Dispose();
        }

        #region Fields

        private readonly MainForm _parent;
        public Proizvodjac Proizvodjac;
        public bool Add { get; set; }

        #endregion
    }
}