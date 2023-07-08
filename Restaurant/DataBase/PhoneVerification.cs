using Twilio;
using Twilio.Rest.Chat.V2;
using Twilio.Rest.Verify.V2.Service;

namespace Restaurant.DataBase
{
    public static partial class PhoneVerification
    {
        private const string accountSid = "AC2f540fa9f22669c5ca2ecc46e7ee7ae6";
        private const string authToken = "0c30ecb3ccbd73b7eebbb007f58efd8b";
        private const string ServiceSid = "VA7f8b4b43c28976c0597013c77b9537ee";

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

