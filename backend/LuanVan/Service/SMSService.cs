using LuanVan.Model;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace LuanVan.Service
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSettings _twilio;

        public SMSService( IOptionsMonitor<TwilioSettings> twilio) { 
            _twilio = twilio.CurrentValue;
        }
        public MessageResource Send(string moblieNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);
            var mediaUrl = new[] {
            new Uri("https://demo.twilio.com/owl.png")
            }.ToList();
            var result = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
                 mediaUrl: mediaUrl,
                to: new Twilio.Types.PhoneNumber(moblieNumber));
            return result;
        }
    }
}
