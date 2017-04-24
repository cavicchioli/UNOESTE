<%@ taglib prefix="c" 
           uri="http://java.sun.com/jsp/jstl/core" %>
<%@page import="java.util.List"%>
<%@page import="br.unoeste.fipp.entidades.UF"%>
<%@page import="br.unoeste.fipp.dao.UfDAO"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    if (session.getAttribute("usuarioLogado") == null) {
        session.invalidate();
        response.sendRedirect("index.jsp");
        return;
    }
%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Teste de Consulta</title>
    </head>
    <body>
        <h1>Teste de Consulta</h1>
        <p>Olá usuário ${usuarioLogado.nome}</p>

        <c:if test="${usuarioLogado.administrador}">
            <form>
                <select name="estados">
                    <option value="">-- Escolha um --</option>
                    <%
                        UfDAO dao = new UfDAO();
                        List<UF> estados = dao.getList();
                        for (UF estado : estados) {
                    %>
                    <option value="<%= estado.getCodigo()%>">
                        <%= estado.getNome()%>
                    </option>
                    <%
                        }
                    %>
                </select>
            </form>
        </c:if>   
        <form>
            <jsp:useBean id="listaEstados" scope="page"
                         class="br.unoeste.fipp.bean.EstadosBean"/>
            <select>
                <c:forEach var="estado" items="${listaEstados.lista}">
                    <option value="${estado.codigo}">${estado.nome}</option>
                </c:forEach>
            </select>
        </form>






    </body>
</html>
