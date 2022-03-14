using PersonalWebsite.Models;

namespace PersonalWebsite.Domain
{
    public interface IEmail
    {
        void SendContactMeEmail(EmailContact emailContactInfo);
    }
}
