package br.unoeste.fipp.pos.jsf;

import br.unoeste.fipp.pos.entidades.Departamento;
import br.unoeste.fipp.pos.entidades.Funcionario;
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
@ManagedBean(name = "funcionarioForm")
@RequestScoped
public class FuncionarioForm extends AbstractForm {

    private List<Funcionario> funcionarios;
    private Funcionario funcionario;
    private List<Departamento> departamentos;

    /**
     * Creates a new instance of EstadoForm
     */
    public FuncionarioForm() {
        super();
        funcionario = new Funcionario();
    }

   public List<Departamento> getDepartamentos() {
        if (departamentos == null) {
            EntityManager em = getEntityManagerFactory().createEntityManager();
            try {
                departamentos = em.createNamedQuery("Departamento.findAll", Departamento.class)
                        .getResultList();
            } catch (Exception ex) {
            } finally {
                em.close();
            }
        }
        return departamentos;
    }
    
    public List<Funcionario> getFuncionarios() {
        if (funcionarios == null) {
            EntityManager em = getEntityManagerFactory().createEntityManager();
            try {
                funcionarios = em.createNamedQuery("Funcionario.findAll", Funcionario.class)
                        .getResultList();
            } catch (Exception ex) {
            } finally {
                em.close();
            }
        }
        return funcionarios;
    }

    public String selecionar(int codigo) {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        try {
            this.funcionario = em.createNamedQuery("Funcionario.findByCodigo", Funcionario.class)
                    .setParameter("codigo", codigo)
                    .getSingleResult();
            return "funcionario.xhtml";
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
            em.persist(em.merge(funcionario));
            em.getTransaction().commit();
            funcionario = new Funcionario();
            return "funcionario.xhtml";
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
                this.funcionario = em.createNamedQuery("Funcionario.findByCodigo", Funcionario.class)
                    .setParameter("codigo", codigo).getSingleResult();
                em.remove(em.merge(funcionario));
                tr.commit();
                funcionario = new Funcionario();
                return "funcionarios.xhtml";
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
    
    

    public String inserir() {
        EntityManager em = getEntityManagerFactory().createEntityManager();
        try {
            em.getTransaction().begin();
            em.persist(funcionario);
            em.getTransaction().commit();
            funcionario = new Funcionario();
            return "funcionario.xhtml";
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

    public String limpar() {
        return "funcionario.xhtml";
    }

    public Funcionario getFuncionario() {
        return funcionario;
    }

}
