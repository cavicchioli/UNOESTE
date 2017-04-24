/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package br.unoeste.fipp.servlet.logado;

import br.unoeste.fipp.dao.CidadeDAO;
import br.unoeste.fipp.dao.DAOException;
import br.unoeste.fipp.dao.UfDAO;
import br.unoeste.fipp.entidades.Cidade;
import br.unoeste.fipp.entidades.UF;
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
@WebServlet(name = "CadCidade", urlPatterns = {"/logado/cad_cidade.jsp"})
public class CadCidade extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        boolean alterar = false;
        Erro erros = new Erro();
        CidadeDAO dao = new CidadeDAO();
        UfDAO daoUf = new UfDAO();
        //Excluir registro
        if (request.getParameter("del") != null) {
            try {
                int codigo = Integer.parseInt(
                        request.getParameter("del"));
                dao.delete(new Cidade(codigo, null, null));
            } catch (NumberFormatException ex) {
                erros.add("Código Inválido!");
            } catch (DAOException ex) {
                erros.add("Erro ao excluir registro!");
                Logger.getLogger(CadCidade.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        if (request.getParameter("sel") != null) {
            try {
                int codigo = Integer.parseInt(request.getParameter("sel"));
                Cidade cid = dao.getSingle(codigo);
                if (cid == null) {
                    erros.add("Cidade não cadastrada!");
                } else {
                    request.setAttribute("cidade", cid);
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
            int uf = 0;
            try {
                uf = Integer.parseInt(request.getParameter("selUF"));
            } catch(NumberFormatException ex) {
                erros.add("Código de UF Inválido!");
            }
            if (!erros.isExisteErros()) {
                try {
                    dao.insere(new Cidade(codigo, nome, new UfDAO().getSingle(uf)));
                } catch (DAOException ex) {
                    erros.add("Erro ao inserir registro!");
                    Logger.getLogger(CadCidade.class.getName()).log(Level.SEVERE, null, ex);
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
            int uf = 0;
            try {
                uf = Integer.parseInt(request.getParameter("selUF"));
            } catch(NumberFormatException ex) {
                erros.add("Código de UF Inválido!");
            }
            if (!erros.isExisteErros()) {
                try {
                    Cidade cid = dao.getSingle(codigo);
                    if (cid != null) {
                        cid.setNome(nome);
                        cid.setEstado(new UfDAO().getSingle(uf));
                        dao.update(cid);
                        alterar = false;
                    } else {
                        erros.add("Cidade não cadastrado!");
                    }
                } catch (DAOException ex) {
                    erros.add("Erro ao alterando registro!");
                    Logger.getLogger(CadCidade.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        }

        request.setAttribute("alterar", alterar);
        request.setAttribute("cidades", dao.getList());
        request.setAttribute("estados", daoUf.getList());
        request.setAttribute("mensagens", erros);
        RequestDispatcher rd = request.getRequestDispatcher(
                "/WEB-INF/view/logado/cad_cidade.jsp");
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
