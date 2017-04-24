import cherrypy

class Modulo1:
    
    @cherrypy.expose    
    def index(self,txlogin,txsenha):
        if str(txsenha).__len__() ==3:
            return '''<h1>Olá, %s</h1>
                            
                             <a href="index"> Clique aqui para retornar </a>'''%(txlogin)
        else:
            raise cherrypy.HTTPRedirect("/..")