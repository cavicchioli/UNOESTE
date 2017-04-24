package br.unoeste.fipp.bean;

import br.unoeste.fipp.dao.UfDAO;
import br.unoeste.fipp.entidades.UF;
import java.util.List;

/**
 *
 * @author Aluno
 */
public class EstadosBean {

    private final List<UF> lista;

    public EstadosBean() {
        lista = new UfDAO().getList();
    }

    public List<UF> getLista() {
        return lista;
    }

}
