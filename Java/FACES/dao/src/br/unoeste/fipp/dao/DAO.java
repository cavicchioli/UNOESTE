package br.unoeste.fipp.dao;

import java.util.List;

/**
 *
 * @param <T>
 */
public interface DAO<T> {

    /**
     * Recupera um registro de uma tabela, baseado na sua chave primária
     *
     * @param chave a chave primária
     * @return o registro correspondente, ou
     * <code>null</code> se nada for encontrado
     */
    public T getSingle(Object... chave);

    /**
     * Recupera uma lista de resistros
     *
     * @return a lista de registros, ou
     * <code>null</code> se nada for encontrado
     */
    public List<T> getList();

    /**
     * Recupera uma lista de resistros, o tamnho da lista é limitado pelo
     * parâmetro
     *
     * @param top o número máximo de registros selecionados
     * @return a lista de registros, ou
     * <code>null</code> se nada for encontrado
     */
    public List<T> getList(int top);

    /**
     * insere um registro na base de dados
     *
     * @param e objeto a ser inserido
     * @throws DAOException caso algum erro ocorra no processamento
     */
    public void insere(T e) throws DAOException;

    /**
     * Altera um registro na base de dados
     *
     * @param e objeto a ser alterado
     * @throws DAOException caso algum erro ocorra no processamento
     */
    public void update(T e) throws DAOException;

    /**
     * Exclui um registro na base de dados
     *
     * @param e objeto a ser excluido
     * @throws DAOException caso algum erro ocorra no processamento
     */
    public void delete(T e) throws DAOException;
}
