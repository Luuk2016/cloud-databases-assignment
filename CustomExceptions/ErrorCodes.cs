
namespace LKenselaar.CloudDatabases.CustomExceptions
{
    public class ErrorCodes
    {
        public static class MortgageExpired
        {
            public static string Key => "MortgageExpired";
            public static string Value => "The requested mortgage has been expired, please create a new one.";
        }

        public static class MailNotSend
        {
            public static string Key => "MailNotSend";
            public static string Value => "The email couldn't be send.";
        }
    }
}