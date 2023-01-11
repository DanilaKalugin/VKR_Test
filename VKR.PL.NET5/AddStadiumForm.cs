using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities.Tables;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class AddStadiumForm : Form
    {
        private readonly CitiesBL _citiesBl = new();
        private readonly StadiumsBL _stadiumBl = new();

        private List<City> _cities = new();
        private readonly Stadium _stadium;

        public AddStadiumForm()
        {
            InitializeComponent();

            _stadium = new Stadium
            {
                StadiumFactor = new StadiumFactor()
            };
        }

        private async Task FillCitiesTable()
        {
            _cities = await _citiesBl.GetAllCitiesAsync();
            cbStadiumLocation.DataSource = _cities;

            cbStadiumLocation.DisplayMember = "CityLocation";
            cbStadiumLocation.ValueMember = "Id";
        }

        private async void AddStadiumForm_Load(object sender, EventArgs e)
        {
            await FillCitiesTable();
            var stadiumId = await _stadiumBl.GetIdForNewStadium();
            _stadium.StadiumId = stadiumId;
            _stadium.StadiumFactor.StadiumId = stadiumId;
            txtId.Value = stadiumId.ToString();
        }

        private void txtStadiumName_Validated(object sender, EventArgs e)
        {
            if (_stadium is null) return;
            _stadium.StadiumTitle = txtStadiumName.Value;
        }

        private void numPlayerNumber_ValueChanged(object sender, EventArgs e)
        {
            if (_stadium is null) return;
            _stadium.StadiumCapacity = (uint)numPlayerNumber.Value;
        }

        private void numMaxWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_stadium is null) return;
            _stadium.StadiumDistanceToCenterfield = (ushort)numMaxWidth.Value;
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            Visible = false;

            using (var form = new AddCityForm()) 
                form.ShowDialog();

            Visible = true;
        }

        private async void btnAddStadium_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            await _stadiumBl.AddNewStadium(_stadium);
            DialogResult = DialogResult.OK;
        }

        private void cbStadiumLocation_Validating(object sender, CancelEventArgs e) => cbStadiumLocation.ValidateComboBox(e);

        private async void AddStadiumForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            await FillCitiesTable();
        }

        private void cbStadiumLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_stadium is null) return;
            _stadium.StadiumLocation = (short)cbStadiumLocation.SelectedValue;
        }
    }
}