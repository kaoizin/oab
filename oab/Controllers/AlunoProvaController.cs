using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oab.Entity;
using oab.Models;
using oab.ViewModel;

namespace oab.Controllers
{
    public class AlunoProvaController : Controller
    {
        private AlunoModel aModel = new AlunoModel();
        private TurmaModel tModel = new TurmaModel();
        private AvaliacaoModel vModel = new AvaliacaoModel();
        int alunoSelecionadoCbx;

        public ActionResult ProvaPorAluno()
        {
            
            
           string alunoSelecionado = "Luiz";
           int turmaSelecionada = 2;
           var turma = new SelectList(tModel.todasTurmas(), "IdTurma", "DescricaoTurma", turmaSelecionada);

           var aluno = new SelectList(aModel.obtAlunoPorTurma(turmaSelecionada),
                   "IdPessoa", "Nome", alunoSelecionado);

           AlunoProvaViewModel aViewModel = new AlunoProvaViewModel();
           var viewModel = new AlunoProvaViewModel(turma, aluno);
           return View(viewModel);
        }

        public PartialViewResult List(int id)
        {
            id = 1;
            var aluno = vModel.todasAvaliacoesID(id);
            return PartialView(aluno);
        }
        public JsonResult ListaAlunos(int id)
        {
            var alunos = new SelectList(aModel.obtAlunoPorTurma(id), "IdPessoa", "Nome");
            //alunoSelecionadoCbx = Convert.ToInt32(alunos);
            return Json(new { alunos = alunos });
        }

    }
}
