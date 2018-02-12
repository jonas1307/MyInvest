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
        private readonly ITipoInstituicaoFinanceiraService _tipoInstituicaoFinanceiraService;

        public ParametrizacaoController(ITipoInvestimentoService tipoInvestimentoService, ITipoInstituicaoFinanceiraService tipoInstituicaoFinanceiraService)
        {
            _tipoInvestimentoService = tipoInvestimentoService;
            _tipoInstituicaoFinanceiraService = tipoInstituicaoFinanceiraService;
        }

        [Route("Parametrizacao/TipoInstituicaoFinanceira")]
        [Route("Parametrizacao/TipoInstituicaoFinanceira/Index")]
        public ActionResult IndexTipoInstituicaoFinanceira()
        {
            var model = _tipoInstituicaoFinanceiraService.GetAll().ToList();

            return View("IndexTipoInstituicao", model);
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

        [Route("Parametrizacao/TipoInstituicaoFinanceira/Novo")]
        public ActionResult NovoTipoInstituicao()
        {
            return View("FormTipoInstituicao", new TipoInstituicaoFinanceiraViewModel());
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

        [Route("Parametrizacao/TipoInstituicaoFinanceira/Editar/{id:long}")]
        public ActionResult EditarTipoInstituicao(long id)
        {
            var data = _tipoInstituicaoFinanceiraService.GetById(id);

            if (data == null)
                return HttpNotFound();

            var model = Mapper.Map<TipoInstituicaoFinanceira, TipoInstituicaoFinanceiraViewModel>(data);

            return View("FormTipoInstituicao", model);
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

        [Route("Parametrizacao/TipoInstituicaoFinanceira/Excluir/{id:long}")]
        public ActionResult ExcluirTipoInstituicao(long id)
        {
            var data = _tipoInstituicaoFinanceiraService.GetById(id);

            if (data == null)
                return HttpNotFound();

            var model = Mapper.Map<TipoInstituicaoFinanceira, TipoInstituicaoFinanceiraViewModel>(data);

            ViewBag.Title = "Exclusão de Tipo de Instituição";
            ViewBag.Message = "Deseja realmente excluir o Tipo de Instituição abaixo?";

            return View("DeleteTipoInstituicao", model);
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
        [ValidateAntiForgeryToken]
        [Route("Parametrizacao/TipoInstituicaoFinanceira/Salvar")]
        public ActionResult SalvarTipoInstituicao(TipoInstituicaoFinanceiraViewModel model)
        {
            if (!ModelState.IsValid)
                return View("FormTipoInstituicao", model);

            var data = Mapper.Map<TipoInstituicaoFinanceiraViewModel, TipoInstituicaoFinanceira>(model);

            if (model.CodTipoInstituicaoFinanceira == 0)
            {
                _tipoInstituicaoFinanceiraService.Add(data);
            }
            else
            {
                _tipoInstituicaoFinanceiraService.Update(data);
            }

            return RedirectToAction("IndexTipoInstituicaoFinanceira");
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

        [HttpPost]
        [Route("Parametrizacao/TipoInstituicaoFinanceira/ConfirmaExcluir/{id:long}")]
        public JsonResult ConfirmaExclusaoTipoInstituicao(long id)
        {
            bool sucesso;

            try
            {
                var data = _tipoInstituicaoFinanceiraService.GetById(id);

                _tipoInstituicaoFinanceiraService.Remove(data);

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