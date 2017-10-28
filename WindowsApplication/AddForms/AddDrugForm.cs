using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Core.Entities.Component;
using Services;
using Enum = Core.Enum;

namespace WindowsApplication
{
    public partial class AddDrugForm : Form
    {
        public AddDrugForm(MainForm parent, Lek lek = null, bool add = true, bool details = false)
        {
            InitializeComponent();
            Add = add;
            Lek = lek;
            _parent = parent;

            textBoxCenaLeka.Maximum = 100000;
            textBoxProcenatParticipacijeLeka.Maximum = 100;

            comboBoxTipLeka.Items.Add(Enum.TipLeka.Analgetik);
            comboBoxTipLeka.Items.Add(Enum.TipLeka.Antipiretik);
            comboBoxTipLeka.Items.Add(Enum.TipLeka.Antibiotik);
            comboBoxTipLeka.Items.Add(Enum.TipLeka.Diuretik);

            comboBoxNacinDoziranja.Items.Add(Enum.NacinDoziranja.Trudnice);
            comboBoxNacinDoziranja.Items.Add(Enum.NacinDoziranja.Deca);
            comboBoxNacinDoziranja.Items.Add(Enum.NacinDoziranja.Odrasli);

            comboBoxNacinDoziranja.SelectedIndex = 0;
            comboBoxTipLeka.SelectedIndex = 0;

            comboBoxPakovanje.DataSource = ServiceProvider.Get<PakovanjeService>().GetDataTable();
            listBoxBolesti.DataSource = ServiceProvider.Get<BolestService>().GetDataTable();
            listBoxProizvodjaci.DataSource = ServiceProvider.Get<ProizvodjacService>().GetDataTable();
            listBoxKontraindikacije.DataSource = ServiceProvider.Get<KontraindikacijaService>().GetDataTable();
            listBoxProdajnaMesta.DataSource = ServiceProvider.Get<ProdajnoMestoService>().GetDataTable();
            listBoxRecepti.DataSource = ServiceProvider.Get<ReceptService>().GetDataTable();


            comboBoxPakovanje.DisplayMember = Constants.ConcatenatedField;
            listBoxBolesti.DisplayMember = Constants.ConcatenatedField;
            listBoxKontraindikacije.DisplayMember = Constants.ConcatenatedField;
            listBoxProdajnaMesta.DisplayMember = Constants.ConcatenatedField;
            listBoxRecepti.DisplayMember = Constants.ConcatenatedField;
            listBoxProizvodjaci.DisplayMember = Constants.ConcatenatedField;

            if (add) return;

            // ako je edit 

            if (Lek == null) throw new Exception("Lek == null; => Add Drug");

            buttonAddDrug.Text = Constants.ButtonEditText;

            Lek.Pakovanje = ServiceProvider.Get<PakovanjeService>().Get(Lek.Pakovanje.Id);
            textBoxHemijskiNazivLeka.Text = Lek.NazivLeka.HemijskiNaziv;
            textBoxCenaLeka.Value = (decimal) Lek.Cena;
            comboBoxTipLeka.Text = Lek.TipLeka.ToString();
            comboBoxTipLeka.Enabled = false;
            textBoxNezeljeniEfekti.Text = Lek.NezeljeniEfekti;
            textBoxProcenatParticipacijeLeka.Value = (decimal) Lek.ProcenatParticipacije;
            comboBoxPakovanje.Text = Lek.Pakovanje.Id + @" : " + Lek.Pakovanje.Tip;

            var ids = (from Entity x in Lek.BolestList select x.Id).ToList();
            _parent.FillDefault(listBoxBolesti, ids);

            ids = (from Entity x in Lek.ProizvodjacList select x.Id).ToList();
            _parent.FillDefault(listBoxProizvodjaci, ids);

            ids = (from Entity x in Lek.ProdajnoMestoList select x.Id).ToList();
            _parent.FillDefault(listBoxProdajnaMesta, ids);

            textBoxDejstvo.Text = Lek.Dejstvo;

            checkBoxNaRecept.Checked = Lek.NaRecept;
            listBoxRecepti.Enabled = Lek.NaRecept;

            if (Lek.NaRecept)
            {
                ids = (from Entity x in Lek.ReceptList select x.Id).ToList();
                _parent.FillDefault(listBoxRecepti, ids);
            }
            comboBoxNacinDoziranja.Text = Lek.NacinDoziranja.ToString();

            if (!details) return;

            _parent.DisableAll(this);
            tableLayoutPanelDrug.Controls.Remove(buttonAddDrug);
            labelSubject.Text = @"Detaljne informacije";
        }


        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FillDrugArgs(Lek lek)
        {
            lek.NazivLeka = new NazivLeka {HemijskiNaziv = textBoxHemijskiNazivLeka.Text};
            lek.Cena = double.Parse(textBoxCenaLeka.Text);
            // Tip
            lek.ProcenatParticipacije = double.Parse(textBoxProcenatParticipacijeLeka.Text);
            if (comboBoxPakovanje.Text != "")
            {
                var id = int.Parse(((DataRowView) comboBoxPakovanje.SelectedItem)["Id"].ToString());
                lek.Pakovanje = ServiceProvider.Get<PakovanjeService>().Get(id);
            }

            if (listBoxBolesti.SelectedItem != null)
                lek.BolestList = _parent.GetSelectedEntities(listBoxBolesti)?
                    .Select(ServiceProvider.Get<BolestService>().Get).ToList();

            if (listBoxProizvodjaci.SelectedItem != null)
                lek.ProizvodjacList = _parent.GetSelectedEntities(listBoxProizvodjaci)?
                    .Select(ServiceProvider.Get<ProizvodjacService>().Get).ToList();

            if (listBoxKontraindikacije.SelectedItem != null)
                lek.KontraindikacijaList = _parent.GetSelectedEntities(listBoxKontraindikacije)?
                    .Select(ServiceProvider.Get<KontraindikacijaService>().Get).ToList();

            if (listBoxProdajnaMesta.SelectedItem != null)
                lek.ProdajnoMestoList = _parent.GetSelectedEntities(listBoxProdajnaMesta)?
                    .Select(ServiceProvider.Get<ProdajnoMestoService>().Get).ToList();

            lek.NaRecept = checkBoxNaRecept.Checked;

            if (lek.NaRecept && listBoxRecepti.SelectedItem != null)
                lek.ReceptList = _parent.GetSelectedEntities(listBoxRecepti)?
                    .Select(ServiceProvider.Get<ReceptService>().Get).ToList();

            lek.Dejstvo = textBoxDejstvo.Text;
            lek.NacinDoziranja = Enum.GetEnumNacinDoziranja(comboBoxNacinDoziranja.Text);
            lek.NezeljeniEfekti = textBoxNezeljeniEfekti.Text;
        }

        private void AddNewLek(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            Lek lekPom;

            if (Add)
            {
                switch (Enum.GetEnumTipLeka(comboBoxTipLeka.Text))
                {
                    case Enum.TipLeka.Analgetik:
                        lekPom = new Analgetik();
                        break;
                    case Enum.TipLeka.Antipiretik:
                        lekPom = new Antipiretik();
                        break;
                    case Enum.TipLeka.Antibiotik:
                        lekPom = new Antibiotik();
                        break;
                    case Enum.TipLeka.Diuretik:
                        lekPom = new Diuretik();
                        break;
                    default:
                        throw new Exception("Lek EnumTipLeka unknown");
                }
                FillDrugArgs(lekPom);
                ServiceProvider.Get<LekService>().Create(lekPom);
            }
            else
            {
                FillDrugArgs(Lek);
                ServiceProvider.Get<LekService>().Update(Lek);
            }


            _parent.UpdateDrugGrid();
            Dispose();
        }

        #region Fields

        public Lek Lek;
        public bool Add { get; }
        private readonly MainForm _parent;

        #endregion
    }
}