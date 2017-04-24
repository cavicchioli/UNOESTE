package br.unoeste.fipp.pos.jsf;

import br.unoeste.fipp.pos.entidades.Cidade;
import br.unoeste.fipp.pos.entidades.Uf;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;
import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;
import javax.persistence.NoResultException;

/**
 *
 * @author Aluno
 */
@ManagedBean
@RequestScoped
public class CidadeForm extends AbstractForm {

    private List<Uf> estados;
    private Cidade cidade;
    private List<Cidade> cidades;

    public CidadeForm() {
        cidade = new Cidade();
        estados = null;
    }

    public List<Uf> getEstados() {
        if (estados == null) {
            EntityManager em = getEntityManagerFactory().createEntityManager();
            try {
                estados = em.createNamedQuery("Uf.findAll", Uf.class)
                        .getResultList();
            } catch (Exception ex) {
                setMessage("Erro carregando estados!");
            } finally {
                em.close();
            }
        }
        return estados;
    }
    
    public List<Cidade> getCidades() {
        if (cidades == null) {
            EntityManager em = getEntityManagerFactory().createEntityManager();
            try {
                cidades = em.createNamedQuery("Cidade.findAll", Cidade.class)
                        .getResultList();
            } catch (Exception ex) {
                setMessage("Erro carregando estados!");
            } finally {
                em.close();
            }
        }
        return cidades;
    }
    
    public String selecionar(int codigo) {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        try {
            this.cidade = em.createNamedQuery("Cidade.findByCidCodigo", Cidade.class)
                    .setParameter("codigo", codigo)
                    .getSingleResult();
            return "cidade.xhtml";
        } catch (NoResultException ex) {

        } catch (Exception ex) {
        } finally {
            em.close();
        }
        return null;
    }

    public Cidade getCidade() {
        return cidade;
    }

    public String inserir() {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        EntityTransaction et = null;
        try {
            et = em.getTransaction();
            et.begin();
            try {
                Cidade temp = em.createNamedQuery("Cidade.findByCidCodigo", Cidade.class)
                        .setParameter("codigo", cidade.getCodigo())
                        .getSingleResult();
                throw new Exception("Cidade escolhida já cadastrada!");
            } catch (NoResultException ex) {
                em.persist(em.merge(this.cidade));
            }
            et.commit();
            this.cidade = new Cidade();
            return "cidade.xhtml";
        } catch (Exception ex) {
            if (et != null) {
                if (et.isActive()) {
                    et.rollback();
                }
            }
            setMessage(ex.getLocalizedMessage());
        } finally {
            em.close();
        }
        return null;
    }

    public String alterar() {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        EntityTransaction et = null;
        try {
            et = em.getTransaction();
            et.begin();
            try {
                Cidade temp = em.createNamedQuery("Cidade.findByCidCodigo", Cidade.class)
                        .setParameter("codigo", cidade.getCodigo())
                        .getSingleResult();
                em.persist(em.merge(this.cidade));
            } catch (NoResultException ex) {
                throw new Exception("Cidade informada não cadastrada!");
            }
            et.commit();
            this.cidade = new Cidade();
            return "cidade.xhtml";
        } catch (Exception ex) {
            if (et != null) {
                if (et.isActive()) {
                    et.rollback();
                }
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
                this.cidade = em.createNamedQuery("Cidade.findByCidCodigo", Cidade.class)
                    .setParameter("codigo", codigo).getSingleResult();
                em.remove(em.merge(cidade));
                tr.commit();
                cidade = new Cidade();
                return "cidades.xhtml";
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
        return "cidade.xhtml";
    }
}
