using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oab.Entity;
using oab.Models;

namespace oab.Models
{
    public class AvaliacaoModel
    {
        private OabEntities db = new OabEntities();

        public List<Avaliacao> todasAvaliacoes()
        {
            var lista = from a in db.Avaliacao
                        select a;
            return lista.ToList();
        }
        public List<Avaliacao> todasAvaliacoesID(int id)
        {
            var lista = from a in db.Avaliacao
                        where a.IdAluno.Equals(id)
                        select a;
            return lista.ToList();
        }        
        public List<Avaliacao> todasAvaliacoesPorAluno(int idPessoa)
        {
            var lista = from a in db.Aluno
                        join p in db.Pessoa
                        on a.IdPessoa equals p.IdPessoa
                        join at in db.AlunoTurma
                        on p.IdPessoa equals at.IdAluno
                        join avt in db.AplicacaoAvaliacaoTurma
                        on at.IdTurma equals avt.IdTurma
                        join av in db.AplicacaoAvaliacao
                        on avt.IdAplicacaoAvaliacao equals av.IdAplicacaoAvaliacao
                        join ava in db.Avaliacao
                        on av.IdAvaliacao equals ava.IdAvaliacao
                        where a.IdPessoa == idPessoa
                        select ava;
            return lista;
        }
    }
}