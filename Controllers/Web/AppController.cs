using Microsoft.AspNet.Mvc;
using TheWorld.Models.Repositorio.Interfaces;
using TheWorld.Services.Interfaces;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IViagemRepositorio _mundoRepositorio;

        public AppController(IEmailService emailService, IViagemRepositorio mundoRepositorio)
        {
            _emailService = emailService;
            _mundoRepositorio = mundoRepositorio;
        }

        public IActionResult Index()
        {
            var viagens = _mundoRepositorio.GetTodasViagens();

            return View(viagens);
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
            if (string.IsNullOrWhiteSpace(email))
                ModelState.AddModelError("", "Não foi possivel enviar o email, problema de configuração");

            if (!_emailService.SendMail(email, "", $"Contato da Pagina {model.Nome} ({model.Email})", model.Mensagem))
                return View();

            ModelState.Clear();
            ViewBag.Mensagem = "Email enviado, obrigado.";

            return View();
        }
    }

}
