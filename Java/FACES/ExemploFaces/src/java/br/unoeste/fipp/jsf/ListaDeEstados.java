package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.UfDAO;
import br.unoeste.fipp.entidades.UF;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

@ManagedBean
@ViewScoped
public class ListaDeEstados {

    private final List<UF> estadosCadastrados;
    
    public ListaDeEstados() {
        UfDAO dao = new UfDAO();
        estadosCadastrados = dao.getList();
    }
    
    public List<UF> getEstadosCadastrados() {
        return estadosCadastrados;
    }
    
}
