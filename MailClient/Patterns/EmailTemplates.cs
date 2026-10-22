using MailClient.Models;

namespace MailClient.Patterns;

public sealed class BusinessEmailTemplate : EmailTemplate
{
    protected override void PrepareHeader(EmailDraft draft)
    {
        draft.SetSubject("Деловое предложение о сотрудничестве");
        Console.WriteLine("[шаг] Подготовлена деловая шапка письма.");
    }

    protected override void PrepareBody(EmailDraft draft)
    {
        draft.SetBody(
            "Здравствуйте! Предлагаем обсудить условия совместного проекта. " +
            "Ждём вашего ответа.");
        Console.WriteLine("[шаг] Подготовлено официальное тело письма.");
    }

    protected override void PrepareSignature(EmailDraft draft)
    {
        draft.SetSignature("С уважением,\nИван Петров\nООО «Пример»");
        Console.WriteLine("[шаг] Добавлена деловая подпись.");
    }

    protected override void AddAttachments(EmailDraft draft)
    {
        draft.AddAttachment("commercial_offer.pdf");
        Console.WriteLine("[шаг] Добавлено вложение: commercial_offer.pdf.");
    }
}

public sealed class NewsletterEmailTemplate : EmailTemplate
{
    protected override void PrepareHeader(EmailDraft draft)
    {
        draft.SetSubject("Еженедельная рассылка новостей");
        Console.WriteLine("[шаг] Подготовлена шапка рассылки.");
    }

    protected override void PrepareBody(EmailDraft draft)
    {
        draft.SetBody(
            "В этом выпуске: обзор новых функций, советы по использованию и анонсы.");
        Console.WriteLine("[шаг] Подготовлено тело рассылки.");
    }

    protected override void PrepareSignature(EmailDraft draft)
    {
        draft.SetSignature("Команда рассылки\nЧтобы отписаться, ответьте словом STOP.");
        Console.WriteLine("[шаг] Добавлена подпись рассылки.");
    }

    protected override void AddAttachments(EmailDraft draft)
    {
        draft.AddAttachment("unsubscribe_info.txt");
        Console.WriteLine("[шаг] Добавлено вложение: unsubscribe_info.txt.");
    }
}

public sealed class InvitationEmailTemplate : EmailTemplate
{
    protected override void PrepareHeader(EmailDraft draft)
    {
        draft.SetSubject("Приглашение на мероприятие");
        Console.WriteLine("[шаг] Подготовлена шапка приглашения.");
    }

    protected override void PrepareBody(EmailDraft draft)
    {
        draft.SetBody(
            "Здравствуйте! Приглашаем вас на ежегодную конференцию. " +
            "Программа и схема проезда — во вложениях.");
        Console.WriteLine("[шаг] Подготовлено тело приглашения.");
    }

    protected override void PrepareSignature(EmailDraft draft)
    {
        draft.SetSignature("Оргкомитет конференции");
        Console.WriteLine("[шаг] Добавлена подпись оргкомитета.");
    }

    protected override void AddAttachments(EmailDraft draft)
    {
        draft.AddAttachment("agenda.pdf");
        draft.AddAttachment("map.png");
        Console.WriteLine("[шаг] Добавлены вложения: agenda.pdf, map.png.");
    }
}