﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities.Tables;
using VKR.PL.Utils.NET5;

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
            cbPlaceOfBirth.DisplayMember = "CityLocation";
            cbPlaceOfBirth.ValueMember = "Id";
        }

        private async void AddManagerForm_Load(object sender, EventArgs e)
        {
            _manager.Id = await _managersBl.GetIdForNewManager();
            txtId.Value = _manager?.Id.ToString();
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            Visible = false;

            using (var form = new AddCityForm()) 
                form.ShowDialog();

            Visible = true;
        }

        private void cbPlaceOfBirth_Validating(object sender, CancelEventArgs e) => cbPlaceOfBirth.ValidateComboBox(e);

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
        }

        private async void btnAddManager_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            await _managersBl.AddManager(_manager);
            DialogResult = DialogResult.OK;
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            if (_manager is null) return;
            _manager.DateOfBirth = dtpBirthDate.Value.Date;
        }

        private void txtFirstName_Validated(object sender, EventArgs e) => _manager.FirstName = txtFirstName.Value;

        private void txtLastName_Validated_1(object sender, EventArgs e) => _manager.SecondName = txtLastName.Value;

        private async void AddManagerForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            await FillCitiesTable();
        }

        private void cbPlaceOfBirth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_manager is null) return; 
            _manager.PlaceOfBirth = (short)cbPlaceOfBirth.SelectedValue;
        }
    }
}