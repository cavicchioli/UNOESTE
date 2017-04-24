<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Menu do Sistema</title>
    </head>
    <body>
        <h1>Menu do Sistema</h1>
        <p>Olá ${sessionScope.usuarioLogado.nome}</p>
        <ul>
            <li>
                <a href="cad_uf.jsp">Cadastro de UF</a>
                
            </li>
            <li>
                <a href="cad_usuario.jsp">Cadastro de Usuário</a>
            </li>
            <li>
                <a href="cad_cidade.jsp">Cadastro de Cidade</a>
            </li>
            <li>
                <a href="${pageContext.request.contextPath}/logout.jsp">Sair</a>
            </li>
        </ul>
    </body>
</html>
