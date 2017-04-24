package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.ContatoDAO;
import br.unoeste.fipp.dao.DAOException;
import br.unoeste.fipp.entidades.Contato;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.validator.ValidatorException;

@ManagedBean
@ViewScoped
public class ContatoBean {

    private Contato contato; 
    private List<Contato> cadastrados;
    //Controles
    private boolean pesquisando;
    private boolean alterando;
    
    private void limpa() {
        cadastrados = null;
        contato = new Contato();
        pesquisando = false;
        alterando = false;
    }
    
    public ContatoBean() {
        limpa();
    }
    
     public String inserir() {
        ContatoDAO dao = new ContatoDAO();
        if (dao.getSingle(contato.getCodigo()) != null) {
            JSFUtil.setErrorMessage("Contato já existe no cadastro");
        } else {
            try {
                dao.insere(contato);
                return limpar();
            } catch (DAOException ex) {
               JSFUtil.setErrorMessage(ex.getMessage());
            }
        }
        return null;
    }
     public String alterar() {
        ContatoDAO dao = new ContatoDAO();
        if (dao.getSingle(contato.getCodigo()) == null) {
            JSFUtil.setErrorMessage("Contato não existe no cadastro");
        } else {
            try {
                dao.update(contato);
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
        cadastrados = new ContatoDAO().getList();
        return null;
    }

    public String selecionar(int codigo) {
        contato = new ContatoDAO().getSingle(codigo);
        if (contato == null) {
            JSFUtil.setErrorMessage("Contato não encontrada.");
            return ativarPesquisa();
        } else {
            alterando = true;
            pesquisando = false;
        }
        return null;
    }

    public String excluir(int codigo) {
        try {
            contato = new ContatoDAO().getSingle(codigo);
            new ContatoDAO().delete(contato);
            
        } catch (DAOException ex) {
            JSFUtil.setErrorMessage(ex.getMessage());
        }
        return ativarPesquisa();
    }

    public String limpar() {
        limpa();
        return "/on/cadastro_contato.xhtml";
    }

    public Contato getContato() {
        return contato;
    }

    public List<Contato> getCadastrados() {
        return cadastrados;
    }

    public boolean isPesquisando() {
        return pesquisando;
    }

    public boolean isAlterando() {
        return alterando;
    }
    
}
