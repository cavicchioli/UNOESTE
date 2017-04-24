
package controloil;
import java.sql.ResultSet;
import javax.swing.table.DefaultTableModel;

public class TelaPesquisaCliente extends javax.swing.JDialog {
        String cod_cli="",cli_nome="";
        
    
        
    public TelaPesquisaCliente(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        carregaTabela("");
    }
    
    
    private void carregaTabela(String complemento)
    {
    
        String sql ="Select * from cliente"+complemento;    
        ResultSet rs=Banco.con.consultar(sql);
        String dados[]=new String[7];
        DefaultTableModel modelo = (DefaultTableModel)tablePesquisa.getModel();
        modelo.setRowCount(0);                
        
        try
        {
        while(rs.next())
        {
            dados[0]=rs.getString("cli_cod");
            dados[1]=rs.getString("cli_nome");
            dados[2]=rs.getString("cli_endereco");
            dados[3]=rs.getString("cli_bairro");
            dados[4]=rs.getString("cli_cidade");
            dados[5]=rs.getString("cli_uf");
            dados[6]=rs.getString("cli_fone");
            modelo.addRow(dados);
        }
        }catch(Exception e){}
    }
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        tProcura = new javax.swing.JTextField();
        bProcurar = new javax.swing.JButton();
        jPanel2 = new javax.swing.JPanel();
        bConfirmar = new javax.swing.JButton();
        bCancelar = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        tablePesquisa = new javax.swing.JTable();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        jPanel1.setBackground(new java.awt.Color(255, 255, 255));

        tProcura.setPreferredSize(new java.awt.Dimension(300, 20));
        jPanel1.add(tProcura);

        bProcurar.setText("Procurar");
        bProcurar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bProcurarActionPerformed(evt);
            }
        });
        jPanel1.add(bProcurar);

        getContentPane().add(jPanel1, java.awt.BorderLayout.PAGE_START);

        jPanel2.setBackground(new java.awt.Color(0, 0, 0));

        bConfirmar.setText("Confirmar");
        bConfirmar.setPreferredSize(new java.awt.Dimension(90, 32));
        bConfirmar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bConfirmarActionPerformed(evt);
            }
        });
        jPanel2.add(bConfirmar);

        bCancelar.setText("Cancelar");
        bCancelar.setPreferredSize(new java.awt.Dimension(90, 32));
        bCancelar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bCancelarActionPerformed(evt);
            }
        });
        jPanel2.add(bCancelar);

        getContentPane().add(jPanel2, java.awt.BorderLayout.PAGE_END);

        tablePesquisa.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "Código", "Nome", "Endereço", "Bairro", "Cidade", "UF", "Telefone"
            }
        ) {
            boolean[] canEdit = new boolean [] {
                false, false, false, false, false, false, false
            };

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        tablePesquisa.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tablePesquisaMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(tablePesquisa);
        tablePesquisa.getColumnModel().getColumn(0).setPreferredWidth(30);
        tablePesquisa.getColumnModel().getColumn(1).setPreferredWidth(200);
        tablePesquisa.getColumnModel().getColumn(2).setPreferredWidth(100);
        tablePesquisa.getColumnModel().getColumn(3).setPreferredWidth(50);
        tablePesquisa.getColumnModel().getColumn(4).setPreferredWidth(50);
        tablePesquisa.getColumnModel().getColumn(5).setPreferredWidth(20);
        tablePesquisa.getColumnModel().getColumn(6).setPreferredWidth(50);

        getContentPane().add(jScrollPane1, java.awt.BorderLayout.CENTER);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void bProcurarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bProcurarActionPerformed
        String comp = " where cli_nome like '%"+tProcura.getText()+"%'";
        carregaTabela(comp);
    }//GEN-LAST:event_bProcurarActionPerformed

    private void tablePesquisaMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tablePesquisaMouseClicked
        
        DefaultTableModel modelo = (DefaultTableModel)tablePesquisa.getModel(); 
        cod_cli=modelo.getValueAt(tablePesquisa.getSelectedRow(),0).toString();
        cli_nome = modelo.getValueAt(tablePesquisa.getSelectedRow(),1).toString();
    }//GEN-LAST:event_tablePesquisaMouseClicked

    private void bConfirmarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bConfirmarActionPerformed
        dispose();
    }//GEN-LAST:event_bConfirmarActionPerformed

    private void bCancelarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bCancelarActionPerformed
        cod_cli = "";
        cli_nome = "";
        dispose();
    }//GEN-LAST:event_bCancelarActionPerformed

    public String getCod_Cli()
    {
        return cod_cli;
    }
    
    public String getCli_Cod()
    {
        return cli_nome;
    }
    
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(TelaPesquisaCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(TelaPesquisaCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(TelaPesquisaCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(TelaPesquisaCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the dialog */
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                TelaPesquisaCliente dialog = new TelaPesquisaCliente(new javax.swing.JFrame(), true);
                dialog.addWindowListener(new java.awt.event.WindowAdapter() {

                    @Override
                    public void windowClosing(java.awt.event.WindowEvent e) {
                        System.exit(0);
                    }
                });
                dialog.setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton bCancelar;
    private javax.swing.JButton bConfirmar;
    private javax.swing.JButton bProcurar;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField tProcura;
    private javax.swing.JTable tablePesquisa;
    // End of variables declaration//GEN-END:variables
}
