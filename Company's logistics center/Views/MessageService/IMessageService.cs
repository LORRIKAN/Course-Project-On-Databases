namespace LogisticsCenter.Views.MessageService
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
        bool ShowOkCancel(string message);
    }
}