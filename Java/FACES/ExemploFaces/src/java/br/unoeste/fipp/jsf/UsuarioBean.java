package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.DAOException;
import br.unoeste.fipp.dao.UsuarioDAO;
import br.unoeste.fipp.entidades.Usuario;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.validator.ValidatorException;

/**
 *
 * @author Aluno
 */
@ManagedBean
@ViewScoped
public class UsuarioBean {

    private Usuario usuario;
    private List<Usuario> cadastrados;
    //Controles
    private boolean pesquisando;
    private boolean alterando;

    /**
     * Creates a new instance of UsuarioBean
     */
    public UsuarioBean() {
        limpa();
    }

    private void limpa() {
        cadastrados = null;
        usuario = new Usuario();
        pesquisando = false;
        alterando = false;
    }

    public void validaSenhaDoUsuario(FacesContext fc, UIComponent uic, Object valor)
            throws ValidatorException {

        if (valor == null) {
            return;
        }

        final String texto = (String) valor;
        if (!texto.matches("^\\D+$")) {
            //if(texto.matches(".*\\d.*")) {
            FacesMessage msg
                    = new FacesMessage("Senha não pode ter número!");
            throw new ValidatorException(msg);
        }
    }

    public String inserir() {
        UsuarioDAO dao = new UsuarioDAO();
        if (dao.getSingle(usuario.getCodigo()) != null) {
            JSFUtil.setErrorMessage("Usuário já existe no cadastro");
        } else {
            try {
                dao.insere(usuario);
                return limpar();
            } catch (DAOException ex) {
                JSFUtil.setErrorMessage(ex.getMessage());
            }
        }
        return null;
    }

    public String alterar() {
        UsuarioDAO dao = new UsuarioDAO();
        if (dao.getSingle(usuario.getCodigo()) == null) {
            JSFUtil.setErrorMessage("Usuário não existe no cadastro");
        } else {
            try {
                dao.update(usuario);
                return limpar();
            } catch (DAOException ex) {
                JSFUtil.setErrorMessage(ex.getMessage());
            }
        }
        return null;
    }

    public String ativarPesquisa() {
        alterando = false;
        pesquisando = true;
        cadastrados = new UsuarioDAO().getList();
        return null;
    }

    public String selecionar(int codigo) {
        usuario = new UsuarioDAO().getSingle(codigo);
        if (usuario == null) {
            JSFUtil.setErrorMessage("Usuário não encontrado.");
            return ativarPesquisa();
        } else {
            alterando = true;
            pesquisando = false;
        }
        return null;
    }

    public String excluir(int codigo) {
        try {
            new UsuarioDAO().delete(new Usuario(codigo));
        } catch (DAOException ex) {
            JSFUtil.setErrorMessage(ex.getMessage());
        }
        return ativarPesquisa();
    }

    public String limpar() {
        limpa();
        return "/on/cadastro_usuario.xhtml";
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public List<Usuario> getCadastrados() {
        return cadastrados;
    }

    public boolean isPesquisando() {
        return pesquisando;
    }

    public boolean isAlterando() {
        return alterando;
    }

}
