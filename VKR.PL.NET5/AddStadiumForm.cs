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
    public partial class AddStadiumForm : Form
    {
        private readonly CitiesBL _citiesBl = new();
        private readonly StadiumsBL _stadiumBl = new();

        private List<City> _cities;
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
            cbPlaceOfBirth.DataSource = _cities;

            cbPlaceOfBirth.DisplayMember = "CityLocation";
            cbPlaceOfBirth.ValueMember = "Id";
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

        private void cbPlaceOfBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_stadium is null) return;

            _stadium.StadiumCity = cbPlaceOfBirth.SelectedItem as City;
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

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            await _stadiumBl.AddNewStadium(_stadium);
            DialogResult = DialogResult.OK;
        }

        private void cbPlaceOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (_stadium.StadiumCity is null)
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

        private async void AddStadiumForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            await FillCitiesTable();
        }

        private void cbPlaceOfBirth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_stadium is null) return;
            _stadium.StadiumLocation = (short)cbPlaceOfBirth.SelectedValue;
        }
    }
}