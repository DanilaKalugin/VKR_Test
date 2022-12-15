using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VKR.PL.Controls.NET5
{
    public partial class TextBoxWithHeader : UserControl
    {
        private string? _header;
        private ushort _valuePosition;
        private string? _value;
        private bool _readOnlyControl;
        private bool _mayIncludeNumbers;
        private ushort _maxLength = ushort.MaxValue;

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

                _valuePosition = value;
                var args = new ValuePositionChangedEventArgs(value);
                ValuePositionChanged(this, args);
            }
        }

        public bool ReadOnlyControl
        {
            get => _readOnlyControl;
            set
            {
                _readOnlyControl = value;

                txtLastName.Enabled = !value;
                Height = value ? 26 : 46;
                txtLastName.Cursor = _readOnlyControl ? Cursors.Default : Cursors.IBeam;
            }
        }

        public bool MayIncludeNumbers
        {
            get => _mayIncludeNumbers;
            set
            {
                _mayIncludeNumbers = value;
                Invalidate();
            }
        }

        public ushort MaxLength
        {
            get => _maxLength;
            set
            {
                _maxLength = value;
                txtLastName.MaxLength = value;
            }
        }


        internal event EventHandler<ValuePositionChangedEventArgs> ValuePositionChanged; 

        public TextBoxWithHeader()
        {
            InitializeComponent();
            ValuePositionChanged += OnValuePositionChanged;
        }

        private void OnValuePositionChanged(object? sender, ValuePositionChangedEventArgs e)
        {
            txtLastName.Left = e.Position;
            txtLastName.Width = Width - e.Position;

            lbHint.Left = e.Position;
            lbHint.Width = Width - e.Position;
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (ReadOnlyControl) return;

            var text = txtLastName.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                txtLastName.BackColor = Color.DarkRed;
                e.Cancel = true;

                lbHint.Text = $"\"{Header}\" cannot be empty";
                lbHint.ForeColor = Color.DarkRed;

                return;
            }

            if (!MayIncludeNumbers && txtLastName.Text.Any(char.IsDigit))
            {
                txtLastName.BackColor = Color.DarkRed;
                e.Cancel = true;

                lbHint.Text = $"\"{Header}\" can't include numbers";
                lbHint.ForeColor = Color.DarkRed;

                return;
            }

            txtLastName.BackColor = Color.WhiteSmoke;
            e.Cancel = false;

            lbHint.Text = string.Empty;
            lbHint.ForeColor = Color.Green;
        }

        private void txtLastName_Validated(object sender, EventArgs e) => Value = txtLastName.Text.Trim();
    }
}