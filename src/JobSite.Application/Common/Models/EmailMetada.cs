namespace JobSite.Application.Common.Models;
public class EmailMetadata
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string AttachmentPath { get; set; }
    public EmailMetadata(string to, string subject, string body, string attachmentPath)
    {
        To = to;
        Subject = subject;
        Body = body;
        AttachmentPath = attachmentPath;
    }
}