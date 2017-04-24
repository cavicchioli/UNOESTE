<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Usuários</title>
        <link href="${pageContext.request.contextPath}/css/layout.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <h1>Cadastro de Usuários</h1>
        <c:if test="${mensagens.existeErros}">
            <div id="erro">
                <ul>
                    <c:forEach var="erro" items="${mensagens.erros}">
                        <li> ${erro} </li>
                    </c:forEach>
                </ul>
            </div>
        </c:if>
        <form method="post" action="cad_usuario.jsp">
            <p>
                Código: <br/>
                <input type="text" name="txtCodigo" 
                       size="3" maxlength="2" 
                       value="${mensagens.existeErros ? param.txtCodigo : usuario.codigo}"
                       ${alterar ? "readonly=\"readonly\"" : ""}
                       />
            </p>
            <p>
                Nome: <br/>
                <input type="text" name="txtNome" 
                       size="30" maxlength="100"
                       value="${mensagens.existeErros ? param.txtNome : usuario.nome}"/>
            </p>
            <p>
                Login: <br/>
                <input type="text" name="txtLogin" 
                       size="10" maxlength="6"
                       value="${mensagens.existeErros ? param.txtLogin : usuario.login}"/>
            </p>
             <p>
                Senha: <br/>
                <input type="password" name="txtSenha" 
                       size="10" maxlength="6"
                       value="${mensagens.existeErros ? param.txtSenha : usuario.senha}"/>
            </p>
             <p>
                Administrador: <br/>
                <input type="radio" name="rAdm" value="S" ${mensagens.existeErros ? param.rAdm == "S" ? "checked=\"checked\"" : "" : usuario.administrador ? "checked=\"checked\"" : ""}/>Sim
                <input type="radio" name="rAdm" value="N" ${mensagens.existeErros ? param.rAdm == "N" ? "checked=\"checked\"" : "" : usuario.administrador ? "" : "checked=\"checked\""}/>Não
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
                <th>Login</th>
                <th>Administrador</th>
                <th> - </th>
            </tr>
            <c:forEach var="usuario" items="${usuarios}">
                <tr>
                    <td>${usuario.codigo}</td>
                    <td>${usuario.nome}</td>
                    <td>${usuario.login}</td>
                    <td>${usuario.administrador ? "Sim" : "Não"}</td>
                    <td>
                        <a href="cad_usuario.jsp?sel=${usuario.codigo}">Selecionar</a>
                        &nbsp;
                        <a href="cad_usuario.jsp?del=${usuario.codigo}">Excluir</a>
                    </td>
                </tr>
            </c:forEach>
        </table>
    </body>
</html>

