using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oab.Entity;

namespace oab.Models
{
    public class AlunoModel
    {
        private OabEntities db = new OabEntities();

        public List<Aluno> todosAlunos()
        {
            var lista = from a in db.Aluno
                        select a;
            return lista.ToList();
        }
        public Aluno obterAluno(string matricula)
        {
            var lista = from u in db.Aluno
                        where u.Matricula == matricula
                        select u;
            return lista.ToList().FirstOrDefault();
        }
        // JSON
        public List<Pessoa> todasPessoas()
        {
            var lista = from p in db.Pessoa
                        select p;
            return lista.ToList();
        }
        public List<Pessoa> obtAlunoPorTurma(int idTurma)
        {
            var lista = from p in db.Pessoa
                        join a in db.Aluno
                        on p.IdPessoa equals a.IdPessoa
                        join at in db.AlunoTurma
                        on a.IdPessoa equals at.IdAluno
                        where at.IdTurma == idTurma
                        select p;
               return lista.ToList();
        }
        //JSON lista
        public List<Avaliacao> pesquisarAvaliacao(string nome)
        {
            var lista = from a in db.Avaliacao
                        where a.NomeAvaliacao.Contains(nome)
                        select a;
            return lista.ToList();
        }

        public string adicionarAluno(Pessoa a)
        {
            var teste = a.Nome;
            var matricula = a.Aluno.Matricula;
            var usuario = a.Usuario.Senha;
            //a.IdUsuario = a.Usuario.IdUsuario;


            string erro = null;
            try
            {
                db.Pessoa.AddObject(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }
        public string excluirAluno(Aluno u)
        {
            string erro = null;
            try
            {
                db.Aluno.DeleteObject(u);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }
    }
}