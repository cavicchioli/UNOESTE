/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package br.unoeste.fipp.bean;
import br.unoeste.fipp.dao.CidadeDAO;
import br.unoeste.fipp.entidades.Cidade;
import java.util.List;
/**
 *
 * @author Victor
 */
public class CidadesBean {
     private final List<Cidade> lista;

    public CidadesBean() {
        lista = new CidadeDAO().getList();
    }

    public List<Cidade> getLista() {
        return lista;
    }
    
}
