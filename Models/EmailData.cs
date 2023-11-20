namespace EmailAPI.Models
{
    public class EmailData
    {
        //public IList<EmailPara> EmailPara { get; set; } = new List<EmailPara>();
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        public IFormFileCollection? EmailAttachments { get; set; }
    }
}
