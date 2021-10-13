using System.Collections.Generic;

namespace ProjectName.Notification.Models
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            FromAddresses = new List<EmailAddress>();
            ToAddresses = new List<EmailAddress>();
        }
        public List<EmailAddress> FromAddresses { get; set; }
        public List<EmailAddress> ToAddresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
