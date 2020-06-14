using LogisticsCenter.Views.MessageService;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DiagnosticAdapter;
using System;

namespace LogisticsCenter.Presenters
{
    public class RepositoryHandler
    {
        IMessageService MessageService { get; set; }

        public RepositoryHandler(IMessageService messageService)
        {
            MessageService = messageService;
        }

        [DiagnosticName("Microsoft.EntityFrameworkCore.Database.Command.CommandError")]
        public void OnCommandError(Exception exception, bool async)
        {
            if (((SqliteException)exception).SqliteErrorCode == 1)
            {
                MessageService.ShowError($"При обращении к базе данных было вызвано исключение {exception.Message} " +
                    $"Это произошло из-за модификации базы данных вне этой программы или её удаления " +
                    $"или перемещения. Программа не может продолжать свою работу.");
                Environment.Exit(1);
            }
        }
    }
}