using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using Region = VKR.EF.Entities.Region;

namespace VKR.PL.NET5
{
    public partial class AddCityForm : Form
    {
        private readonly CitiesBL _citiesBl = new();
        private readonly List<Region> _regions;
        private readonly City _city = new();

        public AddCityForm()
        {
            InitializeComponent();
            _regions = _citiesBl.GetAllRegions().OrderBy(r => r.ToString()).ToList();
            cbPlaceOfBirth.DataSource = _regions;
            cbPlaceOfBirth.DisplayMember = "RegionLocation";
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e) => TextBoxValidating(txtFirstName, e);

        private static void TextBoxValidating(Control control, CancelEventArgs e)
        {
            var text = control.Text.Trim();

            if (string.IsNullOrWhiteSpace(text) || text.Any(char.IsDigit))
            {
                control.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                control.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
        }

        private void txtFirstName_Validated(object sender, EventArgs e) => _city.Name = txtFirstName.Text.Trim();

        private void cbPlaceOfBirth_SelectedIndexChanged(object sender, EventArgs e) => _city.Region = cbPlaceOfBirth.SelectedItem as Region;

        private void AddCityForm_Validating(object sender, CancelEventArgs e)
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
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren() || !Validate()) return;

            _citiesBl.AddCity(_city);
            DialogResult = DialogResult.OK;
        }
    }
}
