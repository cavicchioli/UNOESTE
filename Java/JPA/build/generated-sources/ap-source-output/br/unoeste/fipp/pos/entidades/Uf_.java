package br.unoeste.fipp.pos.entidades;

import br.unoeste.fipp.pos.entidades.Cidade;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.1.v20130918-rNA", date="2015-01-26T11:33:01")
@StaticMetamodel(Uf.class)
public class Uf_ { 

    public static volatile SingularAttribute<Uf, Integer> codigo;
    public static volatile SingularAttribute<Uf, String> sigla;
    public static volatile SingularAttribute<Uf, String> nome;
    public static volatile ListAttribute<Uf, Cidade> cidades;

}