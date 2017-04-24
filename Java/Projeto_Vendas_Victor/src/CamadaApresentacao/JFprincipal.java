package CamadaApresentacao;

import CamadaLogica.BancoDados;
import java.awt.Dimension;
import java.awt.Toolkit;
import java.sql.Date;
import java.sql.ResultSet;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRResultSetDataSource;
import net.sf.jasperreports.engine.JasperExportManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.view.JasperViewer;
import net.sourceforge.jprinterdialog.JPrinterDialog;

public class JFprincipal extends javax.swing.JFrame
{
    /** Creates new form JFprincipal */
    public JFprincipal()
    {
        // captura a dimensão da tela
        Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();

        // seta com a máxima dimensão
        setSize(screenSize);

        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jMenuBarra = new javax.swing.JMenuBar();
        jMcadastros = new javax.swing.JMenu();
        jMIcadastroProdutos = new javax.swing.JMenuItem();
        jMICadastroClientes = new javax.swing.JMenuItem();
        jMICadastroFuncionarios = new javax.swing.JMenuItem();
        jMICadastroEmpresas = new javax.swing.JMenuItem();
        jMmovimentacoes = new javax.swing.JMenu();
        itemVendas = new javax.swing.JMenuItem();
        jMrelatorios = new javax.swing.JMenu();
        jMenuItem3 = new javax.swing.JMenuItem();
        relFuncionarios = new javax.swing.JMenuItem();
        relProdutos = new javax.swing.JMenuItem();
        jMenuItem1 = new javax.swing.JMenuItem();
        itemVendasFuncionarios = new javax.swing.JMenuItem();
        jMenu1 = new javax.swing.JMenu();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Sistema de Vendas");

        jMcadastros.setText("Cadastros");

        jMIcadastroProdutos.setText("Cadastro de Produtos");
        jMIcadastroProdutos.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMIcadastroProdutosActionPerformed(evt);
            }
        });
        jMcadastros.add(jMIcadastroProdutos);

        jMICadastroClientes.setText("Cadastro de Clientes");
        jMICadastroClientes.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMICadastroClientesActionPerformed(evt);
            }
        });
        jMcadastros.add(jMICadastroClientes);

        jMICadastroFuncionarios.setText("Cadastro de Funcionarios");
        jMICadastroFuncionarios.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMICadastroFuncionariosActionPerformed(evt);
            }
        });
        jMcadastros.add(jMICadastroFuncionarios);

        jMICadastroEmpresas.setText("Cadastro de Empresas");
        jMICadastroEmpresas.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMICadastroEmpresasActionPerformed(evt);
            }
        });
        jMcadastros.add(jMICadastroEmpresas);

        jMenuBarra.add(jMcadastros);

        jMmovimentacoes.setText("Movimentações");

        itemVendas.setText("Vendas");
        itemVendas.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                itemVendasActionPerformed(evt);
            }
        });
        jMmovimentacoes.add(itemVendas);

        jMenuBarra.add(jMmovimentacoes);

        jMrelatorios.setText("Relatórios");

        jMenuItem3.setText("Clientes");
        jMenuItem3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem3ActionPerformed(evt);
            }
        });
        jMrelatorios.add(jMenuItem3);

        relFuncionarios.setText("Funcionários");
        relFuncionarios.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                relFuncionariosActionPerformed(evt);
            }
        });
        jMrelatorios.add(relFuncionarios);

        relProdutos.setText("Produtos");
        relProdutos.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                relProdutosActionPerformed(evt);
            }
        });
        jMrelatorios.add(relProdutos);

        jMenuItem1.setText("Vendas/Clientes ");
        jMenuItem1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem1ActionPerformed(evt);
            }
        });
        jMrelatorios.add(jMenuItem1);

        itemVendasFuncionarios.setText("Vendas/Funcionários");
        itemVendasFuncionarios.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                itemVendasFuncionariosActionPerformed(evt);
            }
        });
        jMrelatorios.add(itemVendasFuncionarios);

        jMenuBarra.add(jMrelatorios);

        jMenu1.setText("Backup & Restore");
        jMenu1.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                jMenu1MouseClicked(evt);
            }
        });
        jMenu1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenu1ActionPerformed(evt);
            }
        });
        jMenuBarra.add(jMenu1);

        setJMenuBar(jMenuBarra);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 684, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 434, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents

    private void jMIcadastroProdutosActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jMIcadastroProdutosActionPerformed
    {//GEN-HEADEREND:event_jMIcadastroProdutosActionPerformed
       CadastroProdutos cadProd = new CadastroProdutos(this, true);
       cadProd.setVisible(true);
    }//GEN-LAST:event_jMIcadastroProdutosActionPerformed

    private void jMICadastroClientesActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMICadastroClientesActionPerformed
        CadastroCliente cadCli = new CadastroCliente(this, true);
        cadCli.setVisible(true);
    }//GEN-LAST:event_jMICadastroClientesActionPerformed

    private void jMICadastroFuncionariosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMICadastroFuncionariosActionPerformed
        CadastroFuncionarios cadFun = new CadastroFuncionarios(this, true);
        cadFun.setVisible(true);
    }//GEN-LAST:event_jMICadastroFuncionariosActionPerformed

    private void jMICadastroEmpresasActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMICadastroEmpresasActionPerformed
        CadastroEmpresas cadEmp = new CadastroEmpresas(this,true);
        cadEmp.setVisible(true);
    }//GEN-LAST:event_jMICadastroEmpresasActionPerformed

    private void jMenu1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenu1ActionPerformed
        // TODO add your handling code here:
        BackupRestore frm = new BackupRestore(this,true);
        frm.setVisible(true);
    }//GEN-LAST:event_jMenu1ActionPerformed

    private void jMenu1MouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_jMenu1MouseClicked
        // TODO add your handling code here:
        BackupRestore frm = new BackupRestore(this,true);
        frm.setVisible(true);
    }//GEN-LAST:event_jMenu1MouseClicked

    private void relFuncionariosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_relFuncionariosActionPerformed
       BancoDados banco = new BancoDados();
