package CamadaLogica;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Vector;
import javax.swing.JOptionPane;

public class BancoDados
{

    private Connection connect;

    public BancoDados()
    {
    }
 
    public Connection abrirConexao()
    {
        try
        {
            Class.forName("org.postgresql.Driver");
            String url = "jdbc:postgresql://localhost/banco_vendas?user=postgres&password=postgres123";
            connect = DriverManager.getConnection(url);
        } catch (ClassNotFoundException cnfex)
        { System.err.println("Falha ao ler o driver JDBC"); }
        catch (SQLException sqlex) { System.out.println("Impossível conectar com a base de dados"); }
        catch (Exception ex) { System.out.println("Outro erro"); }
        return (connect);
    }

    public boolean fecharConexao()
    {
        try
        {
            connect.close();
            return true;
        } catch (SQLException ex)
        { System.out.println("Erro ao desconectar!\n" + ex.toString()); }
        catch (NullPointerException e) { System.out.println("Erro ao desconectar!\n" + e.toString()); }
        return false;
    }

    //inserir, alterar, excluir
    public int executarComando(String query)
    {
        int result = 0;
        try
        {
            Statement statement = abrirConexao().createStatement(
                    ResultSet.TYPE_SCROLL_INSENSITIVE,
                    ResultSet.CONCUR_READ_ONLY);
            statement.execute("BEGIN;");
            result = statement.executeUpdate(query);
            if (result == 0)
            {
                System.out.println("Erro!");
                statement.execute("ROLLBACK;");
            }
            else
                statement.execute("COMMIT;");
            statement.close();
            fecharConexao();
        } catch (SQLException ex)
        { System.out.println("Erro: " + ex.getErrorCode() + " => " + ex.getMessage()); }
        return result;
    }

    //inserir quando tem heranca
    public int executarInsercaoTransacao(Vector vetor, String chave)
    {
        int result = 0;
        int codigo = 0;
        String query = "";
        try
        {
            Statement statement = abrirConexao().createStatement(
                    ResultSet.TYPE_SCROLL_INSENSITIVE,
                    ResultSet.CONCUR_READ_ONLY);
            statement.execute("BEGIN;");
            //insercao na tabela principal
            result = statement.executeUpdate((String) vetor.elementAt(0));
            if (result != 0)
            {
                //executando o select max
                ResultSet rs = statement.executeQuery((String) vetor.elementAt(1));
                rs.next();
                if (rs.getRow() != 0)
                    codigo = rs.getInt(chave);

                //insercao nas outras tabelas
                for (int i = 2; i < vetor.size(); i += 2)
                    query = query + (String) vetor.elementAt(i) + codigo +
                            (String) vetor.elementAt(i + 1) + "; ";
                
                result = statement.executeUpdate(query);
            }
            if (result == 0)
            {
                System.out.println("Erro!");
                statement.execute("ROLLBACK;");
            }
            else
                statement.execute("COMMIT;");
            statement.close();
            fecharConexao();
        } catch (SQLException ex)
        { System.out.println("Erro: " + ex.getErrorCode() + " => " + ex.getMessage()); }
        return result;
    }

    //excluir de varias tabelas, alterar em varias tabelas
    public int executarComandosTransacao(Vector vetor)
    {
        int result = 0;
        String query = "";
        try
        {
            Statement statement = abrirConexao().createStatement(
                    ResultSet.TYPE_SCROLL_INSENSITIVE,
                    ResultSet.CONCUR_READ_ONLY);
            statement.execute("BEGIN;");
            for (int i = 0; i < vetor.size(); i++)
                query = query + (String) vetor.elementAt(i) + "; ";

            result = statement.executeUpdate(query);
            if (result == 0)
            {
                System.out.println("Erro!");
                statement.execute("ROLLBACK;");
            }
            else
                statement.execute("COMMIT;");
            statement.close();
            fecharConexao();
        } catch (SQLException ex)
        { System.out.println("Erro: " + ex.getErrorCode() + " => " + ex.getMessage()); }
        return result;
    }

