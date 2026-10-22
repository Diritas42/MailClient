namespace MailClient.Models;
public sealed class EmailMemento
{
    internal string Subject { get; }
    internal string Body { get; }
    internal string Signature { get; }
    internal IReadOnlyList<string> Attachments { get; }

    internal EmailMemento(
        string subject,
        string body,
        string signature,
        IEnumerable<string> attachments)
    {
        Subject = subject;
        Body = body;
        Signature = signature;
        Attachments = attachments.ToArray();
    }
}