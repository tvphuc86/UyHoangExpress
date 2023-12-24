using Twilio.Rest.Api.V2010.Account;

namespace LuanVan.Service
{
    public interface ISMSService
    {
        MessageResource Send(string moblieNumber, string body);
    }
}
