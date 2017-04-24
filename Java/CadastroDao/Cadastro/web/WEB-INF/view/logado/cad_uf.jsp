<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Estados</title>
        <link href="${pageContext.request.contextPath}/css/layout.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <h1>Cadastro de Estados</h1>
        <c:if test="${mensagens.existeErros}">
            <div id="erro">
                <ul>
                    <c:forEach var="erro" items="${mensagens.erros}">
                        <li> ${erro} </li>
                    </c:forEach>
                </ul>
            </div>
        </c:if>
        <form method="post" action="cad_uf.jsp">
            <p>
                Código: <br/>
                <input type="text" name="txtCodigo" 
                       size="3" maxlength="2" 
                       value="${mensagens.existeErros ? param.txtCodigo : uf.codigo}"
                       ${alterar ? "readonly=\"readonly\"" : ""}
                       />
            </p>
            <p>
                Nome: <br/>
                <input type="text" name="txtNome" 
                       size="30" maxlength="20"
                       value="${mensagens.existeErros ? param.txtNome : uf.nome}"/>
            </p>
            <p>
                Sigla: <br/>
                <input type="text" name="txtSigla" 
                       size="3" maxlength="2"
                       value="${mensagens.existeErros ? param.txtSigla : uf.sigla}"/>
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
                <th>Sigla</th>
                <th> - </th>
            </tr>
            <c:forEach var="uf" items="${estados}">
                <tr>
                    <td>${uf.codigo}</td>
                    <td>${uf.nome}</td>
                    <td>${uf.sigla}</td>
                    <td>
                        <a href="cad_uf.jsp?sel=${uf.codigo}">Selecionar</a>
                        &nbsp;
                        <a href="cad_uf.jsp?del=${uf.codigo}">Excluir</a>
                    </td>
                </tr>
            </c:forEach>
        </table>
    </body>
</html>
