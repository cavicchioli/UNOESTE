package br.unoeste.fipp.pos.jsf;

import br.unoeste.fipp.pos.entidades.Funcionario;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.Query;

/**
 *
 * @author Caetano
 */
@ManagedBean(name = "loginForm")
@SessionScoped
public class LoginForm extends AbstractForm {

    private Funcionario funcionarioLogado;
    private String login;
    private String senha;

    public LoginForm() {
        super();
        limpaAtributosForm();
    }

    private void limpaAtributosForm() {
        funcionarioLogado = null;
        login = null;
        senha = null;
    }

    public Funcionario getFuncionarioLogado() {
        return funcionarioLogado;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public String getSenha() {
        return senha;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public boolean isUsuarioLogado() {
        return funcionarioLogado != null;
    }

    public String limpaTelaCadastro_action() {
        limpaAtributosForm();
        return "LIMPA";
    }

    public String logout_action() {
        limpaAtributosForm();
        return "LOGOUT";
    }

    public String efetuaLogin_action() {
        EntityManager em = null;
        try {
            em = getEntityManagerFactory().createEntityManager();
            Query q = em.createNamedQuery("Funcionario.findByLogin");
            q.setParameter("login", login);
            this.funcionarioLogado = (Funcionario) q.getSingleResult();
            if (funcionarioLogado.getSenha().equalsIgnoreCase(senha)) {
                return "PRINCIPAL";
            } else {
                setMessage("Senha inválida.");
            }
        } catch (NoResultException ex) {
            //nenhum registro foi encontrado
            setMessage("Usuário não encontrado.");
        } catch (Exception ex) {
        } finally {
            if (em != null) {
                em.close();
            }
            closeEntityManagerFactory();
        }
        funcionarioLogado = null;
        return null;
    }
}