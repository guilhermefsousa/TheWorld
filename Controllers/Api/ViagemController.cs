using System;
using System.Net;
using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using TheWorld.Models;
using TheWorld.Models.Repositorio.Interfaces;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Api
{
    [Route("api/viagens")]
    public class ViagemController : Controller
    {
        private readonly IViagemRepositorio _viagemRepositorio;

        public ViagemController(IViagemRepositorio viagemRepositorio)
        {
            _viagemRepositorio = viagemRepositorio;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_viagemRepositorio.GetTodasViagensComParadas());
        }

        [HttpPost]
        public JsonResult Post([FromBody]ViagemViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var novaViagem = Mapper.Map<Viagem>(vm);

                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(true);
                }
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Mensagem = "Falhou", ModalState = ModelState });
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {Mensagem = ex.Message});
            }
            
        }

    }
}