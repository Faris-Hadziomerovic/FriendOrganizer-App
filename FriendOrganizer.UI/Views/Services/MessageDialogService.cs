using System.Windows;

namespace FriendOrganizer.UI.Views.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResults ShowDialog_OK_Cancle(string displayMessage, string title)
        {
            var results = MessageBox.Show(displayMessage, title, MessageBoxButton.OKCancel);

            return (results == MessageBoxResult.OK) ?
                MessageDialogResults.OK :       // true
                MessageDialogResults.Cancel;   // false
        }
    }
    public enum MessageDialogResults
    {
        OK,
        Cancel
    }
}
