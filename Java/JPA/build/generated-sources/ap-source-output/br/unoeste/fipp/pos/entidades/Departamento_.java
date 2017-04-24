package br.unoeste.fipp.pos.entidades;

import br.unoeste.fipp.pos.entidades.Funcionario;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.1.v20130918-rNA", date="2015-01-26T11:33:01")
@StaticMetamodel(Departamento.class)
public class Departamento_ { 

    public static volatile SingularAttribute<Departamento, Integer> codigo;
    public static volatile ListAttribute<Departamento, Funcionario> funcionarios;
    public static volatile SingularAttribute<Departamento, String> nome;

}