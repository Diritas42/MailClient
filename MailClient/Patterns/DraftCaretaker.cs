using MailClient.Models;

namespace MailClient.Patterns;
public sealed class DraftCaretaker
{
    private readonly Stack<EmailMemento> _history = new();

    public int Count => _history.Count;

    public void Save(EmailDraft draft)
    {
        ArgumentNullException.ThrowIfNull(draft);

        _history.Push(draft.Save());
        Console.WriteLine($"[DraftCaretaker] Черновик сохранён. Снимков в истории: {_history.Count}.");
    }

    public bool RestoreLast(EmailDraft draft)
    {
        ArgumentNullException.ThrowIfNull(draft);

        if (_history.Count == 0)
        {
            Console.WriteLine("[DraftCaretaker] Нет сохранённых снимков.");
            return false;
        }

        var memento = _history.Pop();
        draft.Restore(memento);

        Console.WriteLine($"[DraftCaretaker] Восстановлен последний снимок. Осталось снимков: {_history.Count}.");
        return true;
    }
}