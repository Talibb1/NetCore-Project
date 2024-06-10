namespace Service.Helper.Abstract
{
    public interface ISendEmailHelper
    {
        Task SendEmail(string resetLink, string userEmail);
    }
}