/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package br.unoeste.fipp.dao;

import br.unoeste.fipp.entidades.Cidade;
import br.unoeste.fipp.sql.Conexao;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Victor
 */
public class CidadeDAO implements DAO<Cidade>{
    
    @Override
    public Cidade getSingle(Object... chave) {
        if (chave[0] instanceof Integer) {
            Connection conn = Conexao.open();
            PreparedStatement ps = null;
            ResultSet rs = null;
            try {
                ps = conn.prepareStatement("select cid_codigo, cid_nome, uf_codigo from cidade where cid_codigo = ?");
                ps.setInt(1, (Integer) chave[0]);
                rs = ps.executeQuery();
                if (rs.next()) {
                    return new Cidade(rs.getInt("cid_codigo"), rs.getString("cid_nome"), new UfDAO().getSingle(rs.getInt("uf_codigo")));
                }
            } catch (SQLException ex) {
            } finally {
                Conexao.close(rs, ps, conn);
            }
        }
        return null;
    }

    @Override
    public List<Cidade> getList() {
        return getList(0);
    }

    @Override
    public List<Cidade> getList(int top) {
        if (top < 0) {
            return null;
        }
        List<Cidade> lista = null;
        Connection conn = Conexao.open();
        Statement ps = null;
        ResultSet rs = null;
        try {
            ps = conn.createStatement();
            rs = ps.executeQuery("select " + (top > 0 ? "top " + top : "") + "cid_codigo, cid_nome, uf_codigo from cidade order by cid_nome");
            lista = new ArrayList<>();
            while (rs.next()) {
                lista.add(new Cidade(rs.getInt("cid_codigo"), rs.getString("cid_nome"), new UfDAO().getSingle(rs.getInt("uf_codigo"))));
            }
        } catch (SQLException ex) {
        } finally {
            Conexao.close(rs, ps, conn);
        }
        return lista;
    }

    @Override
    public void insere(Cidade cidade) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("insert into cidade (cid_codigo, cid_nome, uf_codigo) values (?,?,?)");
            ps.setInt(1, cidade.getCodigo());
            ps.setString(2, cidade.getNome());
            ps.setInt(3, cidade.getEstado().getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro inserindo registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }

    @Override
    public void delete(Cidade cidade) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("delete from cidade where cid_codigo = ?");
            ps.setInt(1, cidade.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro removendo registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }

    @Override
    public void update(Cidade cidade) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("update cidade set cid_nome = ?, uf_codigo = ? where cid_codigo = ?");
            ps.setString(1, cidade.getNome());
            ps.setInt(2, cidade.getEstado().getCodigo());
            ps.setInt(3, cidade.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro alterando registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }
    
}
