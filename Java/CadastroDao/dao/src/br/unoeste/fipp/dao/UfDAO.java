package br.unoeste.fipp.dao;

import br.unoeste.fipp.entidades.UF;
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
 */
public class UfDAO
        implements DAO<UF> {

    @Override
    public UF getSingle(Object... chave) {
        if (chave[0] instanceof Integer) {
            Connection conn = Conexao.open();
            PreparedStatement ps = null;
            ResultSet rs = null;
            try {
                ps = conn.prepareStatement("select uf_codigo, uf_nome, uf_sigla from uf where uf_codigo = ?");
                ps.setInt(1, (Integer) chave[0]);
                rs = ps.executeQuery();
                if (rs.next()) {
                    return new UF(rs.getInt("uf_codigo"), rs.getString("uf_nome"), rs.getString("uf_sigla"));
                }
            } catch (SQLException ex) {
            } finally {
                Conexao.close(rs, ps, conn);
            }
        }
        return null;
    }

    @Override
    public List<UF> getList() {
        return getList(0);
    }

    @Override
    public List<UF> getList(int top) {
        if (top < 0) {
            return null;
        }
        List<UF> lista = null;
        Connection conn = Conexao.open();
        Statement ps = null;
        ResultSet rs = null;
        try {
            ps = conn.createStatement();
            rs = ps.executeQuery("select " + (top > 0 ? "top " + top : "") + "uf_codigo, uf_nome, uf_sigla from uf order by uf_nome");
            lista = new ArrayList<>();
            while (rs.next()) {
                lista.add(new UF(rs.getInt("uf_codigo"), rs.getString("uf_nome"), rs.getString("uf_sigla")));
            }
        } catch (SQLException ex) {
        } finally {
            Conexao.close(rs, ps, conn);
        }
        return lista;
    }

    @Override
    public void insere(UF uf) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("insert into uf (uf_codigo, uf_nome, uf_sigla) values (?,?,?)");
            ps.setInt(1, uf.getCodigo());
            ps.setString(2, uf.getNome());
            ps.setString(3, uf.getSigla());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro inserindo registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }

    @Override
    public void delete(UF uf) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("delete from uf where uf_codigo = ?");
            ps.setInt(1, uf.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro removendo registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }

    @Override
    public void update(UF uf) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("update uf set uf_nome = ?, uf_sigla = ? where uf_codigo = ?");
            ps.setString(1, uf.getNome());
            ps.setString(2, uf.getSigla());
            ps.setInt(3, uf.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro alterando registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }
}
