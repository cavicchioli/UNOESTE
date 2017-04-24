package br.unoeste.fipp.dao;

import br.unoeste.fipp.entidades.Contato;
import br.unoeste.fipp.sql.Conexao;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.sql.Date;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ContatoDAO implements DAO<Contato>{
    
    @Override
    public Contato getSingle(Object... chave) {
        if (chave[0] instanceof Integer) {
            Connection conn = Conexao.open();
            PreparedStatement ps = null;
            ResultSet rs = null;
            try {
                ps = conn.prepareStatement("select con_codigo, con_nome, con_email, con_telefone, con_endereco, con_bairro, cid_codigo, to_char(con_data_nasc,'DD/MM/YYYY') con_data_nasc from contato where con_codigo = ?");
                ps.setInt(1, (Integer) chave[0]);
                rs = ps.executeQuery();
                if (rs.next()) {
                    return new Contato(rs.getInt("con_codigo"), rs.getString("con_nome"), rs.getString("con_email"), rs.getString("con_telefone"), rs.getString("con_endereco"), rs.getString("con_bairro"), new CidadeDAO().getSingle(rs.getInt("cid_codigo")), rs.getString("con_data_nasc"));
                }
            } catch (SQLException ex) {
            } finally {
                Conexao.close(rs, ps, conn);
            }
        }
        return null;
    }
    
    @Override
    public List<Contato> getList() {
        return getList(0);
    }
    
    @Override
    public List<Contato> getList(int top) {
        if (top < 0) {
            return null;
        }
        List<Contato> lista = null;
        Connection conn = Conexao.open();
        Statement ps = null;
        ResultSet rs = null;
        try {
            ps = conn.createStatement();
            rs = ps.executeQuery("select " + (top > 0 ? "top " + top : "") + "con_codigo, con_nome, con_email, con_telefone, con_endereco, con_bairro, cid_codigo, to_char(con_data_nasc,'DD/MM/YYYY') con_data_nasc from contato");
            lista = new ArrayList<>();
            while (rs.next()) {
                lista.add(new Contato(rs.getInt("con_codigo"), rs.getString("con_nome"), rs.getString("con_email"), rs.getString("con_telefone"), rs.getString("con_endereco"), rs.getString("con_bairro"), new CidadeDAO().getSingle(rs.getInt("cid_codigo")), rs.getString("con_data_nasc")));
            }
        } catch (SQLException ex) {
        } finally {
            Conexao.close(rs, ps, conn);
        }
        return lista;
    }
    
    @Override
    public void insere(Contato contato) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("insert into contato (con_codigo, con_nome, con_email, con_telefone, con_endereco, con_bairro, cid_codigo, con_data_nasc) values (?,?,?,?,?,?,?,?)");
            ps.setInt(1, contato.getCodigo());
            ps.setString(2, contato.getNome());
            ps.setString(3, contato.getEmail());
            ps.setString(4, contato.getTelefone());
            ps.setString(5, contato.getEndereco());
            ps.setString(6, contato.getBairro());
            ps.setInt(7, contato.getCidade().getCodigo());
            
            DateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
            java.util.Date nascimeto = null;
            try {
                nascimeto = formatter.parse(contato.getData_nascimento());
            } catch (ParseException ex) {
                Logger.getLogger(ContatoDAO.class.getName()).log(Level.SEVERE, null, ex);
            }
            
            DateFormat formatterSql = new SimpleDateFormat("yyyy-MM-dd");
            String sql = formatterSql.format(nascimeto);
            ps.setDate(8, Date.valueOf(formatterSql.format(nascimeto)));
            ps.executeUpdate();
            
        } catch (SQLException ex) {
            throw new DAOException("Erro inserindo registro!" + ex.getMessage(), ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }
    
    @Override
    public void delete(Contato contato) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("delete from contato where con_codigo = ?");
            ps.setInt(1, contato.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro removendo registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }
    
    @Override
    public void update(Contato contato) throws DAOException {
        Connection conn = Conexao.open();
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement("update contato set con_nome = ?, con_email = ?, con_telefone = ?, con_endereco = ?, con_bairro = ?, cid_codigo = ?, con_data_nasc = ? where con_codigo = ?");
            ps.setString(1, contato.getNome());
            ps.setString(2, contato.getEmail());
            ps.setString(3, contato.getTelefone());
            ps.setString(4, contato.getEndereco());
            ps.setString(5, contato.getBairro());
            ps.setInt(6, contato.getCidade().getCodigo());
            DateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
            java.util.Date nascimeto = null;
            try {
                nascimeto = formatter.parse(contato.getData_nascimento());
            } catch (ParseException ex) {
                Logger.getLogger(ContatoDAO.class.getName()).log(Level.SEVERE, null, ex);
            }
            
            DateFormat formatterSql = new SimpleDateFormat("yyyy-MM-dd");
            String sql = formatterSql.format(nascimeto);
            ps.setDate(7, Date.valueOf(formatterSql.format(nascimeto)));
            
            ps.setInt(8, contato.getCodigo());
            ps.executeUpdate();
        } catch (SQLException ex) {
            throw new DAOException("Erro alterando registro!", ex);
        } finally {
            Conexao.close(ps, conn);
        }
    }
}
