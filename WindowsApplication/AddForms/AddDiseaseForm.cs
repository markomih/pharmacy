using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Core.Entities.Component;
using Services;

namespace WindowsApplication
{
    public partial class AddDiseaseForm : Form
    {
        public AddDiseaseForm(MainForm parent, Bolest bolest = null, bool add = true, bool details = false)
        {
            #region Initialize

            InitializeComponent();
            _parent = parent;
            Bolest = bolest;
            Add = add;

            #endregion

            #region Add handler

            listBoxKontraindikacije.DataSource = ServiceProvider.Get<KontraindikacijaService>().GetDataTable();
            listBoxLekovi.DataSource = ServiceProvider.Get<LekService>().GetDataTable();

            listBoxKontraindikacije.DisplayMember = Constants.ConcatenatedField;
            listBoxLekovi.DisplayMember = Constants.ConcatenatedField;

            #endregion

            if (add) return;

            #region Edit handler

            if (Bolest == null) throw new Exception("Bolest == null => Bolest Add");

            textBoxLatinskiNaziv.Text = bolest?.NazivBolesti?.LatinskiNaziv;
            textBoxNarodniNaziv.Text = bolest?.NazivBolesti?.NarodniNaziv;

            buttonAdd.Text = Constants.ButtonEditText;

            var ids = (from Entity x in Bolest.KontraindikacijaList select x.Id).ToList();
            _parent.FillDefault(listBoxKontraindikacije, ids);


            ids = (from Entity x in Bolest.LekList select x.Id).ToList();
            _parent.FillDefault(listBoxLekovi, ids);


            textBoxOpis.Text = Bolest.Opis;

            #endregion

            #region details handler

            if (!details) return;

            _parent.DisableAll(this);
            tableLayoutPanel1.Controls.Remove(buttonAdd);

            labelSubject.Text = @"Detaljne informacije";
            #endregion
        }

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FillDiseaseArgs(Bolest bolest)
        {
            bolest.NazivBolesti = new NazivBolesti
            {
                LatinskiNaziv = textBoxLatinskiNaziv.Text,
                NarodniNaziv = textBoxNarodniNaziv.Text
            };

            if (listBoxKontraindikacije.SelectedItem != null)
                bolest.KontraindikacijaList = _parent.GetSelectedEntities(listBoxKontraindikacije)?
                .Select(ServiceProvider.Get<KontraindikacijaService>().Get).ToList();

            if (listBoxLekovi.SelectedItem != null)
                bolest.LekList = _parent.GetSelectedEntities(listBoxLekovi)?
                    .Select(ServiceProvider.Get<LekService>().Get).ToList();

            bolest.Opis = textBoxOpis.Text;
        }

        private void AddNewDisease(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                var obj = new Bolest();
                FillDiseaseArgs(obj);
                ServiceProvider.Get<BolestService>().Create(obj);
            }
            else
            {
                FillDiseaseArgs(Bolest);
                ServiceProvider.Get<BolestService>().Update(Bolest);
            }
            _parent.UpdateDiseaseGrid();
            Dispose();
        }

        #region Fields

        private readonly MainForm _parent;
        public Bolest Bolest;
        public bool Add { get; }

        #endregion
    }
}