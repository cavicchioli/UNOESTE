package br.unoeste.fipp.jsf;

import java.util.ArrayList;
import java.util.List;
import javax.faces.application.NavigationHandler;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.faces.event.PhaseEvent;
import javax.faces.event.PhaseId;
import javax.faces.event.PhaseListener;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Aluno
 */
public class AutenticaPhase
        implements PhaseListener {

    private final List<String> liberados;

    public AutenticaPhase() {
        this.liberados = new ArrayList<>();
        liberados.add("/index.xhtml");
    }

    private boolean isLiberado(String url) {
        for (String nome : liberados) {
            if (nome.equals(url)) {
                return true;
            }
        }
        return false;
    }

    @Override
    public void afterPhase(PhaseEvent pe) {
        FacesContext ctx = pe.getFacesContext();
        String pagina = ctx.getViewRoot().getViewId();

        if (!isLiberado(pagina)) {
            ExternalContext ectx = ctx.getExternalContext();
            HttpSession session = (HttpSession) ectx.getSession(true);
            if (session.getAttribute("usuarioLogado") == null) {
                session.invalidate();
                NavigationHandler nav = ctx.getApplication()
                        .getNavigationHandler();
                nav.handleNavigation(ctx, null, "/index.xhtml");
            }
        }

    }

    @Override
    public void beforePhase(PhaseEvent pe) {
    }

    @Override
    public PhaseId getPhaseId() {
        return PhaseId.RESTORE_VIEW;
    }

}
