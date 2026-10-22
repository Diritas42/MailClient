namespace MailClient.Models;
public sealed class EmailDraft
{
    private readonly List<string> _attachments = new();

    public string Subject { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public string Signature { get; private set; } = string.Empty;
    public IReadOnlyList<string> Attachments => _attachments;

    public void SetSubject(string subject)
    {
        Subject = subject ?? string.Empty;
    }

    public void SetBody(string body)
    {
        Body = body ?? string.Empty;
    }

    public void SetSignature(string signature)
    {
        Signature = signature ?? string.Empty;
    }

    public void AddAttachment(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("Имя вложения не может быть пустым", nameof(fileName));

        _attachments.Add(fileName);
    }

    public void ClearAttachments()
    {
        _attachments.Clear();
    }
    public EmailMemento Save()
    {
        Console.WriteLine("[EmailDraft] Создан снимок черновика.");
        return new EmailMemento(Subject, Body, Signature, _attachments);
    }
    public void Restore(EmailMemento memento)
    {
        ArgumentNullException.ThrowIfNull(memento);

        Subject = memento.Subject;
        Body = memento.Body;
        Signature = memento.Signature;

        _attachments.Clear();
        _attachments.AddRange(memento.Attachments);

        Console.WriteLine("[EmailDraft] Состояние черновика восстановлено из снимка.");
    }

    public override string ToString()
    {
        var attachments = _attachments.Count == 0
            ? "нет"
            : string.Join(", ", _attachments);

        return $"Тема: {Subject}\nТело: {Body}\nПодпись: {Signature}\nВложения: {attachments}";
    }
}