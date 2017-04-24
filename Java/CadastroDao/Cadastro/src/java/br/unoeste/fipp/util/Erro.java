package br.unoeste.fipp.util;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * Classe para o tratamento de mensagens de erro
 *
 * @author Aluno
 */
public final class Erro
        implements Serializable {

    private final List<String> erros;

    public Erro() {
        erros = new ArrayList<>();
    }

    public Erro(String mensagem) {
        erros = new ArrayList<>();
        erros.add(mensagem);
    }

    public void add(String mensagem) {
        erros.add(mensagem);
    }
    
    public boolean isExisteErros() {
        return !erros.isEmpty();
    }
    
    public List<String> getErros() {
        return erros;
    }

}
