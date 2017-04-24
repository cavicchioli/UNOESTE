<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Cidades</title>
        <link href="${pageContext.request.contextPath}/css/layout.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <h1>Cadastro de Cidades</h1>
        <c:if test="${mensagens.existeErros}">
            <div id="erro">
                <ul>
                    <c:forEach var="erro" items="${mensagens.erros}">
                        <li> ${erro} </li>
                    </c:forEach>
                </ul>
            </div>
        </c:if>
        <form method="post" action="cad_cidade.jsp">
            <p>
                Código: <br/>
                <input type="text" name="txtCodigo" 
                       size="3" maxlength="4" 
                       value="${mensagens.existeErros ? param.txtCodigo : cidade.codigo}"
                       ${alterar ? "readonly=\"readonly\"" : ""}
                       />
            </p>
            <p>
                Nome: <br/>
                <input type="text" name="txtNome" 
                       size="30" maxlength="20"
                       value="${mensagens.existeErros ? param.txtNome : cidade.nome}"/>
            </p>
            <p>
                Estado: <br/>
                <select name="selUF">
                    <c:forEach var="uf" items="${estados}">
                        <option value="${uf.codigo}" 
                                ${mensagens.existeErros ? 
                                  param.selUF == uf.codigo ? "selected=\"selected\"" : "" :
                                  cidade.estado.codigo == uf.codigo ? "selected=\"selected\"" : ""}>${uf.sigla}</option>
                    </c:forEach>
                </select>
            </p>
            <c:if test="${alterar}">
                <input type="submit" name="bInserir" value="Inserir" 
                       disabled="disabled"/>
            </c:if>
            <c:if test="${not alterar}">
                <input type="submit" name="bInserir" value="Inserir"/>
            </c:if>
            <input type="submit" name="bAlterar" value="Alterar"
                   ${alterar ? "" : "disabled=\"disabled\""} />
            <input type="submit" name="bLimpar" value="Limpar"/>
        </form>
       <h2>Registros Cadastrados</h2>
        <table>
            <tr>
                <th>Código</th>
                <th>Nome</th>
                <th>Estado</th>
                <th> - </th>
            </tr>
            <c:forEach var="cid" items="${cidades}">
                <tr>
                    <td>${cidade.codigo}</td>
                    <td>${cidade.nome}</td>
                    <td>${cidade.sigla}</td>
                    <td>
                        <a href="cad_cidade.jsp?sel=${cidade.codigo}">Selecionar</a>
                        &nbsp;
                        <a href="cad_cidade.jsp?del=${cidade.codigo}">Excluir</a>
                    </td>
                </tr>
            </c:forEach>
        </table>
    </body>
</html>
