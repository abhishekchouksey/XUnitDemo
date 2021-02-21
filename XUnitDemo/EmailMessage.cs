namespace XUnitDemo
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

        public EmailMessage(string to, string body)
        {
            To = to;
            Body = body;
        }

    }
}
