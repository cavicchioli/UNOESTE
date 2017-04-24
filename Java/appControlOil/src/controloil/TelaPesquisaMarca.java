
package controloil;
import java.sql.ResultSet;
import javax.swing.table.DefaultTableModel;

public class TelaPesquisaMarca extends javax.swing.JDialog {

    String cod_mar="";
    
    public TelaPesquisaMarca(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        carregaTabela("");
    }

    private void carregaTabela(String complemento)
    {
    
        String sql ="Select * from marca"+complemento;    
        ResultSet rs=Banco.con.consultar(sql);
        String dados[]=new String[2];
        DefaultTableModel modelo = (DefaultTableModel)tabelaPesquisa.getModel();
        modelo.setRowCount(0);                
        
        try
        {
        while(rs.next())
        {
            dados[0]=rs.getString("mar_cod");
            dados[1]=rs.getString("mar_desc");
            
            modelo.addRow(dados);
        }
        }catch(Exception e){}
    }
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        tPesquisa = new javax.swing.JTextField();
        bProcurar = new javax.swing.JButton();
        jPanel2 = new javax.swing.JPanel();
        bConfirmar = new javax.swing.JButton();
        bCancelar = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        tabelaPesquisa = new javax.swing.JTable();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        jPanel1.setBackground(new java.awt.Color(255, 255, 255));

        tPesquisa.setPreferredSize(new java.awt.Dimension(300, 20));
        tPesquisa.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                tPesquisaActionPerformed(evt);
            }
        });
        jPanel1.add(tPesquisa);

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

        tabelaPesquisa.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "Código", "Marca"
            }
        ) {
            boolean[] canEdit = new boolean [] {
                false, false
            };

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        tabelaPesquisa.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tabelaPesquisaMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(tabelaPesquisa);
        tabelaPesquisa.getColumnModel().getColumn(0).setResizable(false);
        tabelaPesquisa.getColumnModel().getColumn(0).setPreferredWidth(25);
        tabelaPesquisa.getColumnModel().getColumn(1).setResizable(false);
        tabelaPesquisa.getColumnModel().getColumn(1).setPreferredWidth(300);

        getContentPane().add(jScrollPane1, java.awt.BorderLayout.CENTER);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-485)/2, (screenSize.height-392)/2, 485, 392);
    }// </editor-fold>//GEN-END:initComponents

    private void tPesquisaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_tPesquisaActionPerformed

    }//GEN-LAST:event_tPesquisaActionPerformed

    private void tabelaPesquisaMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tabelaPesquisaMouseClicked
        DefaultTableModel modelo = (DefaultTableModel)tabelaPesquisa.getModel(); 
        cod_mar=modelo.getValueAt(tabelaPesquisa.getSelectedRow(),0).toString();
        
    }//GEN-LAST:event_tabelaPesquisaMouseClicked

    private void bProcurarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bProcurarActionPerformed
        String comp = " where mar_desc like '%"+tPesquisa.getText()+"%'";
        carregaTabela(comp);
    }//GEN-LAST:event_bProcurarActionPerformed

    private void bConfirmarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bConfirmarActionPerformed
        dispose();
    }//GEN-LAST:event_bConfirmarActionPerformed

    private void bCancelarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bCancelarActionPerformed
        cod_mar = "";
        dispose();
    }//GEN-LAST:event_bCancelarActionPerformed

    public String getCod_Mar()
    {
        return cod_mar;
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
            java.util.logging.Logger.getLogger(TelaPesquisaMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(TelaPesquisaMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(TelaPesquisaMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(TelaPesquisaMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the dialog */
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                TelaPesquisaMarca dialog = new TelaPesquisaMarca(new javax.swing.JFrame(), true);
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
    private javax.swing.JTextField tPesquisa;
    private javax.swing.JTable tabelaPesquisa;
    // End of variables declaration//GEN-END:variables
}
