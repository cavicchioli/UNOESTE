package br.unoeste.fipp.pos.entidades;

import br.unoeste.fipp.pos.entidades.Departamento;
import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.1.v20130918-rNA", date="2015-01-26T11:33:01")
@StaticMetamodel(Funcionario.class)
public class Funcionario_ { 

    public static volatile SingularAttribute<Funcionario, Integer> codigo;
    public static volatile SingularAttribute<Funcionario, String> bairro;
    public static volatile SingularAttribute<Funcionario, Integer> enderecoNumero;
    public static volatile SingularAttribute<Funcionario, Boolean> ativo;
    public static volatile SingularAttribute<Funcionario, Departamento> departamento;
    public static volatile SingularAttribute<Funcionario, String> nome;
    public static volatile SingularAttribute<Funcionario, String> login;
    public static volatile SingularAttribute<Funcionario, String> senha;
    public static volatile SingularAttribute<Funcionario, String> enderecoComplemento;
    public static volatile SingularAttribute<Funcionario, String> endereco;

}