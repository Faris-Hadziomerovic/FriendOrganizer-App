namespace FriendOrganizer.UI.Views.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResults ShowDialog_OK_Cancle(string displayMessage, string title);
    }
}