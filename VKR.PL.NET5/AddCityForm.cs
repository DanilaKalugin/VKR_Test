using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using Region = VKR.EF.Entities.Region;

namespace VKR.PL.NET5
{
    public partial class AddCityForm : Form
    {
        private readonly CitiesBL _citiesBl = new();
        private List<Region> _regions;
        private readonly City _city = new();

        public AddCityForm() => InitializeComponent();

        private void cbPlaceOfBirth_SelectedIndexChanged(object sender, EventArgs e) => _city.Region = cbPlaceOfBirth.SelectedItem as Region;

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            await _citiesBl.AddCityAsync(_city);
            btnClose.Visible = true;
        }

        private async void AddCityForm_Load(object sender, EventArgs e)
        {
            var regions = await _citiesBl.GetAllRegions();
            _regions = regions.OrderBy(r => r.ToString()).ToList();
            cbPlaceOfBirth.DataSource = _regions;
            cbPlaceOfBirth.DisplayMember = "RegionLocation";
        }

        private void btnClose_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void cbPlaceOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (_city.Region is null)
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

        private void txtCityName_Validated(object sender, EventArgs e)
        {
            _city.Name = txtCityName.Value;
            btnClose.Visible = false;
        }
    }
}