using System;
using System.ComponentModel;
using System.Windows.Forms;
using VKR.PL.Utils.NET5;

namespace VKR.PL.Controls.NET5
{
    public partial class TextBoxWithHeader : UserControl
    {
        private string? _header;
        private ushort _valuePosition;
        private string? _value;
        private bool _readOnlyControl;

        public string? Header
        {
            get => _header;
            set
            {
                _header = value;
                label1.Text = $"{value}:";
            }
        }

        public string? Value
        {
            get => _value;
            set
            {
                _value = value;
                txtLastName.Text = value;
            }
        }

        public ushort ValuePosition
        {
            get => _valuePosition;
            set
            {
                if (value >= Width)
                    throw new ArgumentOutOfRangeException(nameof(value));

                txtLastName.Left = value;
                txtLastName.Width = Width - value;
                _valuePosition = value;
            }
        }

        public bool ReadOnlyControl
        {
            get => _readOnlyControl;
            set
            {
                _readOnlyControl = value;
                txtLastName.Enabled = !value;
            }
        }

        public TextBoxWithHeader() => InitializeComponent();

        private void txtLastName_Validating(object sender, CancelEventArgs e) => ControlValidator.TextBoxValidating(sender as Control, e);

        private void txtLastName_Validated(object sender, EventArgs e) => Value = txtLastName.Text.Trim();
    }
}