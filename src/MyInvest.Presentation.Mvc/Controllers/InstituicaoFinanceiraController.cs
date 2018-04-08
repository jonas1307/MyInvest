using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Services;
using MyInvest.Presentation.Mvc.ViewModels;

namespace MyInvest.Presentation.Mvc.Controllers
{
    public class InstituicaoFinanceiraController : Controller
    {
        private readonly IInstituicaoFinanceiraService _instituicaoFinanceiraService;
        private readonly ITipoInstituicaoFinanceiraService _tipoInstituicaoFinanceiraService;

        public InstituicaoFinanceiraController(IInstituicaoFinanceiraService instituicaoFinanceiraService,
            ITipoInstituicaoFinanceiraService tipoInstituicaoFinanceiraService)
        {
            _instituicaoFinanceiraService = instituicaoFinanceiraService;
            _tipoInstituicaoFinanceiraService = tipoInstituicaoFinanceiraService;
        }

        public ActionResult Index()
        {
            var model = _instituicaoFinanceiraService.GetAll().ToList();

            return View(model);
        }

        public ActionResult Novo()
        {
            var model = DefinirModel();

            return View("FormInstituicaoFinanceira", model);
        }

        public ActionResult Editar(long id)
        {
            var data = _instituicaoFinanceiraService.GetById(id);

            if (data == null)
                return HttpNotFound();

            var model = DefinirModel(Mapper.Map<InstituicaoFinanceira, InstituicaoFinanceiraViewModel>(data));

            return View("FormInstituicaoFinanceira", model);
        }
        
        public ActionResult Excluir(long id)
        {
            var data = _instituicaoFinanceiraService.GetById(id);

            if (data == null)
                return HttpNotFound();

            var model = Mapper.Map<InstituicaoFinanceira, InstituicaoFinanceiraViewModel>(data);

            ViewBag.Title = "Exclusão de Instituição Financeira";
            ViewBag.Message = "Deseja realmente excluir a Instituição Financeira abaixo?";

            return View("DeleteInstituicaoFinanceira", model);
        }

        [HttpPost]
        public JsonResult ConfirmaExclusao(long id)
        {
            bool sucesso;

            try
            {
                var data = _instituicaoFinanceiraService.GetById(id);

                _instituicaoFinanceiraService.Remove(data);

                sucesso = true;
            }
            catch (Exception)
            {
                sucesso = false;
            }

            return Json(sucesso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(InstituicaoFinanceiraViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = DefinirModel(model);
                return View("FormInstituicaoFinanceira", model);
            }

            var data = Mapper.Map<InstituicaoFinanceiraViewModel, InstituicaoFinanceira>(model);

            if (data.CodInstituicaoFinanceira == 0)
            {
                _instituicaoFinanceiraService.Add(data);
            }
            else
            {
                _instituicaoFinanceiraService.Update(data);
            }

            return RedirectToAction("Index", "InstituicaoFinanceira");
        }

        private InstituicaoFinanceiraViewModel DefinirModel(InstituicaoFinanceiraViewModel model = null)
        {
            if (model == null)
                model = new InstituicaoFinanceiraViewModel();

            model.ListaTipoInstituicaoFinanceira = new SelectList(_tipoInstituicaoFinanceiraService.GetAll(), "CodTipoInstituicaoFinanceira", "Descricao");

            return model;
        }
    }
}