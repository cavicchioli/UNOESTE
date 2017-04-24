<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CadastroCartoes.login" %>

<html xmlns="http://www.w3.org/1999/xhtml"><head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="classification" content="Wurth">
<meta name="description" content="Wurth">
<meta name="keywords" content="Wurth">
<meta name="Robots" content="all">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<meta name="rating" content="General">
<meta name="language" content="pt-br">
<meta name="doc-class" content="Completed">
<meta name="doc-rights" content="Public">
<title>Wurth do Brasil - Intranet</title>
<link href="includes/css/style.css" rel="stylesheet" type="text/css">
<link href="includes/css/menu_lateral.css" rel="stylesheet" type="text/css">
<!--[if lt IE 7]>
<link href="includes/css/ie6.css" rel="stylesheet" type="text/css" />
<script defer type="text/javascript" src="includes/js/pngfix.js"></script>
<![endif]-->

<!--[if lt IE 7]>
<script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
<![endif]-->
<script type="text/javascript" src="includes/js/jquery.js"></script>
<script type="text/javascript" src="includes/js/jcycle.js"></script>
    <link href="style.css" rel="stylesheet" />
<script language="javascript" type="text/javascript" src="../js/JSFunctions.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#banner')
        .before('<div id="nav">')
        	.cycle({
        	    fx: 'fade',
        	    auto: 3800,
        	    speed: 3800,
        	    pager: '#nav'
        	});
    });
</script>
<script language="JavaScript" type="text/JavaScript">
    function verifica_cookie() {
        var resp = navigator.cookieEnabled;

        if (resp == false) {
            alert("É necessario habilitar cookies para este site.");
            return false;
        }

        return true;

    }
</script>



</head>
<body>
    <div id="ajusta_box">
        <div id="box">
            <div id="header">
                <div id="header_topo">
                    <div id="header_logo">
                        <a href="../PT/Default.aspx" title="Logomarca">
                            <img src="imagens/logo.jpg" border="0" alt=""></a>
                    </div>
                    <!-- HEADER LOGO -->
                    <h1><img src="imagens/txt_topo.png" border="0" alt=""></h1>
                </div>
                <!-- HEADER TOPO -->
                <div id="header_menu">
                  
                    
                </div>
                <!-- HEADER MENU -->
                <div id="header_search">
</div><!-- HEADER SEARCH -->
</div><!-- HEADER -->

                <p align="center"><font face="Arial" size="4"><b><i>&nbsp;</i></b></font></p>                        
   
	<div id="content2">
    	<div id="login">
       
        <form id="frmLogin" method="post" action="redirect.php">
        	<fieldset>
            	<legend>Entrada do Sistema</legend>
            	
				<label for="usu">Usuário:</label>
             	<input type="text" name="usu" id="usu">
                
              	<label for="senha">Senha:</label>
              	<input type="password" name="senha" id="senha">
              
              	<label><!-- TESTE --></label>  
              	<input type="checkbox" name="esqueci_senha" id="esqueci_senha" class="checkbox"><span class="txt_check">Esqueci minha senha</span>
            	
                <label><!-- TESTE --></label>  
                <input type="submit" name="button" id="button" value="Entrar" class="btnAcao">  
        	</fieldset>
        </form>
        </div><!-- LOGIN -->
        
        <div id="txt_login">
        	Caso tenha <strong>esquecido sua senha ou Usuário Bloqueado</strong>.<br><br>

			Digitar o usuário e clicar na opção <strong>Esqueci minha senha</strong> e Pressionar o Botão Entrar.
        </div>
    </div><!-- CONTENT -->
      
﻿</div><!-- BOX -->
    <div style="clear: both">
    </div>
    <!-- CLEAR -->
    <div id="footer">
        <img src="imagens/logo_footer.jpg" border="0" alt="">
        <div id="direitos">
            © 2014 - Wurth do Brasil
        </div><!-- DIREITOS -->
    </div><!-- FOOTER -->
    </div><!-- AJUSTA BOX -->


</body></html>