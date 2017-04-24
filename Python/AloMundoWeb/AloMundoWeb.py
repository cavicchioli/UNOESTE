import cherrypy
import os
import Modulo1
import Partes
localDir = os.path.dirname(__file__)

from Modulo1 import *


class AloMundo(): 
    
    
    @cherrypy.expose
    def index(self):
        return ''' <p>Faltam 13 dias</p>
                  <a href="modulo1"><img src="canada.png"/> </a> 
                  <a href="login2">clique aqui para logar </a> 
                  <a href="partes"> Clique aqui para ver as partes</a>'''
        
    @cherrypy.expose    
    def modulo1(self):
        return '''<h1>Olá, recebi sua solicitação</h1>
                    
                     <a href="index"> Clique aqui para retornar </a>'''
        
    @cherrypy.expose 
    def login2(self):
        return '''
                  <form name="login2" action="login">
                   <input type="text" name="txlogin" placeholder="Login"/>
                   <input type="password" name="txsenha" placeholder="Senha"/>
                   <input type="submit" />
                  </form>'''
        
    @cherrypy.expose    
    def principal(self,txlogin,txsenha):
        if str(txsenha).__len__() ==3:
            return '''<h1>Olá, %s</h1>
                     
                        <a href="index"> Clique aqui para retornar </a>'''%(txlogin)
        else:
            raise cherrypy.InternalRedirect("index")

    def partes(self):
        yield Partes.Cabecalho()
        yield '''<body>CORPO</body>'''
        yield Partes.Rodape()
    
    
    
home = AloMundo()
home.login = Modulo1()
        
local_config={'/':{'tools.staticdir.on':True,
                   'tools.staticdir.dir':localDir}}

    
cherrypy.quickstart(home,config=local_config)