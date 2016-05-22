using Microsoft.AspNet.Mvc;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IEmailService _emailService;

        public AppController(IEmailService emailService)
         {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato(ContatoViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var email = Startup.Configuracao["AppConfiguracoes:EnderecoEmail"];
            if(string.IsNullOrWhiteSpace(email))
                ModelState.AddModelError("","Não foi possivel enviar o email, problema de configuração");

            if (!_emailService.SendMail(email, "", $"Contato da Pagina {model.Nome} ({model.Email})", model.Mensagem))
                return View();

            ModelState.Clear();
            ViewBag.Mensagem = "Email enviado, obrigado.";

            return View();
        }
    }

}
