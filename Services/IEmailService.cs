namespace TheWorld.Services
{
    public interface IEmailService
    {
        bool SendMail(string para, string de, string assunto, string corpo);
    }
}   