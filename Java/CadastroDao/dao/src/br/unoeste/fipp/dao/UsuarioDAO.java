package br.unoeste.fipp.dao;

import br.unoeste.fipp.entidades.Usuario;
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
public class UsuarioDAO
        implements DAO<Usuario> {

    /**
     * Seleciona um usuário a partir de seu login
     *
     * @param login o login do usuário
     * @return uma instância de Usuario ou <code>null</code> se nenhum for
     * encontrado
     */
    public Usuario getSingle(String login) {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            ps = conn.prepareStatement("select usu_codigo, usu_nome, usu_login, usu_senha, usu_adm from usuario where usu_login = ?");
            ps.setString(1, login);
            rs = ps.executeQuery();
            if (rs.next()) {
                return new Usuario(rs.getInt("usu_codigo"), rs.getString("usu_nome"), rs.getString("usu_login"), rs.getString("usu_senha"), rs.getBoolean("usu_adm"));
            }
        } catch (SQLException ex) {
        } finally {
            Conexao.close(rs, ps, conn);
        }
        return null;
    }

    @Override
    public Usuario getSingle(Object... chave) {
        if (chave[0] instanceof Integer) {
            Connection conn = Conexao.open();
            PreparedStatement ps = null;
            ResultSet rs = null;
            try {
                ps = conn.prepareStatement("select usu_codigo, usu_nome, usu_login, usu_senha, usu_adm from usuario where usu_codigo = ?");
                ps.setInt(1, (Integer) chave[0]);
                rs = ps.executeQuery();
                if (rs.next()) {
                    return new Usuario(rs.getInt("usu_codigo"), rs.getString("usu_nome"), rs.getString("usu_login"), rs.getString("usu_senha"), rs.getBoolean("usu_adm"));
                }
            } catch (SQLException ex) {
            } finally {
                Conexao.close(rs, ps, conn);
            }
        }
        return null;
    }

    @Override
    public List<Usuario> getList() {
        return getList(0);
    }

    @Override
    public List<Usuario> getList(int top) {
        if (top < 0) {
            return null;
        }
        List<Usuario> lista = null;
        Connection conn = Conexao.open();
        Statement ps = null;
        ResultSet rs = null;
        try {
            ps = conn.createStatement();
            rs = ps.executeQuery("select " + (top > 0 ? "top " + top : "") + "usu_codigo, usu_nome, usu_login, usu_senha, usu_adm from usuario");
            lista = new ArrayList<>();
            while (rs.next()) {
                lista.add(new Usuario(rs.getInt("usu_codigo"), rs.getString("usu_nome"), rs.getString("usu_login"), rs.getString("usu_senha"), rs.getBoolean("usu_adm")));
            }
        } catch (SQLException ex) {
        } finally {
            Conexao.close(rs, ps, conn);
        }
        return lista;
    }

    @Override
    public void insere(Usuario usuario) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("insert into usuario (usu_nome, usu_login, usu_senha, usu_adm) values (?,?,?,?)");
            ps.setString(1, usuario.getNome());
            ps.setString(2, usuario.getLogin());
            ps.setString(3, usuario.getSenha());
            ps.setBoolean(4, usuario.isAdministrador());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro inserindo registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }

    @Override
    public void delete(Usuario usuario) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("delete from usuario where usu_codigo = ?");
            ps.setInt(1, usuario.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro removendo registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }

    @Override
    public void update(Usuario usuario) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("update usuario set usu_nome = ?, usu_login = ?, usu_senha = ?, usu_adm = ? where usu_codigo = ?");
            ps.setString(1, usuario.getNome());
            ps.setString(2, usuario.getLogin());
            ps.setString(3, usuario.getSenha());
            ps.setBoolean(4, usuario.isAdministrador());
            ps.setInt(5, usuario.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro alterando registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }
}
