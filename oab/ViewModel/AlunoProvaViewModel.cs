using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oab.Entity;
using System.Web.Mvc;
using oab.Models;

namespace oab.ViewModel
{
    public class AlunoProvaViewModel
    {
        public SelectList Aluno { get; set; }
        public SelectList Turma { get; set; }
        public List<Avaliacao> ListaAvaliacoes { get; set; }

        public AlunoProvaViewModel()
        {
        }
        public AlunoProvaViewModel(SelectList turmaAluno, SelectList alunoTurma)
        {
            Aluno = alunoTurma;
            Turma = turmaAluno;
        }
    }
}