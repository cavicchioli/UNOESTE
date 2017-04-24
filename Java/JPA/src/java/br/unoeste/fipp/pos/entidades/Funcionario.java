package br.unoeste.fipp.pos.entidades;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.UniqueConstraint;

/**
 *
 * @author Caetano
 */
@Entity
@Table(catalog = "postgres", schema = "public", uniqueConstraints = {
    @UniqueConstraint(columnNames = {"fun_login"})})
@NamedQueries({
    @NamedQuery(name = "Funcionario.findAll", query = "SELECT f FROM Funcionario f"),
    @NamedQuery(name = "Funcionario.findByCodigo", query = "SELECT f FROM Funcionario f WHERE f.codigo = :codigo"),
    @NamedQuery(name = "Funcionario.findByLogin", query = "SELECT f FROM Funcionario f WHERE f.login = :login")})
public class Funcionario implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "fun_codigo", nullable = false)
    private Integer codigo;
    @Basic(optional = false)
    @Column(name = "fun_nome", nullable = false, length = 100)
    private String nome;
    @Basic(optional = false)
    @Column(name = "fun_login", nullable = false, length = 15)
    private String login;
    @Basic(optional = false)
    @Column(name = "fun_senha", nullable = false, length = 32)
    private String senha;
    @Basic(optional = false)
    @Column(name = "fun_endereco", nullable = false, length = 100)
    private String endereco;
    @Column(name = "fun_endereco_numero")
    private Integer enderecoNumero;
    @Column(name = "fun_endereco_complemento", length = 15)
    private String enderecoComplemento;
    @Column(name = "fun_bairro", length = 70)
    private String bairro;
    @Basic(optional = false)
    @Column(name = "fun_ativo", nullable = false)
    private boolean ativo;
    @JoinColumn(name = "dep_codigo", referencedColumnName = "dep_codigo", nullable = false)
    @ManyToOne(optional = false, fetch = FetchType.LAZY)
    private Departamento departamento;

    public Funcionario() {
    }

    public Funcionario(Integer funCodigo) {
        this.codigo = funCodigo;
    }

    public Funcionario(Integer funCodigo, String funNome, String funLogin, String funSenha, String funEndereco, boolean funAtivo) {
        this.codigo = funCodigo;
        this.nome = funNome;
        this.login = funLogin;
        this.senha = funSenha;
        this.endereco = funEndereco;
        this.ativo = funAtivo;
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

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public String getEndereco() {
        return endereco;
    }

    public void setEndereco(String endereco) {
        this.endereco = endereco;
    }

    public Integer getEnderecoNumero() {
        return enderecoNumero;
    }

    public void setEnderecoNumero(Integer enderecoNumero) {
        this.enderecoNumero = enderecoNumero;
    }

    public String getEnderecoComplemento() {
        return enderecoComplemento;
    }

    public void setEnderecoComplemento(String enderecoComplemento) {
        this.enderecoComplemento = enderecoComplemento;
    }

    public String getBairro() {
        return bairro;
    }

    public void setBairro(String bairro) {
        this.bairro = bairro;
    }

    public boolean isAtivo() {
        return ativo;
    }

    public void setAtivo(boolean ativo) {
        this.ativo = ativo;
    }

    public Departamento getDepartamento() {
        return departamento;
    }

    public void setDepartamento(Departamento departamento) {
        this.departamento = departamento;
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
        if (!(object instanceof Funcionario)) {
            return false;
        }
        Funcionario other = (Funcionario) object;
        return !((this.codigo == null && other.codigo != null) || (this.codigo != null && !this.codigo.equals(other.codigo)));
    }

    @Override
    public String toString() {
        return "br.unoeste.fipp.pos.entidades.Funcionario[ fun_codigo=" + codigo + " ]";
    }
}
