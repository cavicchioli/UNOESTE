package br.unoeste.fipp.pos.entidades;

import java.io.Serializable;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
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
@Table(catalog = "postgres", schema = "public")
@NamedQueries({
    @NamedQuery(name = "Departamento.findAll", query = "SELECT d FROM Departamento d"),
    @NamedQuery(name = "Departamento.findByDepCodigo", query = "SELECT d FROM Departamento d WHERE d.codigo = :codigo"),
    @NamedQuery(name = "Departamento.findByDepNome", query = "SELECT d FROM Departamento d WHERE d.nome = :nome")})
public class Departamento implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "dep_codigo", nullable = false)
    private Integer codigo;
    @Basic(optional = false)
    @Column(name = "dep_nome", nullable = false, length = 150)
    private String nome;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "departamento", fetch = FetchType.LAZY)
    private List<Funcionario> funcionarios;

    public Departamento() {
    }

    public Departamento(Integer depCodigo) {
        this.codigo = depCodigo;
    }

    public Departamento(Integer depCodigo, String depNome) {
        this.codigo = depCodigo;
        this.nome = depNome;
    }

    public Integer getCodigo() {
        return codigo;
    }

    public void setCodigo(Integer depCodigo) {
        this.codigo = depCodigo;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String depNome) {
        this.nome = depNome;
    }

    public List<Funcionario> getFuncionarios() {
        return funcionarios;
    }

    public void setFuncionarios(List<Funcionario> funcionarios) {
        this.funcionarios = funcionarios;
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
        if (!(object instanceof Departamento)) {
            return false;
        }
        Departamento other = (Departamento) object;
        return !((this.codigo == null && other.codigo != null) || (this.codigo != null && !this.codigo.equals(other.codigo)));
    }

    @Override
    public String toString() {
        return "br.unoeste.fipp.pos.entidades.Departamento[ dep_codigo=" + codigo + " ]";
    }
    
}
