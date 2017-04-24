package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.CidadeDAO;
import br.unoeste.fipp.dao.UfDAO;
import br.unoeste.fipp.entidades.Cidade;
import br.unoeste.fipp.entidades.UF;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.event.AbortProcessingException;
import javax.faces.event.ValueChangeEvent;
import javax.faces.event.ValueChangeListener;

@ManagedBean
@ViewScoped
public final class ListaDeEstadosCidades implements Serializable, ValueChangeListener {

    private final List<UF> estadosCadastrados;
    private List<Cidade> cidades;
    
    public ListaDeEstadosCidades() {
        UfDAO dao = new UfDAO();
        estadosCadastrados = dao.getList();
        limpaCidade();
    }
    
    private void limpaCidade() {
        cidades = new ArrayList<>();
    }

    @Override
    public void processValueChange(ValueChangeEvent vce)
            throws AbortProcessingException {
        escolheuEstado(vce);
    }

    public void escolheuEstado(ValueChangeEvent evt) {
        UF estado = (UF) evt.getNewValue();
        if (estado == null) {
            limpaCidade();
        } else {
            cidades = CidadeDAO.getListaCidade(estado.getCodigo());
        }
        JSFUtil.getFacesContext().renderResponse();
    }

    public List<UF> getEstadosCadastrados() {
        return estadosCadastrados;
    }

    public List<Cidade> getCidades() {
        return cidades;
    }
    
}
