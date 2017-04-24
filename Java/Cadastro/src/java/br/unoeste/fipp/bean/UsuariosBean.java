/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package br.unoeste.fipp.bean;

import br.unoeste.fipp.dao.UsuarioDAO;
import br.unoeste.fipp.entidades.Usuario;
import java.beans.*;
import java.util.List;

public class UsuariosBean {

    private final List<Usuario> lista;

    public UsuariosBean() {
        lista = new UsuarioDAO().getList();
    }

    public List<Usuario> getLista() {
        return lista;
    }

}
    
   