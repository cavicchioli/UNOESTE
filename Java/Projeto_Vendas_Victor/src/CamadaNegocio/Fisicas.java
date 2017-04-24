package CamadaNegocio;

import java.sql.ResultSet;
import java.sql.SQLException;
import CamadaLogica.BancoDados;

public class Fisicas extends Pessoas
{
   private BancoDados banco = new BancoDados();
    protected int fis_codigo;
    protected String fis_nome;
    protected String fis_rg;
    protected String fis_cpf;

    public Fisicas()
    {
        super();
        fis_codigo = 0;
        fis_nome = "";
        fis_rg = "";
        fis_cpf = "";
    }
    
    public int getFis_codigo()
    {
        return fis_codigo;
    }

    public void setFis_codigo(int fis_codigo)
    {
        this.fis_codigo = fis_codigo;
    }

    public String getFis_cpf()
    {
        return fis_cpf;
    }

    public void setFis_cpf(String fis_cpf)
    {
        this.fis_cpf = fis_cpf.replace("'", "`");;
    }

    public String getFis_nome()
    {
        return fis_nome;
    }

    public void setFis_nome(String fis_nome)
    {
        this.fis_nome = fis_nome.replace("'", "`");
    }

    public String getFis_rg()
    {
        return fis_rg;
    }

    public void setFis_rg(String fis_rg)
    {
        this.fis_rg = fis_rg.replace("'", "`");
    }
}
