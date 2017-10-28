using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Entities;
using Services;
using Enum = Core.Enum;

namespace WindowsApplication
{
    public partial class AddPackageForm : Form
    {
        public AddPackageForm(MainForm parent, Pakovanje pakovanje = null, bool add = true, bool details = false)
        {
            InitializeComponent();
            _parent = parent;
            Pakovanje = pakovanje;
            Add = add;

            numericKolicina.Maximum = 100000;

            comboBoxTip.Items.Add(Enum.TipPakovanja.Prasak.ToString());
            comboBoxTip.Items.Add(Enum.TipPakovanja.Injekcija.ToString());
            comboBoxTip.Items.Add(Enum.TipPakovanja.Sirup.ToString());
            comboBoxTip.Items.Add(Enum.TipPakovanja.Tableta.ToString());

            listBoxKontraindikacija.DataSource = ServiceProvider.Get<KontraindikacijaService>().GetDataTable();
            listBoxLekovi.DataSource = ServiceProvider.Get<LekService>().GetDataTable();

            listBoxKontraindikacija.DisplayMember = Constants.ConcatenatedField;
            listBoxLekovi.DisplayMember = Constants.ConcatenatedField;

            if (Add) return;

            if (Pakovanje == null) throw new Exception("Pakovanje == null => AddPakcageForm");

            buttonAdd.Text = Constants.ButtonEditText;

            textBoxSastav.Text = Pakovanje.Sastav;
            numericKolicina.Value = Pakovanje.Kolicina;
            comboBoxTip.Text = Pakovanje.Tip.ToString();

            var ids = (from Entity x in Pakovanje.KontraindikacijaList select x.Id).ToList();
            _parent.FillDefault(listBoxKontraindikacija, ids);

            ids = (from Entity x in Pakovanje.LekList select x.Id).ToList();
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

        private void FillPackageArgs(Pakovanje pakovanje)
        {
            pakovanje.Sastav = textBoxSastav.Text;
            pakovanje.Kolicina = (int) numericKolicina.Value;

            if (listBoxKontraindikacija.SelectedItem != null)
                pakovanje.KontraindikacijaList = _parent.GetSelectedEntities(listBoxKontraindikacija)?
                    .Select(ServiceProvider.Get<KontraindikacijaService>().Get).ToList();

            if (listBoxLekovi.SelectedItem != null)
                pakovanje.LekList = _parent.GetSelectedEntities(listBoxLekovi)?
                    .Select(ServiceProvider.Get<LekService>().Get).ToList();
        }

        private void AddNewPakovanje(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No) return;

            if (Add)
            {
                Pakovanje pakovanje;
                switch (Enum.GetEnumTipPakovanja(comboBoxTip.Text))
                {
                    case Enum.TipPakovanja.Tableta:
                        pakovanje = new Tableta();
                        break;
                    case Enum.TipPakovanja.Sirup:
                        pakovanje = new Sirup();
                        break;
                    case Enum.TipPakovanja.Prasak:
                        pakovanje = new Prasak();
                        break;
                    case Enum.TipPakovanja.Injekcija:
                        pakovanje = new Injekcija();
                        break;
                    default:
                        throw new Exception("Pakovanje EnumTipLeka unknown");
                }
                FillPackageArgs(pakovanje);
                ServiceProvider.Get<PakovanjeService>().Create(pakovanje);
            }
            else
            {
                FillPackageArgs(Pakovanje);
                ServiceProvider.Get<PakovanjeService>().Update(Pakovanje);
            }
            _parent.UpdatePackageGrid();
            Dispose();
        }

        #region Fields

        private readonly MainForm _parent;
        public Pakovanje Pakovanje;
        public bool Add { get; }

        #endregion
    }
}