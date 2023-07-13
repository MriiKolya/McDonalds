using Twilio;
using Twilio.Rest.Chat.V2;
using Twilio.Rest.Verify.V2.Service;

namespace Restaurant.DataBase
{
    public static partial class PhoneVerification
    {
        private const string accountSid = "AC557245bd757bc86beeae7e9220e6e1f8";
        private const string authToken = "f741ba336553bceb7633265d9b54d796";
        private const string ServiceSid = "VAdaaa76f0dd6cf08f257ec1438e12a405";

        public static void SendCodeDB(string PhoneNumber)
        {
            TwilioClient.Init(accountSid, authToken);
            var service = ServiceResource.Create(friendlyName: "My Verify Service");
            var verification = VerificationResource.Create(
            to: PhoneNumber,
            channel: "sms",
            pathServiceSid: ServiceSid
        );
            Console.WriteLine(verification.Status);
        }
        public static string CheckUser(string PhoneNumber,string Code)
        {
            TwilioClient.Init(accountSid, authToken);
            var verificationCheck = VerificationCheckResource.Create(
                to: PhoneNumber,
                code: Code,
                pathServiceSid: ServiceSid
            );
            Console.WriteLine(verificationCheck.Status);
            return verificationCheck.Status;
        }
    }
}

