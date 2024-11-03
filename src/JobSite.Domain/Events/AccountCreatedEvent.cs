namespace JobSite.Domain.Events;

public class AccountCreatedEvent : BaseEvent
{
    public AccountCreatedEvent(Account account)
    {
        this.Account = account;
    }
    public Account Account { get; }
}