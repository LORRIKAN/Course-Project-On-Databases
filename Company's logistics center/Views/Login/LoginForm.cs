using LogisticsCenter.Views.MessageService;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Login
{
    public partial class LoginForm : Form, ILoginForm
    {
        LoginAttemptResult loginAttemptResult = new LoginAttemptResult();

        IMessageService MessageService { get; set; }
        public LoginForm(IMessageService messageService)
        {
            InitializeComponent();
            MessageService = messageService;
            this.FormClosed += (sender, e) => OnFormClosed?.Invoke(loginAttemptResult);

            void IfEnterKeyPressed(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter)
                    LoginAttempt();
            }

            loginTextBox.KeyPress += (sender, e) => IfEnterKeyPressed(sender, e);
            passwordTextBox.KeyPress += (sender, e) => IfEnterKeyPressed(sender, e);

            enterButton.Click += (sender, e) => LoginAttempt();
        }

        public new void Show() => Application.Run(this);

        private void LoginAttempt()
        {
            if (loginTextBox.IsEmpty() || passwordTextBox.IsEmpty())
                return;

            loginTextBox.Enabled = false;
            passwordTextBox.Enabled = false;

            enterButton.Enabled = false;

            loginAttemptResult = OnLoginAttempt?.Invoke(loginTextBox.Text, passwordTextBox.Text)
                ?? new LoginAttemptResult();

            if (loginAttemptResult == LoginResults.Success)
            {
                this.Close();
            }
            else
            {
                if (loginAttemptResult == LoginResults.failedNoAttemt)
                    MessageService.ShowError("Не была выполнена попытка проверки данных (программная ошибка)." +
                        "Обратитесь к разработчикам программы.");
                else if (loginAttemptResult == LoginResults.failedWrongLogin)
                    MessageService.ShowError("Такой пары логина/пароля нет!");
                else if (loginAttemptResult == LoginResults.failedWrongPassword)
                    MessageService.ShowError("Неверный пароль!");

                loginTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                loginTextBox.Focus();

                enterButton.Enabled = true;
            }
        }

        #region Events
        public event LoginAttempt OnLoginAttempt;

        public new event FormClosed OnFormClosed;
        #endregion

        private void loginPicture_Click(object sender, System.EventArgs e)
        {

        }

        private void enterButton_Click(object sender, System.EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}