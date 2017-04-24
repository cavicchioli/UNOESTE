package br.unoeste.fipp.entidades;

import java.util.Objects;

/**
 *
 * @author Aluno
 */
public class Cidade {

    private Integer codigo;
    private String nome;
    private UF estado;

    public Cidade() {
         this(null, null, null);
    }

    public Cidade(Integer codigo) {
        this(codigo, null, null);
    }

    public Cidade(Integer codigo, String nome, UF estado) {
        this.codigo = codigo;
        this.nome = nome;
        this.estado = estado;
    }

    public Integer getCodigo() {
        return codigo;
    }

    public void setCodigo(Integer codigo) {
        this.codigo = codigo;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public UF getEstado() {
        return estado;
    }

    public void setEstado(UF estado) {
        this.estado = estado;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 89 * hash + Objects.hashCode(this.codigo);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Cidade other = (Cidade) obj;
        return Objects.equals(this.codigo, other.codigo);
    }

}
