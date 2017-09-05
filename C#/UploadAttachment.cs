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
        /// Sample code to execute UploadAttachment* methods
        /// </summary>
        static void Main(string[] args)
        {
            string response = UploadAttachmentFromFile("USERNAME", "PASSWORD", @"C:\TextTest.txt", "TextTest.txt", false);
            Console.WriteLine(response);

            Console.ReadKey();
        }

        /// <summary>
        /// Upload Attachment to JangoMail, specifying the path to a local file.
        /// </summary>
        /// <param name="username">Your JangoMail Username</param>
        /// <param name="password">Your JangoMail Password</param>
        /// <param name="localFilename">Full path to the local file</param>
        /// <param name="targetFilename">Name of file to store with JangoMail</param>
        /// <param name="overwriteExistingFile">If yes, overwrites the file if it already exists</param>
        /// <returns>String representing API response</returns>
        public static string UploadAttachmentFromFile(string username, string password, string localFilename, string targetFilename, bool overwriteExistingFile)
        {
            // Load local file
            using (FileStream fileStream = File.OpenRead(localFilename))
            {
                MemoryStream stream = new MemoryStream();
                stream.SetLength(fileStream.Length);
                fileStream.Read(stream.GetBuffer(), 0, (int)fileStream.Length);

                return UploadAttachmentFromMemoryStream(username, password, stream, targetFilename, overwriteExistingFile);
            }
        }

        /// <summary>
        /// Upload Attachment to JangoMail using a Memory Stream.
        /// </summary>
        /// <param name="username">Your JangoMail Username</param>
        /// <param name="password">Your JangoMail Password</param>
        /// <param name="stream">MemoryStream object</param>
        /// <param name="targetFilename">Name of file to store with JangoMail</param>
        /// <param name="overwriteExistingFile">If yes, overwrites the file if it already exists</param>
        /// <returns>String representing API response</returns>
        public static string UploadAttachmentFromMemoryStream(string username, string password, MemoryStream stream, string targetFilename, bool overwriteExistingFile)
        {
            JangoMailService.JangoMailSoapClient client = new JangoMailService.JangoMailSoapClient("JangoMailSoap");

            string response = client.UploadAttachment(
                    username,
                    password,
                    stream.GetBuffer(),
                    targetFilename,
                    overwriteExistingFile);

            return response;
        }
    }
}
