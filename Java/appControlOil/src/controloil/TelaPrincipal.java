package controloil;
import java.sql.ResultSet;
import java.util.ArrayList;
import javax.swing.JOptionPane;
import net.sf.jasperreports.engine.JRResultSetDataSource;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.view.JasperViewer;

public class TelaPrincipal extends javax.swing.JFrame {

    public TelaPrincipal() {
        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jToolBar1 = new javax.swing.JToolBar();
        btnProdutos = new javax.swing.JButton();
        btnClientes = new javax.swing.JButton();
        btnMarcas = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenuItem1 = new javax.swing.JMenuItem();
        jMenuItem2 = new javax.swing.JMenuItem();
        jMenuItem4 = new javax.swing.JMenuItem();
        jSeparator1 = new javax.swing.JPopupMenu.Separator();
        jMenuItem3 = new javax.swing.JMenuItem();
        jMenu2 = new javax.swing.JMenu();
        jMenuItem5 = new javax.swing.JMenuItem();
        jMenu4 = new javax.swing.JMenu();
        jMenuItem7 = new javax.swing.JMenuItem();
        jMenuItem8 = new javax.swing.JMenuItem();
        jMenuItem10 = new javax.swing.JMenuItem();
        jMenuItem9 = new javax.swing.JMenuItem();
        jMenu3 = new javax.swing.JMenu();
        jMenuItem6 = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Control Oil v 0.1");

        jToolBar1.setBackground(new java.awt.Color(204, 204, 204));
        jToolBar1.setRollover(true);
        jToolBar1.setPreferredSize(new java.awt.Dimension(154, 55));

        btnProdutos.setBackground(new java.awt.Color(204, 204, 204));
        btnProdutos.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/oil1.png"))); // NOI18N
        btnProdutos.setFocusable(false);
        btnProdutos.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        btnProdutos.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        btnProdutos.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnProdutosActionPerformed(evt);
            }
        });
        jToolBar1.add(btnProdutos);

        btnClientes.setBackground(new java.awt.Color(204, 204, 204));
        btnClientes.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/user2.png"))); // NOI18N
        btnClientes.setFocusable(false);
        btnClientes.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        btnClientes.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        btnClientes.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnClientesActionPerformed(evt);
            }
        });
        jToolBar1.add(btnClientes);

        btnMarcas.setBackground(new java.awt.Color(204, 204, 204));
        btnMarcas.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/brand3.png"))); // NOI18N
        btnMarcas.setFocusable(false);
        btnMarcas.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        btnMarcas.setPreferredSize(new java.awt.Dimension(47, 47));
        btnMarcas.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        btnMarcas.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnMarcasActionPerformed(evt);
            }
        });
        jToolBar1.add(btnMarcas);

        getContentPane().add(jToolBar1, java.awt.BorderLayout.PAGE_START);

        jLabel1.setBackground(new java.awt.Color(51, 51, 51));
        jLabel1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/i_background.jpg"))); // NOI18N
        getContentPane().add(jLabel1, java.awt.BorderLayout.CENTER);

        jMenu1.setText("Cadastros");

        jMenuItem1.setMnemonic('M');
        jMenuItem1.setText("Marcas");
        jMenuItem1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem1ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem1);

        jMenuItem2.setMnemonic('P');
        jMenuItem2.setText("Produtos");
        jMenuItem2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem2ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem2);

        jMenuItem4.setText("Clientes");
        jMenuItem4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem4ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem4);
        jMenu1.add(jSeparator1);

        jMenuItem3.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_X, java.awt.event.InputEvent.CTRL_MASK));
        jMenuItem3.setMnemonic('S');
        jMenuItem3.setText("Sair");
        jMenuItem3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem3ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem3);

        jMenuBar1.add(jMenu1);

        jMenu2.setText("Movimentações");

        jMenuItem5.setText("Troca de Oleo");
        jMenuItem5.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem5ActionPerformed(evt);
            }
        });
        jMenu2.add(jMenuItem5);

        jMenuBar1.add(jMenu2);

        jMenu4.setText("Relatórios");

        jMenuItem7.setText("Clientes");
        jMenuItem7.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem7ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem7);

        jMenuItem8.setText("Lista de Preços");
        jMenuItem8.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem8ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem8);

        jMenuItem10.setText("Trocas e Itens");
        jMenuItem10.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem10ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem10);

        jMenuItem9.setText("Trocas por período");
        jMenuItem9.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem9ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem9);

        jMenuBar1.add(jMenu4);

        jMenu3.setText("Ajuda");

        jMenuItem6.setText("Sobre");
        jMenuItem6.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem6ActionPerformed(evt);
            }
        });
        jMenu3.add(jMenuItem6);

        jMenuBar1.add(jMenu3);

        setJMenuBar(jMenuBar1);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-1002)/2, (screenSize.height-597)/2, 1002, 597);
    }// </editor-fold>//GEN-END:initComponents
    
    private void jMenuItem2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem2ActionPerformed
         TelaCadProduto dialog = new TelaCadProduto(this, true);
         dialog.setVisible(true);
    }//GEN-LAST:event_jMenuItem2ActionPerformed

    private void btnProdutosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnProdutosActionPerformed
        jMenuItem2ActionPerformed(evt);
    }//GEN-LAST:event_btnProdutosActionPerformed

    private void jMenuItem4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem4ActionPerformed
        // TODO add your handling code here:la
        TelaCadCliente dialog = new TelaCadCliente(this,true);
        dialog.setVisible(true);
    }//GEN-LAST:event_jMenuItem4ActionPerformed

    private void btnClientesActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnClientesActionPerformed
        jMenuItem4ActionPerformed(evt);
    }//GEN-LAST:event_btnClientesActionPerformed

    private void jMenuItem1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem1ActionPerformed
       TelaCadMarca f = new TelaCadMarca(this,true);
       f.setVisible(true);
    }//GEN-LAST:event_jMenuItem1ActionPerformed

    private void btnMarcasActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnMarcasActionPerformed
        jMenuItem1ActionPerformed(evt);
    }//GEN-LAST:event_btnMarcasActionPerformed

    private void jMenuItem3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem3ActionPerformed
       dispose();
    }//GEN-LAST:event_jMenuItem3ActionPerformed

    private void jMenuItem5ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem5ActionPerformed
        TelaTrocaDeOleo d = new TelaTrocaDeOleo(null,true);
        d.setVisible(true);
    }//GEN-LAST:event_jMenuItem5ActionPerformed

    private void jMenuItem8ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem8ActionPerformed
       String sql ="select * from produto, marca where produto.mar_cod = marca.mar_cod order by pro_desc";
       
       ResultSet rs= Banco.con.consultar(sql);
       
       JRResultSetDataSource jrRS1 = new JRResultSetDataSource(rs);
  
       try
       {
            String jasperPrint =           
            JasperFillManager.fillReportToFile("reports\\rel_produtos.jasper",null, jrRS1);
            //JasperFillManager.fillReportToFile("J:\\__2 SEMESTRE\\F2\\Projetos\\appControlOil\\reports\\rel_produtos.jasper",null, jrRS1);
            JasperViewer viewer = new JasperViewer(jasperPrint, false, false);
  
            viewer.setExtendedState(JasperViewer.MAXIMIZED_BOTH);//maximizado
            viewer.setTitle("Relatório de Produtos");//titulo do relatório
            viewer.setVisible(true);
       }catch(Exception e){JOptionPane.showMessageDialog(this, e.getMessage());
       }
    }//GEN-LAST:event_jMenuItem8ActionPerformed

    private void jMenuItem7ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem7ActionPerformed
        String sql ="select * from cliente order by cli_nome";
       
        ResultSet rs= Banco.con.consultar(sql);
       
        JRResultSetDataSource jrRS2 = new JRResultSetDataSource(rs);
  //chamando o relatório
       try
       {
            String jasperPrint = JasperFillManager.fillReportToFile("reports\\rel_clientes.jasper",null, jrRS2);           
            //JasperFillManager.fillReportToFile("G:\\__2 SEMESTRE\\F2\\Projetos\\appControlOil\\reports\\rel_clientes.jasper",null, jrRS);
            
            JasperViewer viewer = new JasperViewer(jasperPrint, false, false);
  
            viewer.setExtendedState(JasperViewer.MAXIMIZED_BOTH);//maximizado
            viewer.setTitle("Relatório de Clientes");//titulo do relatório
            viewer.setVisible(true);
       }catch(Exception e){JOptionPane.showMessageDialog(this, e.getMessage());
       }
    }//GEN-LAST:event_jMenuItem7ActionPerformed

    private void jMenuItem9ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem9ActionPerformed
        String sql ="select troca.*, cliente.cli_nome from troca, cliente where troca.cli_cod=cliente.cli_cod order by tro_data";
       
       ResultSet rs= Banco.con.consultar(sql);
       
       JRResultSetDataSource jrRS3 = new JRResultSetDataSource(rs);
  //chamando o relatório
       try
       {
            String jasperPrint =           
            //JasperFillManager.fillReportToFile("G:\\__2 SEMESTRE\\F2\\Projetos\\appControlOil\\reports\\rel_produtos.jasper",null, jrRS);
            JasperFillManager.fillReportToFile("reports\\rel_troca.jasper",null, jrRS3);
            JasperViewer viewer = new JasperViewer(jasperPrint, false, false);
  
            viewer.setExtendedState(JasperViewer.MAXIMIZED_BOTH);//maximizado
            viewer.setTitle("Relatório de Trocas por Período");//titulo do relatório
            viewer.setVisible(true);
       }catch(Exception e){JOptionPane.showMessageDialog(this, e.getMessage());
       }
    }//GEN-LAST:event_jMenuItem9ActionPerformed

    private void jMenuItem10ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem10ActionPerformed
        String sql ="select troca.*, troca_itens.* , cliente.cli_nome, produto.pro_desc from troca, troca_itens, cliente, produto where troca.cli_cod = cliente.cli_cod and troca_itens.pro_cod= produto.pro_cod order by tro_data";
       
       ResultSet rs= Banco.con.consultar(sql);
       
       JRResultSetDataSource jrRS4 = new JRResultSetDataSource(rs);
  //chamando o relatório
       try
       {
            String jasperPrint =           
            //JasperFillManager.fillReportToFile("G:\\__2 SEMESTRE\\F2\\Projetos\\appControlOil\\reports\\rel_produtos.jasper",null, jrRS);
            JasperFillManager.fillReportToFile("reports\\rel_trocaitens.jasper",null, jrRS4);
            JasperViewer viewer = new JasperViewer(jasperPrint, false, false);
  
            viewer.setExtendedState(JasperViewer.MAXIMIZED_BOTH);//maximizado
            viewer.setTitle("Relatório de Trocas e Itens");//titulo do relatório
            viewer.setVisible(true);
       }catch(Exception e){JOptionPane.showMessageDialog(this, e.getMessage());
       }
    }//GEN-LAST:event_jMenuItem10ActionPerformed

    private void jMenuItem6ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem6ActionPerformed
        
        JOptionPane.showMessageDialog(this,"Victor Hugo Cavichiolli Prado\n RA:0261030370");
    }//GEN-LAST:event_jMenuItem6ActionPerformed


    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                new TelaPrincipal().setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnClientes;
    private javax.swing.JButton btnMarcas;
    private javax.swing.JButton btnProdutos;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu2;
    private javax.swing.JMenu jMenu3;
    private javax.swing.JMenu jMenu4;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem jMenuItem1;
    private javax.swing.JMenuItem jMenuItem10;
    private javax.swing.JMenuItem jMenuItem2;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JMenuItem jMenuItem4;
    private javax.swing.JMenuItem jMenuItem5;
    private javax.swing.JMenuItem jMenuItem6;
    private javax.swing.JMenuItem jMenuItem7;
    private javax.swing.JMenuItem jMenuItem8;
    private javax.swing.JMenuItem jMenuItem9;
    private javax.swing.JPopupMenu.Separator jSeparator1;
    private javax.swing.JToolBar jToolBar1;
    // End of variables declaration//GEN-END:variables
}
