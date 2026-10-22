using System.Globalization;
using System.Text;
using MailClient.Models;
using MailClient.Patterns;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");

Console.WriteLine("ДЕМО 1: Template Method — разные типы писем с общим порядком шагов");

var businessDraft = new EmailDraft();
new BusinessEmailTemplate().PrepareAndSend(businessDraft);

var newsletterDraft = new EmailDraft();
new NewsletterEmailTemplate().PrepareAndSend(newsletterDraft);

var invitationDraft = new EmailDraft();
new InvitationEmailTemplate().PrepareAndSend(invitationDraft);

Console.WriteLine("\nДЕМО 2: Memento — сохранение и восстановление черновика");

var draft = new EmailDraft();
var caretaker = new DraftCaretaker();

draft.SetSubject("Черновик приглашения");
draft.SetBody("Здравствуйте! Приглашаем вас на встречу.");
draft.SetSignature("Оргкомитет");

Console.WriteLine("\nЧерновик до сохранения:");
Console.WriteLine(draft);

caretaker.Save(draft);

draft.SetBody("Здравствуйте! Приглашаем вас на встречу 15 мая. Программа будет позже.");
draft.AddAttachment("agenda_v1.pdf");

Console.WriteLine("\nЧерновик после изменений:");
Console.WriteLine(draft);

caretaker.Save(draft);

draft.SetBody("Совсем другой текст, который не должен остаться после отката.");
draft.AddAttachment("wrong_file.tmp");

Console.WriteLine("\nЧерновик после ошибочных правок:");
Console.WriteLine(draft);

caretaker.RestoreLast(draft);

Console.WriteLine("\nПосле восстановления последнего снимка:");
Console.WriteLine(draft);

caretaker.RestoreLast(draft);

Console.WriteLine("\nПосле восстановления более раннего снимка:");
Console.WriteLine(draft);

Console.WriteLine("\nГотово. Нажмите Enter для выхода.");
Console.ReadLine();