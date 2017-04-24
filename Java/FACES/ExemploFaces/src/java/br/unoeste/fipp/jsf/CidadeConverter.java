package br.unoeste.fipp.jsf;

import br.unoeste.fipp.dao.CidadeDAO;
import br.unoeste.fipp.entidades.Cidade;
import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.ConverterException;
import javax.faces.convert.FacesConverter;

@FacesConverter("CidadeConverter")
public class CidadeConverter implements Converter{
    
    @Override
    public Object getAsObject(FacesContext fc, UIComponent uic, String string) {
        if (string != null) {
            try {
                int codigo = Integer.parseInt(string);
                Cidade city = CidadeDAO.getCidade(codigo);
                return city;
            } catch (NumberFormatException ex) {
                throw new ConverterException(
                        new FacesMessage("Erro convertendo Cidade!"));
            }
        }
        return null;
    }

    @Override
    public String getAsString(FacesContext fc, UIComponent uic, Object objeto) {
        if (objeto == null) {
            return "";
        }
        final Cidade cidade = (Cidade) objeto;
        if (cidade.getCodigo() == null) {
            return null;
        }
        return cidade.getCodigo().toString();
    }
    
}
