package br.unoeste.fipp.pos.jsf;

import br.unoeste.fipp.pos.entidades.Uf;
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
@ManagedBean(name = "estadoForm")
@RequestScoped
public class EstadoForm extends AbstractForm {

    private List<Uf> estados;
    private Uf estado;

    /**
     * Creates a new instance of EstadoForm
     */
    public EstadoForm() {
        super();
        estado = new Uf();
    }

    public List<Uf> getEstados() {
        if (estados == null) {
            EntityManager em = getEntityManagerFactory().createEntityManager();
            try {
                estados = em.createNamedQuery("Uf.findAll", Uf.class)
                        .getResultList();
            } catch (Exception ex) {
            } finally {
                em.close();
            }
        }
        return estados;
    }

    public String selecionar(int codigo) {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        try {
            this.estado = em.createNamedQuery("Uf.findByUfCodigo", Uf.class)
                    .setParameter("codigo", codigo)
                    .getSingleResult();
            return "estado.xhtml";
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
            em.persist(em.merge(estado));
            em.getTransaction().commit();
            estado = new Uf();
            return "estado.xhtml";
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
            em.persist(estado);
            em.getTransaction().commit();
            estado = new Uf();
            return "estado.xhtml";
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
                this.estado = em.createNamedQuery("Uf.findByUfCodigo", Uf.class)
                    .setParameter("codigo", codigo).getSingleResult();
                em.remove(em.merge(estado));
                tr.commit();
                estado = new Uf();
                return "estados.xhtml";
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
        return "estado.xhtml";
    }

    public Uf getEstado() {
        return estado;
    }

}
