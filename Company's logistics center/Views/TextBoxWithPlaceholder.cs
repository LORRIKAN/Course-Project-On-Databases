using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogisticsCenter.Views
{
    public class TextBoxWithPlaceholder : TextBox
    {
        public string Placeholder { get; set; }

        private char passwordChar;

        public bool IsEmpty()
        {
            if (this.Text.Equals(Placeholder) || this.Text.Equals(""))
                return true;
            return false;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            if (PasswordChar != 0)
            {
                passwordChar = PasswordChar;
                PasswordChar = (char)0;
            }
            Text = Placeholder;
            ForeColor = Color.Gray;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (Text.Equals(string.Empty))
            {
                SetPlaceholder();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (Text.Equals(Placeholder))
            {
                if (passwordChar != 0)
                {
                    PasswordChar = passwordChar;
                }
                Text = string.Empty;
                ForeColor = Color.Black;
            }
        }
    }
}