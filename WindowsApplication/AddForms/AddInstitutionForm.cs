using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Core.Entities.Component;
using Services;

namespace WindowsApplication
{
    public partial class AddInstitutionForm : Form
    {
        private readonly MainForm _parent;
        public ApotekarskaUstanova ApotekarskaUstanova;

        public AddInstitutionForm(MainForm parent, ApotekarskaUstanova apotekarskaUstanova = null, bool add = true,
            bool details = false)
        {
            InitializeComponent();
            Add = add;
            ApotekarskaUstanova = apotekarskaUstanova;
            _parent = parent;

            listBoxProdajnaMesta.DataSource = ServiceProvider.Get<ProdajnoMestoService>().GetDataTable();
            listBoxProdajnaMesta.DisplayMember = Constants.ConcatenatedField;

            if (add) return;
            // ako je EDIT
            if (ApotekarskaUstanova == null)
                throw new Exception("ApotekarskaUstanova == null; => Add ApotekarskaUstanova");

            buttonAdd.Text = Constants.ButtonEditText;

            textBoxNaziv.Text = ApotekarskaUstanova?.Naziv;
            textBoxSajt.Text = ApotekarskaUstanova?.Sajt;
            textBoxEmail.Text = ApotekarskaUstanova?.Kontakt?.Email;
            textBoxTelefon.Text = ApotekarskaUstanova?.Kontakt?.BrojTelefona;

            var ids = (from Entity x in ApotekarskaUstanova.ProdajnoMestoList select x.Id).ToList();
            _parent.FillDefault(listBoxProdajnaMesta, ids);

            if (!details) return;

            _parent.DisableAll(this);
            tableLayoutPanel1.Controls.Remove(buttonAdd);
            labelSubject.Text = @"Detaljne informacije";
        }

        public bool Add { get; }

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FillInstitutionArgs(ApotekarskaUstanova apotekarskaUstanova)
        {
            apotekarskaUstanova.Naziv = textBoxNaziv.Text;
            apotekarskaUstanova.Sajt = textBoxSajt.Text;
            apotekarskaUstanova.Kontakt = new Kontakt {Email = textBoxEmail.Text, BrojTelefona = textBoxTelefon.Text};
            if (listBoxProdajnaMesta.SelectedItem != null)
                apotekarskaUstanova.ProdajnoMestoList = _parent.GetSelectedEntities(listBoxProdajnaMesta)?
                    .Select(ServiceProvider.Get<ProdajnoMestoService>().Get).ToList();
        }

        private void AddNewInstitution(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                var obj = new ApotekarskaUstanova();
                FillInstitutionArgs(obj);
                ServiceProvider.Get<ApotekarskaUstanovaService>().Create(obj);
            }
            else
            {
                FillInstitutionArgs(ApotekarskaUstanova);
                ServiceProvider.Get<ApotekarskaUstanovaService>().Update(ApotekarskaUstanova);
            }
            _parent.UpdateInstitutionGrid();
            Dispose();
        }
    }
}