    //consultar 
    public ResultSet retornaResultSet(String query)
    {
        ResultSet rs = null;
        try
        {
            Statement statement = abrirConexao().createStatement(
                    ResultSet.TYPE_SCROLL_INSENSITIVE,
                    ResultSet.CONCUR_READ_ONLY);
            rs = statement.executeQuery(query);
            fecharConexao();
        } catch (SQLException sqlex)
        {
            System.out.println("Erro na Consulta");
            rs = null;
        }
        return (rs);
    }
    
    public void realizaRestore() throws IOException, InterruptedException{        
       final List<String> comandos = new ArrayList<String>();        
           
       comandos.add("C:\\Program Files (x86)\\PostgreSQL\\9.3\\bin\\pg_restore.exe"); //testado no windows xp  
         
         
       comandos.add("-i");        
       comandos.add("-h");        
       comandos.add("localhost");    //ou   comandos.add("192.168.0.1");   
       comandos.add("-p");        
       comandos.add("5432");        
       comandos.add("-U");        
       comandos.add("postgres");        
       comandos.add("-d");        
       comandos.add("banco_vendas");       
       comandos.add("-v");        
           
       comandos.add("D:\\bkp.backup");   // eu utilizei meu C:\ e D:\ para os testes e gravei o backup com sucesso.    
  
       ProcessBuilder pb = new ProcessBuilder(comandos);        
           
       pb.environment().put("PGPASSWORD", "postgres123");     //Somente coloque sua senha           
           
       try {        
           final Process process = pb.start();        
       
           final BufferedReader r = new BufferedReader(        
               new InputStreamReader(process.getErrorStream()));        
           String line = r.readLine();        
           while (line != null) {        
           System.err.println(line);        
           line = r.readLine();        
           }        
           r.close();        
       
           process.waitFor();      
           process.destroy();   
           JOptionPane.showMessageDialog(null,"Restore realizado com sucesso.");    
       
       } catch (IOException e) {        
           e.printStackTrace();        
       } catch (InterruptedException ie) {        
           ie.printStackTrace();        
       }           
             
   }     
    
        public void realizaBackup() throws IOException, InterruptedException{        
           final List<String> comandos = new ArrayList<String>();        
                  
           comandos.add("C:\\Program Files (x86)\\PostgreSQL\\9.3\\bin\\pg_dump.exe");    // esse é meu caminho    
             
           comandos.add("-i");        
           comandos.add("-h");        
           comandos.add("localhost");     //ou  comandos.add("192.168.0.1");   
           comandos.add("-p");        
           comandos.add("5432");        
           comandos.add("-U");        
           comandos.add("postgres");        
           comandos.add("-F");        
           comandos.add("c");        
           comandos.add("-b");        
           comandos.add("-v");        
           comandos.add("-f");        
               
           comandos.add("D:\\bkp.backup");   // eu utilizei meu C:\ e D:\ para os testes e gravei o backup com sucesso.    
           comandos.add("banco_vendas");        
           ProcessBuilder pb = new ProcessBuilder(comandos);        
               
           pb.environment().put("PGPASSWORD", "postgres123");      //Somente coloque sua senha           
               
           try {        
               final Process process = pb.start();        
           
               final BufferedReader r = new BufferedReader(        
                   new InputStreamReader(process.getErrorStream()));        
               String line = r.readLine();        
               while (line != null) {        
               System.err.println(line);        
               line = r.readLine();        
               }        
               r.close();        
           
               process.waitFor();      
               process.destroy();   
               JOptionPane.showMessageDialog(null,"backup realizado com sucesso.");    
           
           } catch (IOException e) {        
               e.printStackTrace();        
           } catch (InterruptedException ie) {        
               ie.printStackTrace();        
           }           
                 
       } 
}
