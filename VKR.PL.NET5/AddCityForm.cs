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

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            await _citiesBl.AddCityAsync(_city);
            DialogResult = DialogResult.OK;
        }

        private async void AddCityForm_Load(object sender, EventArgs e)
        {
            var regions = await _citiesBl.GetAllRegions();
            _regions = regions.OrderBy(r => r.ToString()).ToList();
            cbCityRegion.DataSource = _regions;
            cbCityRegion.DisplayMember = "RegionLocation";
            cbCityRegion.ValueMember = "RegionCode";
        }

        private void cbPlaceOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (cbCityRegion.SelectedValue is null)
            {
                cbCityRegion.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                cbCityRegion.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
        }

        private void txtCityName_Validated(object sender, EventArgs e) => _city.Name = txtCityName.Value;

        private void cbCityRegion_SelectionChangeCommitted(object sender, EventArgs e) => _city.RegionCode = (string)cbCityRegion.SelectedValue;
    }
}