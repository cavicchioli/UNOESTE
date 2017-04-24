package br.unoeste.fipp.jsf;

import javax.faces.application.FacesMessage;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Aluno
 */
public final class JSFUtil {

    private JSFUtil() {
    }

    public static FacesContext getFacesContext() {
        return FacesContext.getCurrentInstance();
    }

    public static FacesMessage geraMensagem(String texto) {
        return new FacesMessage(texto);
    }

    public static void setErrorMessage(String msg, String id) {
        getFacesContext().addMessage(id, geraMensagem(msg));
    }

    public static void setErrorMessage(String msg) {
        setErrorMessage(msg, null);
    }

    public static ExternalContext getExternalContext() {
        return getFacesContext().getExternalContext();
    }
    
    public static HttpSession getSession() {
        return (HttpSession)getExternalContext().getSession(true);
    }
    
}
