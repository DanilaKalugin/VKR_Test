using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.EF.Entities.Tables;
using VKR.PL.Utils.NET5;

namespace VKR.PL.Controls.NET5
{
    public partial class ManagerInfo : UserControl
    {
        private Manager? _manager;

        public Manager? Manager
        {
            get => _manager;
            set
            {
                _manager = value;
                ManagerChanged(_manager);

            }
        }

        public ManagerInfo()
        {
            InitializeComponent();
        }

        private void ManagerChanged(Manager? teamManager)
        {
            lbManagerName.Text = teamManager?.FullName ?? string.Empty;
            lbManagerDateOfBirth.Text = teamManager?.DateOfBirth.ToShortDateString() ?? string.Empty;
            lbManagerPlaceOfBirth.Text = teamManager?.City.CityLocation ?? string.Empty;
            pbManagerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/Managers/Manager{teamManager?.Id:000}.jpg");
        }
    }
}