try
{
  String jasperPrint = 
     JasperFillManager.fillReportToFile("relatorios/relFuncionarios.jasper", 
     null, banco.abrirConexao());
  JasperViewer viewer = new JasperViewer(jasperPrint, false, false);
  viewer.setExtendedState(JasperViewer.MAXIMIZED_BOTH);//maximizado
  viewer.setTitle("Relatório de Funcionários");//titulo do relatório
  viewer.setVisible(true);
} catch (JRException erro)
{
  erro.printStackTrace();
}        // TODO add your handling code here:
    }//GEN-LAST:event_relFuncionariosActionPerformed

    private void jMenuItem3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem3ActionPerformed
       BancoDados banco = new BancoDados();
try
{
  String jasperPrint = 
     JasperFillManager.fillReportToFile("relatorios/relClientes.jasper", 
     null, banco.abrirConexao());
  JasperViewer viewer = new JasperViewer(jasperPrint, false, false);
  viewer.setExtendedState(JasperViewer.MAXIMIZED_BOTH);//maximizado
  viewer.setTitle("Relatório de Clientes");//titulo do relatório
  viewer.setVisible(true);
} catch (JRException erro)
{
  erro.printStackTrace();
}        // TODO add your handling code here:
    }//GEN-LAST:event_jMenuItem3ActionPerformed

    private void relProdutosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_relProdutosActionPerformed
       BancoDados banco = new BancoDados();
try
{
  String jasperPrint = 
     JasperFillManager.fillReportToFile("relatorios/relProdutos.jasper", 
     null, banco.abrirConexao());
  JasperViewer viewer = new JasperViewer(jasperPrint, false, false);
  viewer.setExtendedState(JasperViewer.MAXIMIZED_BOTH);//maximizado
  viewer.setTitle("Relatório de Produtos");//titulo do relatório
  viewer.setVisible(true);
} catch (JRException erro)
{
  erro.printStackTrace();
}        // TODO add your handling code here:
    }//GEN-LAST:event_relProdutosActionPerformed

    private void itemVendasActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_itemVendasActionPerformed
        Vendas frm = new Vendas(this,true);
        frm.setVisible(true);
    }//GEN-LAST:event_itemVendasActionPerformed

    private void jMenuItem1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem1ActionPerformed
    relVendasPeriodo frm =new relVendasPeriodo();
frm.setVisible(true);
    }//GEN-LAST:event_jMenuItem1ActionPerformed

    private void itemVendasFuncionariosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_itemVendasFuncionariosActionPerformed
        relVendasFuncionarios frm;
        try {
            frm = new relVendasFuncionarios(this,true);
            frm.setVisible(true);
        } catch (Exception ex) {
            Logger.getLogger(JFprincipal.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_itemVendasFuncionariosActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[])
    {
        java.awt.EventQueue.invokeLater(new Runnable()
        {
            public void run()
            {
                new JFprincipal().setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JMenuItem itemVendas;
    private javax.swing.JMenuItem itemVendasFuncionarios;
    private javax.swing.JMenuItem jMICadastroClientes;
    private javax.swing.JMenuItem jMICadastroEmpresas;
    private javax.swing.JMenuItem jMICadastroFuncionarios;
    private javax.swing.JMenuItem jMIcadastroProdutos;
    private javax.swing.JMenu jMcadastros;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenuBar jMenuBarra;
    private javax.swing.JMenuItem jMenuItem1;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JMenu jMmovimentacoes;
    private javax.swing.JMenu jMrelatorios;
    private javax.swing.JMenuItem relFuncionarios;
    private javax.swing.JMenuItem relProdutos;
    // End of variables declaration//GEN-END:variables
}
