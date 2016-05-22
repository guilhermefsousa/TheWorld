using System.Diagnostics;

namespace TheWorld.Services
{
    public class DebugEmailService : IEmailService
    {
        public bool SendMail(string para, string de, string assunto, string corpo)
        {
            Debug.WriteLine($"Enviando email: para: {para}, Assunto:{assunto}");
            return true;
        }
    }
}