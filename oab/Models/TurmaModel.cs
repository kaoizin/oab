using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oab.Entity;

namespace oab.Models
{
    public class TurmaModel
    {
        private OabEntities db = new OabEntities();

        public List<Turma> todasTurmas()
        {
            var lista = from t in db.Turma
                        select t;
            return lista.ToList();
        }

        public string adicionarTurma(Turma t)
        {
            string erro = null;
            try
            {
                db.Turma.AddObject(t);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Turma obterTurma(int idTurma)
        {
            var lista = from c in db.Turma
                        where c.IdTurma == idTurma
                        select c;
            return lista.ToList().FirstOrDefault();
        }

        public string editarTurma(Turma t)
        {
            string erro = null;
            try
            {
                if (t.EntityState == System.Data.EntityState.Detached)
                {
                    db.Turma.Attach(t);
                }
                db.ObjectStateManager.ChangeObjectState(t, System.Data.EntityState.Modified);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }
        public string excluirTurma(Turma t)
        {
            string erro = null;
            try
            {
                db.Turma.DeleteObject(t);
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