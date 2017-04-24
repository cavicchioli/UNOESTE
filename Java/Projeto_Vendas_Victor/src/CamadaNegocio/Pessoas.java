package CamadaNegocio;

import CamadaLogica.BancoDados;
import CamadaLogica.ReadOnlyTableModel;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JTable;

public class Pessoas
{
    private BancoDados banco = new BancoDados();
    protected int pes_codigo;
    protected String pes_logradouro;
    protected int pes_nro;
    protected String pes_cidade;
    protected String pes_uf;
    protected String pes_cep;
    protected int pes_ddd;
    protected String pes_telefone;

    public Pessoas()
    {
        pes_codigo = 0;
        pes_logradouro = "";
        pes_nro = 0;
        pes_cidade = "";
        pes_uf = "";
        pes_cep = "";
        pes_ddd = 0;
        pes_telefone = "";
    }

    public String getPes_cep()
    {
        return pes_cep;
    }

    public void setPes_cep(String pes_cep)
    {
        this.pes_cep = pes_cep.replace("'", "`");
    }

    public String getPes_cidade()
    {
        return pes_cidade;
    }

    public void setPes_cidade(String pes_cidade)
    {
        this.pes_cidade = pes_cidade.replace("'", "`");
    }

    public int getPes_codigo()
    {
        return pes_codigo;
    }

    public void setPes_codigo(int pes_codigo)
    {
        this.pes_codigo = pes_codigo;
    }

    public int getPes_ddd()
    {
        return pes_ddd;
    }

    public void setPes_ddd(int pes_ddd)
    {
        this.pes_ddd = pes_ddd;
    }

    public String getPes_logradouro()
    {
        return pes_logradouro;
    }

    public void setPes_logradouro(String pes_logradouro)
    {
        this.pes_logradouro = pes_logradouro.replace("'", "`");
    }

    public int getPes_nro()
    {
        return pes_nro;
    }

    public void setPes_nro(int pes_nro)
    {
        this.pes_nro = pes_nro;
    }

    public String getPes_telefone()
    {
        return pes_telefone;
    }

    public void setPes_telefone(String pes_telefone)
    {
        this.pes_telefone = pes_telefone.replace("'", "`");
    }

    public String getPes_uf()
    {
        return pes_uf;
    }

    public void setPes_uf(String pes_uf)
    {
        this.pes_uf = pes_uf.replace("'", "`");
    }
}
