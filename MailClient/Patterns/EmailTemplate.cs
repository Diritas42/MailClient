using MailClient.Models;

namespace MailClient.Patterns;
public abstract class EmailTemplate
{
    public void PrepareAndSend(EmailDraft draft)
    {
        ArgumentNullException.ThrowIfNull(draft);

        Console.WriteLine($"\nПодготовка письма: {GetType().Name}");

        PrepareHeader(draft);
        PrepareBody(draft);
        PrepareSignature(draft);
        AddAttachments(draft);
        Send(draft);
    }

    protected abstract void PrepareHeader(EmailDraft draft);

    protected abstract void PrepareBody(EmailDraft draft);

    protected virtual void PrepareSignature(EmailDraft draft)
    {
        draft.SetSignature("С уважением,\nредакция MailClient");
        Console.WriteLine("[шаг] Добавлена стандартная подпись.");
    }

    protected virtual void AddAttachments(EmailDraft draft)
    {
        Console.WriteLine("[шаг] Дополнительные вложения не требуются.");
    }

    private void Send(EmailDraft draft)
    {
        Console.WriteLine("[шаг] Отправка письма...");
        Console.WriteLine(draft);
        Console.WriteLine("Письмо отправлено.");
    }
}