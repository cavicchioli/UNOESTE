package br.unoeste.fipp.pos.jsf;

import br.unoeste.fipp.pos.entidades.Departamento;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;
import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;
import javax.persistence.NoResultException;

/**
 *
 * @author aluno
 */
@ManagedBean(name = "departamentoForm")
@RequestScoped
public class DepartamentoForm extends AbstractForm {

    private List<Departamento> depts;
    private Departamento dept;

    /**
     * Creates a new instance of EstadoForm
     */
    public DepartamentoForm() {
        super();
        dept = new Departamento();
    }

    public List<Departamento> getDepartamentos() {
        if (depts == null) {
            EntityManager em = getEntityManagerFactory().createEntityManager();
            try {
                depts = em.createNamedQuery("Departamento.findAll", Departamento.class)
                        .getResultList();
            } catch (Exception ex) {
            } finally {
                em.close();
            }
        }
        return depts;
    }

    public String selecionar(int codigo) {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        try {
            this.dept = em.createNamedQuery("Departamento.findByDepCodigo", Departamento.class)
                    .setParameter("codigo", codigo)
                    .getSingleResult();
            return "departamento.xhtml";
        } catch (NoResultException ex) {

        } catch (Exception ex) {
        } finally {
            em.close();
        }
        return null;
    }

    public String alterar() {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        try {
            em.getTransaction().begin();
            em.persist(em.merge(dept));
            em.getTransaction().commit();
            dept = new Departamento();
            return "departamento.xhtml";
        } catch (Exception ex) {
            if (em.getTransaction().isActive()) {
                em.getTransaction().rollback();
            }
            setMessage(ex.getLocalizedMessage());
        } finally {
            em.close();
        }
        return null;
    }

    public String inserir() {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        try {
            em.getTransaction().begin();
            em.persist(dept);
            em.getTransaction().commit();
            dept = new Departamento();
            return "departamento.xhtml";
        } catch (Exception ex) {
            if (em.getTransaction().isActive()) {
                em.getTransaction().rollback();
            }
            setMessage(ex.getLocalizedMessage());
        } finally {
            em.close();
        }
        return null;
    }
    
      public String deletar(int codigo) {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        EntityTransaction tr = null;
        try {
            tr = em.getTransaction();
            tr.begin();
            try {
                this.dept = em.createNamedQuery("Departamento.findByDepCodigo", Departamento.class)
                    .setParameter("codigo", codigo).getSingleResult();
                em.remove(em.merge(dept));
                tr.commit();
                dept = new Departamento();
                return "departamentos.xhtml";
            } catch (NoResultException ex) {
                if (tr.isActive()) {
                    tr.rollback();
                }
            }
        } catch (Exception ex) {
            this.setMessage(ex.getLocalizedMessage());
        } finally {
            em.close();
        }
        return null;
    }

    public String limpar() {
        return "departamento.xhtml";
    }

    public Departamento getDepartamento() {
        return dept;
    }

}
