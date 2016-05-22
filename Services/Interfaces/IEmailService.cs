namespace TheWorld.Services.Interfaces
{
    public interface IEmailService
    {
        bool SendMail(string para, string de, string assunto, string corpo);
    }
}   