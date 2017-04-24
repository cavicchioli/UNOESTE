package br.unoeste.fipp.jsf;

import static com.sun.faces.facelets.util.Path.context;
import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.faces.component.UIInput;
import javax.faces.context.FacesContext;
import javax.faces.validator.FacesValidator;
import javax.faces.validator.Validator;
import javax.faces.validator.ValidatorException;
/**
 *
 * @author Aluno
 */
@FacesValidator("validadorConfirmacaoSenha")
public class ValidaConfSenha
        implements Validator {

    @Override
    public void validate(FacesContext context, UIComponent component, Object value)
            throws ValidatorException {
        UIInput txtSenha = (UIInput) context.getViewRoot().findComponent("form:txtSenha");
        if (txtSenha == null) {
            throw new IllegalArgumentException(String.format("Não encontrei input."));
        }
       
        String senha = (String) txtSenha.getValue();
        String confirmacao = (String) value;

        if (senha != null && senha.length() != 0 && !senha.equals(confirmacao)) {
            throw new ValidatorException(new FacesMessage("A Confirmação de Senha e Senha não Conferem."));
        }
    }
}
