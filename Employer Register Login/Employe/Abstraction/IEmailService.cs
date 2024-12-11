using Humanizer;

namespace Employe.Abstraction
{
    public interface IEmailService
    {
        void SendEmail(string toUser);
        void SendEmailConfirm(string toUser, string confirmUrl);
    }
}
