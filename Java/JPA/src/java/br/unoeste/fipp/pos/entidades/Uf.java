package br.unoeste.fipp.pos.entidades;

import java.io.Serializable;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;

/**
 *
 * @author Caetano
 */
@Entity
@Table(name = "uf")
@NamedQueries({
    @NamedQuery(name = "Uf.findAll", query = "SELECT u FROM Uf u ORDER BY u.nome"),
    @NamedQuery(name = "Uf.findByUfCodigo", query = "SELECT u FROM Uf u WHERE u.codigo = :codigo"),
    @NamedQuery(name = "Uf.findByUfNome", query = "SELECT u FROM Uf u WHERE u.nome = :nome"),
    @NamedQuery(name = "Uf.findByUfSigla", query = "SELECT u FROM Uf u WHERE u.sigla = :sigla")})
public class Uf implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "uf_codigo", nullable = false)
    private Integer codigo;
    @Basic(optional = false)
    @Column(name = "uf_nome", nullable = false, length = 100)
    private String nome;
    @Basic(optional = false)
    @Column(name = "uf_sigla", nullable = false, length = 2)
    private String sigla;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "uf")
    private List<Cidade> cidades;

    public Uf() {
    }

    public Uf(Integer ufCodigo) {
        this.codigo = ufCodigo;
    }

    public Uf(Integer ufCodigo, String ufNome, String ufSigla) {
        this.codigo = ufCodigo;
        this.nome = ufNome;
        this.sigla = ufSigla;
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

    public String getSigla() {
        return sigla;
    }

    public void setSigla(String sigla) {
        this.sigla = sigla;
    }

    public List<Cidade> getCidades() {
        return cidades;
    }

    public void setCidades(List<Cidade> cidades) {
        this.cidades = cidades;
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
        if (!(object instanceof Uf)) {
            return false;
        }
        Uf other = (Uf) object;
        return !((this.codigo == null && other.codigo != null) || (this.codigo != null && !this.codigo.equals(other.codigo)));
    }

    @Override
    public String toString() {
        return "br.unoeste.fipp.pos.entidades.Uf[ uf_codigo=" + codigo + " ]";
    }
}
