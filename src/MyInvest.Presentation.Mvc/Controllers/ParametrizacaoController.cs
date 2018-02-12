using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Services;
using MyInvest.Presentation.Mvc.ViewModels;

namespace MyInvest.Presentation.Mvc.Controllers
{
    public class ParametrizacaoController : Controller
    {
        private readonly ITipoInvestimentoService _tipoInvestimentoService;

        public ParametrizacaoController(ITipoInvestimentoService tipoInvestimentoService)
        {
            _tipoInvestimentoService = tipoInvestimentoService;
        }

        [Route("Parametrizacao/TipoInvestimento")]
        [Route("Parametrizacao/TipoInvestimento/Index")]
        public ActionResult IndexTipoInvestimento()
        {
            var model = _tipoInvestimentoService.GetAll().ToList();

            return View("IndexTipoInvestimento", model);
        }

        [Route("Parametrizacao/TipoInvestimento/Novo")]
        public ActionResult NovoTipoInvestimento()
        {
            return View("FormTipoInvestimento", new TipoInvestimentoViewModel());
        }

        [Route("Parametrizacao/TipoInvestimento/Editar/{id:long}")]
        public ActionResult EditarTipoInvestimento(long id)
        {
            var data = _tipoInvestimentoService.GetById(id);

            if (data == null)
                return HttpNotFound();

            var model = Mapper.Map<TipoInvestimento, TipoInvestimentoViewModel>(data);

            return View("FormTipoInvestimento", model);
        }

        [Route("Parametrizacao/TipoInvestimento/Excluir/{id:long}")]
        public ActionResult ExcluirTipoInvestimento(long id)
        {
            var data = _tipoInvestimentoService.GetById(id);

            if (data == null)
                return HttpNotFound();

            var model = Mapper.Map<TipoInvestimento, TipoInvestimentoViewModel>(data);

            ViewBag.Title = "Exclusão de Tipo de Investimento";
            ViewBag.Message = "Deseja realmente excluir o Tipo de Investimento abaixo?";

            return View("DeleteTipoInvestimento", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Parametrizacao/TipoInvestimento/Salvar")]
        public ActionResult SalvarTipoInvestimento(TipoInvestimentoViewModel model)
        {
            if (!ModelState.IsValid)
                return View("FormTipoInvestimento", model);

            var data = Mapper.Map<TipoInvestimentoViewModel, TipoInvestimento>(model);

            if (model.CodTipoInvestimento == 0)
            {
                _tipoInvestimentoService.Add(data);
            }
            else
            {
                _tipoInvestimentoService.Update(data);
            }

            return RedirectToAction("IndexTipoInvestimento");
        }

        [HttpPost]
        [Route("Parametrizacao/TipoInvestimento/ConfirmaExcluir/{id:long}")]
        public JsonResult ConfirmaExclusaoTipoInvestimento(long id)
        {
            bool sucesso;

            try
            {
                var data = _tipoInvestimentoService.GetById(id);

                _tipoInvestimentoService.Remove(data);

                sucesso = true;
            }
            catch (Exception)
            {
                sucesso = false;
            }

            return Json(sucesso);
        }
    }
}