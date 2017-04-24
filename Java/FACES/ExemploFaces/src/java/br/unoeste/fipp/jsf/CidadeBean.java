package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.CidadeDAO;
import br.unoeste.fipp.dao.DAOException;
import br.unoeste.fipp.entidades.Cidade;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

@ManagedBean
@ViewScoped
public class CidadeBean {

    private Cidade cidade; 
    private List<Cidade> cadastrados;
    //Controles
    private boolean pesquisando;
    private boolean alterando;
    
    private void limpa() {
        cadastrados = null;
        cidade = new Cidade();
        pesquisando = false;
        alterando = false;
    }
    
    public CidadeBean() {
        limpa();
    }

    public String inserir() {
        CidadeDAO dao = new CidadeDAO();
        if (dao.getSingle(cidade.getCodigo()) != null) {
            JSFUtil.setErrorMessage("Cidade já existe no cadastro");
        } else {
            try {
                dao.insere(cidade);
                return limpar();
            } catch (DAOException ex) {
                JSFUtil.setErrorMessage(ex.getMessage());
            }
        }
        return null;
    }

    
    
     public String alterar() {
        CidadeDAO dao = new CidadeDAO();
        if (dao.getSingle(cidade.getCodigo()) == null) {
            JSFUtil.setErrorMessage("Cidade não existe no cadastro");
        } else {
            try {
                dao.update(cidade);
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
        cadastrados = new CidadeDAO().getList();
        return null;
    }

    public String selecionar(int codigo) {
        cidade = new CidadeDAO().getSingle(codigo);
        if (cidade == null) {
            JSFUtil.setErrorMessage("Cidade não encontrada.");
            return ativarPesquisa();
        } else {
            alterando = true;
            pesquisando = false;
        }
        return null;
    }

    public String excluir(int codigo) {
        try {
            cidade = new CidadeDAO().getSingle(codigo);
            new CidadeDAO().delete(cidade);
            
        } catch (DAOException ex) {
            JSFUtil.setErrorMessage(ex.getMessage());
        }
        return ativarPesquisa();
    }

    public String limpar() {
        limpa();
        return "/on/cadastro_cidade.xhtml";
    }

    public Cidade getCidade() {
        return cidade;
    }

    public List<Cidade> getCadastrados() {
        return cadastrados;
    }

    public boolean isPesquisando() {
        return pesquisando;
    }

    public boolean isAlterando() {
        return alterando;
    }
    
}
