package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.UfDAO;
import br.unoeste.fipp.entidades.UF;
import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.ConverterException;
import javax.faces.convert.FacesConverter;

/**
 *
 * @author Aluno
 */
@FacesConverter("UFConverter")
public class UFConverter implements Converter {

    @Override
    public Object getAsObject(FacesContext fc, UIComponent uic, String string) {
        if (string != null) {
            try {
                int codigo = Integer.parseInt(string);
                UF estado = (new UfDAO()).getSingle(codigo);
                return estado;
            } catch (NumberFormatException ex) {
                throw new ConverterException(
                        new FacesMessage("Erro convertendo UF!"));
            }
        }
        return null;
    }

    @Override
    public String getAsString(FacesContext fc, UIComponent uic, Object objeto) {
        if (objeto == null) {
            return "";
        }
        final UF uf = (UF) objeto;
        if (uf.getCodigo() == null) {
            return null;
        }
        return uf.getCodigo().toString();
    }

}
