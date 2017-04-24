package br.unoeste.fipp.jsf;

import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.validator.FacesValidator;
import javax.faces.validator.Validator;
import javax.faces.validator.ValidatorException;

/**
 *
 * @author Aluno
 */
@FacesValidator("validadorDeSenha")
public class ValidaSenha
        implements Validator {

    @Override
    public void validate(FacesContext fc,
            UIComponent uic,
            Object valor)
            throws ValidatorException {

        if (valor == null) {
            return;
        }

        final String texto = (String) valor;
        if(!texto.matches("^\\D+$")) {
        //if(texto.matches(".*\\d.*")) {
            FacesMessage msg = 
                    new FacesMessage("Senha não pode ter número!");
            throw new ValidatorException(msg);
        }

    }

}
