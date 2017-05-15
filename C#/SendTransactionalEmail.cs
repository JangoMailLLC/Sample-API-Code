using System;
using System.IO;

namespace JangoMailAPIExample
{
    /// <summary>
    /// JangoMail API Example Code
    /// To use this example, add a Service Reference to https://api.jangomail.com/api.asmx?WSDL as JangoMailService.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Sample code to execute SendTransactionalEmail method
        /// </summary>
        static void Main(string[] args)
        {
            JangoMailService.JangoMailSoapClient client = new JangoMailService.JangoMailSoapClient("JangoMailSoap");

            string response = client.SendTransactionalEmail(
                "Username",
                "Password",
                "FromEmail",
                "FromName",
                "ToEmailAddress",
                "Subject",
                "MessagePlain",
                "MessageHTML",
                "Options");

            Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}