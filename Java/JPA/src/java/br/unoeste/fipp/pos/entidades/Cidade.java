package br.unoeste.fipp.pos.entidades;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 *
 * @author Caetano
 */
@Entity
@Table(name = "cidade")
@NamedQueries({
    @NamedQuery(name = "Cidade.findAll", query = "SELECT c FROM Cidade c"),
    @NamedQuery(name = "Cidade.findByCidCodigo", query = "SELECT c FROM Cidade c WHERE c.codigo = :codigo"),
    
    @NamedQuery(name = "Cidade.findByCidNome", query = "SELECT c FROM Cidade c WHERE c.nome = :nome")})
public class Cidade implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "cid_codigo")
    private Integer codigo;
    @Basic(optional = false)
    @Column(name = "cid_nome", length = 150, nullable = false)
    private String nome;
    @JoinColumn(name = "uf_codigo", referencedColumnName = "uf_codigo")
    @ManyToOne(optional = false)
    private Uf uf;

    public Cidade() {
    }

    public Cidade(Integer cidCodigo) {
        this.codigo = cidCodigo;
    }

    public Cidade(Integer cidCodigo, String cidNome) {
        this.codigo = cidCodigo;
        this.nome = cidNome;
    }

    public Integer getCodigo() {
        return codigo;
    }

    public void setCodigo(Integer cidCodigo) {
        this.codigo = cidCodigo;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String cidNome) {
        this.nome = cidNome;
    }

    public Uf getUf() {
        return uf;
    }

    public void setUf(Uf uf) {
        this.uf = uf;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (codigo != null ? codigo.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Cidade)) {
            return false;
        }
        Cidade other = (Cidade) object;
        return !((this.codigo == null && other.codigo != null) || (this.codigo != null && !this.codigo.equals(other.codigo)));
    }

    @Override
    public String toString() {
        return "br.unoeste.fipp.pos.entidades.Cidade[ cid_codigo=" + codigo + " ]";
    }
    
}
