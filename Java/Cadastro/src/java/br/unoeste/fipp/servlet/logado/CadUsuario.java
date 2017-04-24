/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package br.unoeste.fipp.servlet.logado;

import br.unoeste.fipp.dao.DAOException;
import br.unoeste.fipp.dao.UsuarioDAO;
import br.unoeste.fipp.entidades.Usuario;
import br.unoeste.fipp.util.Erro;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Victor
 */
@WebServlet(name = "CadUsuario", urlPatterns = {"/logado/cad_usuario.jsp"})
public class CadUsuario extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        boolean alterar = false;
        Erro erros = new Erro();
        UsuarioDAO dao = new UsuarioDAO();
        //Excluir registro
        if (request.getParameter("del") != null) {
            try {
                int codigo = Integer.parseInt(
                        request.getParameter("del"));
                dao.delete(new Usuario(codigo, null, null, null,false));
            } catch (NumberFormatException ex) {
                erros.add("Código Inválido!");
            } catch (DAOException ex) {
                erros.add("Erro ao excluir registro!");
                Logger.getLogger(CadUsuario.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        if (request.getParameter("sel") != null) {
            try {
                int codigo = Integer.parseInt(request.getParameter("sel"));
                Usuario usu = dao.getSingle(codigo);
                if (usu == null) {
                    erros.add("Usuário não cadastrado!");
                } else {
                    request.setAttribute("usuario", usu);
                    alterar = true;
                }
            } catch (NumberFormatException ex) {
                erros.add("Código Inválido!");
            }
        }
        //Inclusão
        if (request.getParameter("bInserir") != null) {
            int codigo = 0;
            try {
                codigo = Integer.parseInt(
                        request.getParameter("txtCodigo"));
            } catch (NumberFormatException ex) {
                erros.add("Código inválido!");
            }
            String nome = request.getParameter("txtNome");
            if (nome == null || nome.isEmpty()) {
                erros.add("Nome não informado!");
            }
            String login = request.getParameter("txtLogin");
            if (login == null || login.isEmpty()) {
                erros.add("Login não informado!");
            }
            String senha = request.getParameter("txtSenha");
            if (senha == null || senha.isEmpty()) {
                erros.add("Senha não informada!");
            }
//          
            String adm = request.getParameter("rAdm");
            boolean admin = false;
            if (adm == null || adm.isEmpty()){
                erros.add("Administrador não informado!");
            } else if (adm.equals("S")) {
                admin = true;
            }
            
            if (!erros.isExisteErros()) {
                try {
                    dao.insere(new Usuario(codigo, nome,login, senha, admin));
                } catch (DAOException ex) {
                    erros.add("Erro ao inserir registro!");
                    Logger.getLogger(CadUsuario.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        }
        //Alterar
        if (request.getParameter("bAlterar") != null) {
            alterar = true;
            int codigo = 0;
            try {
                codigo = Integer.parseInt(
                        request.getParameter("txtCodigo"));
            } catch (NumberFormatException ex) {
                erros.add("Código inválido!");
            }
            String nome = request.getParameter("txtNome");
            if (nome == null || nome.isEmpty()) {
                erros.add("Nome não informado!");
            }
            String login = request.getParameter("txtLogin");
            if (login == null || login.isEmpty()) {
                erros.add("Login não informado!");
            }
            String senha = request.getParameter("txtSenha");
            if (senha == null || senha.isEmpty()) {
                erros.add("Senha não informada!");
            }
//           
            String adm = request.getParameter("rAdm");
            boolean admin = false;
            if (adm == null || adm.isEmpty()){
                erros.add("Administrador não informado!");
            } else if (adm.equals("S")) {
                admin = true;
            }
            
            if (!erros.isExisteErros()) {
                try {
                    Usuario usu = dao.getSingle(codigo);
                    if (usu != null) {
                        usu.setNome(nome);
                        usu.setLogin(login);
                        usu.setSenha(senha);
                        usu.setAdministrador(admin);
                        dao.update(usu);
                        alterar = false;
                    } else {
                        erros.add("Usuário não cadastrado!");
                    }
                } catch (DAOException ex) {
                    erros.add("Erro ao alterando registro!");
                    Logger.getLogger(CadUsuario.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        }

        request.setAttribute("alterar", alterar);
        request.setAttribute("usuarios", dao.getList());
        request.setAttribute("mensagens", erros);
        RequestDispatcher rd = request.getRequestDispatcher(
                "/WEB-INF/view/logado/cad_usuario.jsp");
        rd.forward(request, response);
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
