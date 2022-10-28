using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class AddManagerForm : Form
    {
        private readonly CitiesBL _citiesBl = new();
        private readonly ManagerBL _managersBl = new();

        private List<City> _cities = new();
        private readonly Manager? _manager;

        public AddManagerForm()
        {
            InitializeComponent();

            dtpBirthDate.MaxDate = DateTime.Today.AddYears(-16);
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-100);

            _manager = new Manager();
        }

        private async Task FillCitiesTable()
        {
            _cities = await _citiesBl.GetAllCitiesAsync();
            cbPlaceOfBirth.DataSource = _cities;
        }

        private async void AddManagerForm_Load(object sender, EventArgs e)
        {
            await FillCitiesTable();
            cbPlaceOfBirth.DisplayMember = "CityLocation";

            _manager.Id = await _managersBl.GetIdForNewManager();
            txtId.Value = _manager?.Id.ToString();
        }

        private async void btnAddCity_Click(object sender, EventArgs e)
        {
            Visible = false;

            using (var form = new AddCityForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                    await FillCitiesTable();
            }

            Visible = true;
        }

        private void cbPlaceOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (_manager?.City is null)
            {
                cbPlaceOfBirth.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                cbPlaceOfBirth.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
            btnClose.Visible = false;
        }

        private void dtpBirthDate_Validating(object sender, CancelEventArgs e)
        {
            if (_manager?.DateOfBirth.Year == 1)
            {
                dtpBirthDate.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                dtpBirthDate.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
            btnClose.Visible = false;
        }

        private void cbPlaceOfBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_manager is null) return;
            _manager.City = cbPlaceOfBirth.SelectedItem as City;
        }

        private async void btnAddManager_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            await _managersBl.AddManager(_manager);
            btnClose.Visible = true;
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            if (_manager is null) return;

            _manager.DateOfBirth = dtpBirthDate.Value.Date;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            _manager.FirstName = txtFirstName.Value;
            btnClose.Visible = false;
        }

        private void txtLastName_Validated_1(object sender, EventArgs e)
        {
            _manager.SecondName = txtLastName.Value;
            btnClose.Visible = false;
        }
    }
}