package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.UsuarioDAO;
import br.unoeste.fipp.entidades.Usuario;
import java.io.Serializable;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;
import javax.faces.context.FacesContext;

/**
 *
 * @author Aluno
 */
@ManagedBean(name = "loginBean")
@RequestScoped
public class LoginBean
        implements Serializable {

    private String login;
    private String senha;

    /**
     * Creates a new instance of LoginBean
     */
    public LoginBean() {
        limpa();
    }

    private void limpa() {
        login = null;
        senha = null;
    }

    public String efetuarLogin() {
        FacesContext ctx = FacesContext.getCurrentInstance();
        FacesMessage erro;
        UsuarioDAO dao = new UsuarioDAO();
        Usuario user = dao.getSingle(login);
        if (user == null) {
            erro = new FacesMessage("Usuário não cadastrado!");
            ctx.addMessage("txtLogin", erro);
        } else {
            if (senha.equals(user.getSenha())) {
                JSFUtil.getSession().setAttribute("usuarioLogado", user);
                return "ENTRAR";
            } else {
                erro = new FacesMessage("Senha inválida!");
                ctx.addMessage("txtSenha", erro);
            }
        }
        return null;
    }

    public String logout() {
        JSFUtil.getSession().invalidate();
        limpa();
        return "/index.xhtml";
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

}
