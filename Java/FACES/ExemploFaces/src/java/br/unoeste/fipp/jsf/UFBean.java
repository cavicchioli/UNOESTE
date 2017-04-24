package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.DAOException;
import br.unoeste.fipp.dao.UfDAO;
import br.unoeste.fipp.entidades.UF;
import br.unoeste.fipp.entidades.Usuario;
import java.io.Serializable;
import java.util.List;
import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ManagedProperty;
import javax.faces.bean.ViewScoped;

/**
 *
 * @author Aluno
 */
@ManagedBean
@ViewScoped
public class UFBean
        implements Serializable {

    private UF estado;
    private List<UF> estadosCadastrados;
    @ManagedProperty("#{sessionScope.usuarioLogado}")
    private Usuario usuarioLogado;
    private boolean alterando;
    private boolean pesquisando;

    /**
     * Creates a new instance of UFBean
     */
    public UFBean() {
    }

    @PostConstruct
    private void limpa() {
        estado = new UF();
        estadosCadastrados = null;
        alterando = false;
        pesquisando = false;
    }

    public String inserir() {
        UfDAO dao = new UfDAO();
        if (dao.getSingle(estado.getCodigo()) != null) {
            JSFUtil.setErrorMessage("Estado já existe no cadastro");
        } else {
            try {
                dao.insere(estado);
                return limpar();
            } catch (DAOException ex) {
                JSFUtil.setErrorMessage(ex.getMessage());
            }
        }
        return null;
    }

    public String alterar() {
        UfDAO dao = new UfDAO();
        if (dao.getSingle(estado.getCodigo()) == null) {
            JSFUtil.setErrorMessage("Estado não existe no cadastro");
        } else {
            try {
                dao.update(estado);
                return limpar();
            } catch (DAOException ex) {
                JSFUtil.setErrorMessage(ex.getMessage());
            }
        }
        return null;
    }

    public String limpar() {
        limpa();
        return "/on/cadastro_uf.xhtml";
    }

    public String ativarPesquisa() {
        alterando = false;
        pesquisando = true;
        estadosCadastrados = new UfDAO().getList();
        return null;
    }
    
     public String selecionar(int codigo) {
        estado = new UfDAO().getSingle(codigo);
        if (estado == null) {
            JSFUtil.setErrorMessage("Estado não encontrado.");
            return ativarPesquisa();
        } else {
            alterando = true;
            pesquisando = false;
        }
        return null;
    }
     
      public String excluir(int codigo) {
        try {
            estado = new UfDAO().getSingle(codigo);
            new UfDAO().delete(estado);
        } catch (DAOException ex) {
            JSFUtil.setErrorMessage(ex.getMessage());
        }
        return ativarPesquisa();
    }
    

    public UF getEstado() {
        return estado;
    }

    public List<UF> getEstadosCadastrados() {
        return estadosCadastrados;
    }

    public Usuario getUsuarioLogado() {
        return usuarioLogado;
    }

    public void setUsuarioLogado(Usuario usuarioLogado) {
        this.usuarioLogado = usuarioLogado;
    }

    public boolean isAlterando() {
        return alterando;
    }

    public boolean isPesquisando() {
        return pesquisando;
    }

}
