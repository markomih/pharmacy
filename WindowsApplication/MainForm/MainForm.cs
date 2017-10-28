using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Core;
using NHibernate.Util;
using Services;

namespace WindowsApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            #region Update Gdrids
                
            UpdateDrugGrid();
            UpdatePrescriptionGrid();
            UpdateEmployeeGrid();
            UpdateCustomerGrid();
            UpdateInstitutionGrid();
            UpdateManufacturerGrid();
            UpdateDiseaseGrid();
            UpdatePackageGrid();
            UpdateDrugStoreGrid();
         
            #endregion
        }

        #region Fields

        #endregion

        #region algorithms for children

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            var enumerable = controls as IList<Control> ?? controls.ToList();

            return enumerable.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(enumerable)
                                      .Where(c => c.GetType() == type).ToList();
        }

        public void DisableAll(Form form)
        {
            GetAll(form, typeof(TextBox)).ForEach(x => x.Enabled = false);
            GetAll(form, typeof(CheckBox)).ForEach(x => x.Enabled = false);
            GetAll(form, typeof(ListBox)).ForEach(x => x.Enabled = false);
            GetAll(form, typeof(NumericUpDown)).ForEach(x => x.Enabled = false);
            GetAll(form, typeof(RadioButton)).ForEach(x => x.Enabled = false);
            GetAll(form, typeof(ComboBox)).ForEach(x => x.Enabled = false);
            GetAll(form, typeof(DateTime)).ForEach(x => x.Enabled = false);
        }
        public void FillDefault(ListBox listBox, List<int> ids)
        {
            for (var i = 0; i < listBox.Items.Count; i++)
            {
                //var aid = int.Parse(((DataRowView)comboBoxPakovanje.SelectedItem)["Id"].ToString());

                var id = int.Parse(((DataRowView) listBox.Items[i])["Id"].ToString());

                //var id = int.Parse(listBox.GetItemText(listBox.Items[i]).Split(':')[0]);

                listBox.SetSelected(i, ids.Contains(id));
            }
        }

        //public List<T> GetSelectedEntities<T>(ListBox listBox) where T : IService<Entity>
        //{
        //    var ids = from object selectedItem in listBox.SelectedItems
        //        select int.Parse(((DataRowView) selectedItem)["Id"].ToString());
        //    return null;
        //    //return ids.Select(ServiceProvider.Get<T>().Get).ToList();
        //}

        public IEnumerable<int> GetSelectedEntities(ListBox listBox)
        {
            return from object selectedItem in listBox.SelectedItems
                   select int.Parse(((DataRowView)selectedItem)["Id"].ToString());
        } 

        #endregion

        #region Enable Button Click event

        public void UpdateGridClickEvent()
        {
            DrugGridClickEvent();
            PrescriptionGridClickEvent();
            EmployeeGridClickEvent();
            CustomerGridClickEvent();
            ManufacturerGridClickEvent();
            InstitutionGridClickEvent();
            DiseaseGridClickEvent();
            PackageGridClickEvent();
            DrugStoreGridClickEvent();
        }

        public void DrugGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonDrugEdit.Enabled = dataGridDrugs.SelectedRows.Count != 0;
            buttonDrugRemove.Enabled = dataGridDrugs.SelectedRows.Count != 0;
            buttonDrugDetails.Enabled = dataGridDrugs.SelectedRows.Count != 0;
        }

        public void PrescriptionGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonPerscriptionEdit.Enabled = dataGridPrescription.SelectedRows.Count != 0;
            buttonPerscriptionRemove.Enabled = dataGridPrescription.SelectedRows.Count != 0;
            buttonPrescriptionDetails.Enabled = dataGridPrescription.SelectedRows.Count != 0;
        }

        public void EmployeeGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonEmployeeEdit.Enabled = dataGridEmployee.SelectedRows.Count != 0;
            buttonEmployeeRemove.Enabled = dataGridEmployee.SelectedRows.Count != 0;
            buttonEmployeeDetails.Enabled = dataGridEmployee.SelectedRows.Count != 0;
        }

        public void CustomerGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonCustomerEdit.Enabled = dataGridCustomer.SelectedRows.Count != 0;
            buttonCustomerRemove.Enabled = dataGridCustomer.SelectedRows.Count != 0;
            buttonCustomerDetails.Enabled = dataGridCustomer.SelectedRows.Count != 0;
        }

        public void ManufacturerGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonManufacturerEdit.Enabled = dataGridManufacturer.SelectedRows.Count != 0;
            buttonManufacturerRemove.Enabled = dataGridManufacturer.SelectedRows.Count != 0;
            buttonManufacturerDetails.Enabled = dataGridManufacturer.SelectedRows.Count != 0;
        }

        public void InstitutionGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonInstitutionEdit.Enabled = dataGridInstitution.SelectedRows.Count != 0;
            buttonInstitutionRemove.Enabled = dataGridInstitution.SelectedRows.Count != 0;
            buttonInstitutionDetails.Enabled = dataGridInstitution.SelectedRows.Count != 0;
        }

        public void DiseaseGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonDiseaseEdit.Enabled = dataGridDisease.SelectedRows.Count != 0;
            buttonDiseaseRemove.Enabled = dataGridDisease.SelectedRows.Count != 0;
            buttonDiseaseDetails.Enabled = dataGridDisease.SelectedRows.Count != 0;
        }

        public void PackageGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonPackageEdit.Enabled = dataGridPackage.SelectedRows.Count != 0;
            buttonPackageRemove.Enabled = dataGridPackage.SelectedRows.Count != 0;
            buttonPackageDetails.Enabled = dataGridPackage.SelectedRows.Count != 0;
        }

        public void DrugStoreGridClickEvent(object sender = null, EventArgs e = null)
        {
            buttonDrugStoreEdit.Enabled = dataGridDrugStore.SelectedRows.Count != 0;
            buttonDrugStoreRemove.Enabled = dataGridDrugStore.SelectedRows.Count != 0;
            buttonDrugStoreDetails.Enabled = dataGridDrugStore.SelectedRows.Count != 0;
        }

        #endregion

        #region Edit Click event

        private void buttonDrugEdit_Click(object sender, EventArgs e)
        {
            DrugGridClickEvent();

            var value = int.Parse((string) dataGridDrugs.Rows[dataGridDrugs.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<LekService>().Get(value);

            var form = new AddDrugForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonPrescriptionEdit_Click(object sender, EventArgs e)
        {
            PrescriptionGridClickEvent();

            var value =
                int.Parse((string) dataGridPrescription.Rows[dataGridPrescription.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ReceptService>().Get(value);

            var form = new AddPrescriptionForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonEmployeeEdit_Click(object sender, EventArgs e)
        {
            EmployeeGridClickEvent();

            var value = int.Parse((string) dataGridEmployee.Rows[dataGridEmployee.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ZaposleniService>().Get(value);

            var form = new AddEmployeeForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonCustomerEdit_Click(object sender, EventArgs e)
        {
            CustomerGridClickEvent();

            var value = int.Parse((string) dataGridCustomer.Rows[dataGridCustomer.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<KupacService>().Get(value);

            var form = new AddCustomerForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonInstitutionEdit_Click(object sender, EventArgs e)
        {
            InstitutionGridClickEvent();

            var value =
                int.Parse((string) dataGridInstitution.Rows[dataGridInstitution.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ApotekarskaUstanovaService>().Get(value);

            var form = new AddInstitutionForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonManufacturerEdit_Click(object sender, EventArgs e)
        {
            ManufacturerGridClickEvent();

            var value =
                int.Parse((string) dataGridManufacturer.Rows[dataGridManufacturer.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ProizvodjacService>().Get(value);

            var form = new AddManufacturerForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonDiseaseEdit_Click(object sender, EventArgs e)
        {
            DiseaseGridClickEvent();

            var value = int.Parse((string) dataGridDisease.Rows[dataGridDisease.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<BolestService>().Get(value);

            var form = new AddDiseaseForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonPackageEdit_Click(object sender, EventArgs e)
        {
            PackageGridClickEvent();

            var value =
                int.Parse((string) dataGridPackage.Rows[dataGridPackage.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<PakovanjeService>().Get(value);

            var form = new AddPackageForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonDrugStoreEdit_Click(object sender, EventArgs e)
        {
            DrugStoreGridClickEvent();

            var value =
                int.Parse((string) dataGridDrugStore.Rows[dataGridDrugStore.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ProdajnoMestoService>().Get(value);

            var form = new AddDrugStoreForm(this, obj, false);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        #endregion

        #region Update Grid

        public void UpdateDrugGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            var naRecept = checkBoxNaRecept.Checked;

            if (radioButtonAntibiotici.Checked)
                dataGridDrugs.DataSource = ServiceProvider.Get<AntibiotikService>().GetDataTable(naRecept);
            else if (radioButtonAntipiretici.Checked)
                dataGridDrugs.DataSource = ServiceProvider.Get<AntipiretikService>().GetDataTable(naRecept);
            else if (radioButtonDiuretici.Checked)
                dataGridDrugs.DataSource = ServiceProvider.Get<DiuretikService>().GetDataTable(naRecept);
            else if (radioButtonAnalgetici.Checked)
                dataGridDrugs.DataSource = ServiceProvider.Get<AnalgetikService>().GetDataTable(naRecept);
            else
                dataGridDrugs.DataSource = ServiceProvider.Get<LekService>().GetDataTable(naRecept);

            dataGridDrugs.Update();
        }

        public void UpdatePrescriptionGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            dataGridPrescription.DataSource = ServiceProvider.Get<ReceptService>().GetDataTable();
            dataGridPrescription.Update();
        }

        public void UpdateEmployeeGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            dataGridEmployee.DataSource = checkBoxEmployeeFarmaceut.Checked
                ? ServiceProvider.Get<ZaposleniService>().GetFarmaceutDataTable()
                : ServiceProvider.Get<ZaposleniService>().GetDataTable();
            dataGridEmployee.Update();
        }

        public void UpdateCustomerGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            dataGridCustomer.DataSource = ServiceProvider.Get<KupacService>().GetDataTable();
            dataGridCustomer.Update();
        }

        public void UpdateInstitutionGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            dataGridInstitution.DataSource = ServiceProvider.Get<ApotekarskaUstanovaService>().GetDataTable();
            dataGridInstitution.Update();
        }

        public void UpdateManufacturerGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            dataGridManufacturer.DataSource = ServiceProvider.Get<ProizvodjacService>().GetDataTable();
            dataGridManufacturer.Update();
        }

        public void UpdateDiseaseGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            dataGridDisease.DataSource = ServiceProvider.Get<BolestService>().GetDataTable();
            dataGridDisease.Update();
        }

        public void UpdatePackageGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            if (radioButtonPacakageSirup.Checked)
                dataGridPackage.DataSource = ServiceProvider.Get<SirupService>().GetDataTable();
            else if (radioButtonPackagePrasak.Checked)
                dataGridPackage.DataSource = ServiceProvider.Get<PrasakService>().GetDataTable();
            else if (radioButtonPackageInjekcija.Checked)
                dataGridPackage.DataSource = ServiceProvider.Get<InjekcijaService>().GetDataTable();
            else if (radioButtonPackageTableta.Checked)
                dataGridPackage.DataSource = ServiceProvider.Get<TabletaService>().GetDataTable();
            else
                dataGridPackage.DataSource = ServiceProvider.Get<PakovanjeService>().GetDataTable();
            dataGridPackage.Update();
        }

        public void UpdateDrugStoreGrid(object sender = null, EventArgs e = null)
        {
            UpdateGridClickEvent();
            dataGridDrugStore.DataSource = ServiceProvider.Get<ProdajnoMestoService>().GetDataTable();
            dataGridDrugStore.Update();
        }

        #endregion

        #region Remove Click event

        private void buttonDrugRemove_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value = int.Parse((string) dataGridDrugs.Rows[dataGridDrugs.SelectedRows[0].Index].Cells[0].Value);

            ServiceProvider.Get<LekService>().Delete(value);
            UpdateDrugGrid();
            UpdateGridClickEvent();
        }

        private void buttonRemovePerscription_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value =
                int.Parse((string) dataGridPrescription.Rows[dataGridPrescription.SelectedRows[0].Index].Cells[0].Value);

            ServiceProvider.Get<ReceptService>().Delete(value);
            UpdatePrescriptionGrid();
            UpdateGridClickEvent();
        }

        private void buttonEmployeeRemove_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value = int.Parse((string) dataGridEmployee.Rows[dataGridEmployee.SelectedRows[0].Index].Cells[0].Value);
            ServiceProvider.Get<ZaposleniService>().Delete(value);
            UpdateEmployeeGrid();
            UpdateGridClickEvent();
        }

        private void buttonRemoveCustomer_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value = int.Parse((string) dataGridCustomer.Rows[dataGridCustomer.SelectedRows[0].Index].Cells[0].Value);
            ServiceProvider.Get<KupacService>().Delete(value);
            UpdateCustomerGrid();
            UpdateGridClickEvent();
        }

        private void buttonRemoveInstituton_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value =
                int.Parse((string) dataGridInstitution.Rows[dataGridInstitution.SelectedRows[0].Index].Cells[0].Value);
            ServiceProvider.Get<ApotekarskaUstanovaService>().Delete(value);
            UpdateInstitutionGrid();
            UpdateGridClickEvent();
        }

        private void buttonRemoveManufacturer_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value =
                int.Parse((string) dataGridManufacturer.Rows[dataGridManufacturer.SelectedRows[0].Index].Cells[0].Value);
            ServiceProvider.Get<ProizvodjacService>().Delete(value);
            UpdateManufacturerGrid();
            UpdateGridClickEvent();
        }

        private void buttonRemovDisease_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value = int.Parse((string) dataGridDisease.Rows[dataGridDisease.SelectedRows[0].Index].Cells[0].Value);
            ServiceProvider.Get<BolestService>().Delete(value);
            UpdateDiseaseGrid();
            UpdateGridClickEvent();
        }

        private void buttonRemovePackage_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value = int.Parse((string) dataGridPackage.Rows[dataGridPackage.SelectedRows[0].Index].Cells[0].Value);
            ServiceProvider.Get<PakovanjeService>().Delete(value);
            UpdateManufacturerGrid();
            UpdateGridClickEvent();
        }

        private void buttonRemoveDrugStore_Click(object sender, EventArgs e)
        {
            UpdateGridClickEvent();
            var dialogResult = MessageBox.Show(Constants.CheckMessageBoxText, Constants.CheckMessageBoxText,
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            var value =
                int.Parse((string) dataGridDrugStore.Rows[dataGridDrugStore.SelectedRows[0].Index].Cells[0].Value);
            ServiceProvider.Get<ProdajnoMestoService>().Delete(value);
            UpdateDrugStoreGrid();
            UpdateGridClickEvent();
        }

        #endregion

        #region Add Click event

        private void buttonDrugAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddDrugForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonPrescriptionAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddPrescriptionForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonEmployeeAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEmployeeForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonCustomerAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddCustomerForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonInstitutionAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddInstitutionForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonManufacturerAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddManufacturerForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonDiseaseAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddDiseaseForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonPackageAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddPackageForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        private void buttonDrugStoreAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddDrugStoreForm(this);
            addForm.BringToFront();
            addForm.Activate();
            addForm.Show();
        }

        #endregion

        #region Details Click event

        private void buttonDrugDetails_Click(object sender, EventArgs e)
        {
            DrugGridClickEvent();

            var value = int.Parse((string)dataGridDrugs.Rows[dataGridDrugs.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<LekService>().Get(value);

            var form = new AddDrugForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonPrescriptionDetails_Click(object sender, EventArgs e)
        {
            PrescriptionGridClickEvent();

            var value =
                int.Parse((string)dataGridPrescription.Rows[dataGridPrescription.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ReceptService>().Get(value);

            var form = new AddPrescriptionForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonEmployeeDetails_Click(object sender, EventArgs e)
        {
            EmployeeGridClickEvent();

            var value = int.Parse((string)dataGridEmployee.Rows[dataGridEmployee.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ZaposleniService>().Get(value);

            var form = new AddEmployeeForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonCustomerDetails_Click(object sender, EventArgs e)
        {
            CustomerGridClickEvent();

            var value = int.Parse((string)dataGridCustomer.Rows[dataGridCustomer.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<KupacService>().Get(value);

            var form = new AddCustomerForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonInstitutionDetails_Click(object sender, EventArgs e)
        {
            InstitutionGridClickEvent();

            var value =
                int.Parse((string)dataGridInstitution.Rows[dataGridInstitution.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ApotekarskaUstanovaService>().Get(value);

            var form = new AddInstitutionForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonManufacturerDetails_Click(object sender, EventArgs e)
        {
            ManufacturerGridClickEvent();

            var value =
                int.Parse((string)dataGridManufacturer.Rows[dataGridManufacturer.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ProizvodjacService>().Get(value);

            var form = new AddManufacturerForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonDiseaseDetails_Click(object sender, EventArgs e)
        {
            DiseaseGridClickEvent();

            var value = int.Parse((string)dataGridDisease.Rows[dataGridDisease.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<BolestService>().Get(value);    

            var form = new AddDiseaseForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonPackageDetails_Click(object sender, EventArgs e)
        {
            PackageGridClickEvent();

            var value =
                int.Parse((string)dataGridPackage.Rows[dataGridPackage.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<PakovanjeService>().Get(value);

            var form = new AddPackageForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        private void buttonDrugStoreDetails_Click(object sender, EventArgs e)
        {
            DrugStoreGridClickEvent();

            var value =
                int.Parse((string)dataGridDrugStore.Rows[dataGridDrugStore.SelectedRows[0].Index].Cells[0].Value);
            var obj = ServiceProvider.Get<ProdajnoMestoService>().Get(value);

            var form = new AddDrugStoreForm(this, obj, false, true);
            form.BringToFront();
            form.Activate();
            form.Show();
        }

        #endregion
    }
}