package controloil;
import java.sql.ResultSet;
import java.util.ArrayList;
import javax.swing.JOptionPane;

public class TelaCadMarca extends javax.swing.JDialog {

    String cod_mar="";
    
    public TelaCadMarca(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        DesabilitaTudo();
        btnNovo.setEnabled(true);
        
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        btnNovo = new javax.swing.JButton();
        btnAlterar = new javax.swing.JButton();
        btnExcluir = new javax.swing.JButton();
        btnConfirmar = new javax.swing.JButton();
        btnCancelar = new javax.swing.JButton();
        jPanel2 = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        tMarca = new javax.swing.JTextField();
        btnBusca = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Cadastro de Marcas");

        jPanel1.setBackground(new java.awt.Color(0, 0, 0));

        btnNovo.setFont(new java.awt.Font("Tahoma", 0, 10));
        btnNovo.setText("Novo");
        btnNovo.setPreferredSize(new java.awt.Dimension(90, 32));
        btnNovo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnNovoActionPerformed(evt);
            }
        });
        jPanel1.add(btnNovo);

        btnAlterar.setFont(new java.awt.Font("Tahoma", 0, 10));
        btnAlterar.setText("Alterar");
        btnAlterar.setPreferredSize(new java.awt.Dimension(90, 32));
        btnAlterar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnAlterarActionPerformed(evt);
            }
        });
        jPanel1.add(btnAlterar);

        btnExcluir.setFont(new java.awt.Font("Tahoma", 0, 10));
        btnExcluir.setText("Excluir");
        btnExcluir.setPreferredSize(new java.awt.Dimension(90, 32));
        btnExcluir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnExcluirActionPerformed(evt);
            }
        });
        jPanel1.add(btnExcluir);

        btnConfirmar.setFont(new java.awt.Font("Tahoma", 0, 10));
        btnConfirmar.setText("Confirmar");
        btnConfirmar.setPreferredSize(new java.awt.Dimension(90, 32));
        btnConfirmar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnConfirmarActionPerformed(evt);
            }
        });
        jPanel1.add(btnConfirmar);

        btnCancelar.setFont(new java.awt.Font("Tahoma", 0, 10));
        btnCancelar.setText("Cancelar");
        btnCancelar.setPreferredSize(new java.awt.Dimension(90, 32));
        btnCancelar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnCancelarActionPerformed(evt);
            }
        });
        jPanel1.add(btnCancelar);

        getContentPane().add(jPanel1, java.awt.BorderLayout.PAGE_END);

        jPanel2.setLayout(null);

        jLabel1.setFont(new java.awt.Font("Tahoma", 1, 11));
        jLabel1.setText("Marca:");
        jPanel2.add(jLabel1);
        jLabel1.setBounds(10, 11, 50, 14);
        jPanel2.add(tMarca);
        tMarca.setBounds(10, 32, 440, 20);

        btnBusca.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/lupa.gif"))); // NOI18N
        btnBusca.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnBuscaActionPerformed(evt);
            }
        });
        jPanel2.add(btnBusca);
        btnBusca.setBounds(460, 30, 20, 20);

        getContentPane().add(jPanel2, java.awt.BorderLayout.CENTER);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-512)/2, (screenSize.height-145)/2, 512, 145);
    }// </editor-fold>//GEN-END:initComponents

    private void Clear()
        {
            tMarca.setText("");
        }
        
        private void DesabilitaTudo()
        {
        for (int i=0; i< jPanel1.getComponentCount();i++)
        {
            jPanel1.getComponent(i).setEnabled(false);
        }
        for (int i=0; i< jPanel2.getComponentCount();i++)
        {
            jPanel2.getComponent(i).setEnabled(false);
        }
        btnCancelar.setEnabled(true);
        btnBusca.setEnabled(true);
        }
        
        private void HabilitaTudo()
        {
        for (int i=0; i< jPanel1.getComponentCount();i++)
        {
            jPanel1.getComponent(i).setEnabled(true);
        }
        for (int i=0; i< jPanel2.getComponentCount();i++)
        {
            jPanel2.getComponent(i).setEnabled(true);
        }
       }
    
    
    private void btnConfirmarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnConfirmarActionPerformed
        int op=JOptionPane.showConfirmDialog(this, "Confirma a inclusão?");
        if (op==JOptionPane.YES_OPTION)
        {
            String sql = "insert into marca (mar_desc)"
                       + " Values ("+ "'" + tMarca.getText() + "')" ;
            if (!Banco.con.manipular(sql))
                JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
        }
        DesabilitaTudo();
        btnNovo.setEnabled(true);
        btnConfirmar.setEnabled(true);
        Clear();
        
    }//GEN-LAST:event_btnConfirmarActionPerformed

    private void btnAlterarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnAlterarActionPerformed
        int op=JOptionPane.showConfirmDialog(this, "Confirma a alteração?");
        if (op==JOptionPane.YES_OPTION)
        {   
            String sql = "UPDATE marca SET " + "mar_desc ="+ "'" +tMarca.getText()+ "'"
                    + "where mar_cod =" + Integer.parseInt(cod_mar);
            
            if (!Banco.con.manipular(sql))
                JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());       
        }
        cod_mar="";
        tMarca.setText("");
        DesabilitaTudo();
        btnNovo.setEnabled(true);
    }//GEN-LAST:event_btnAlterarActionPerformed

    private void btnExcluirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnExcluirActionPerformed
        String sql = "DELETE FROM marca WHERE mar_cod="+ cod_mar;
        
        if (!Banco.con.manipular(sql))
                JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
        cod_mar="";
        tMarca.setText("");
        DesabilitaTudo();
        btnNovo.setEnabled(true);
    }//GEN-LAST:event_btnExcluirActionPerformed

    private void btnNovoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnNovoActionPerformed
        HabilitaTudo();
        btnNovo.setEnabled(false);
        btnAlterar.setEnabled(false);
        btnExcluir.setEnabled(false);
        btnBusca.setEnabled(false);
    }//GEN-LAST:event_btnNovoActionPerformed

    private void btnCancelarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnCancelarActionPerformed
        dispose();
    }//GEN-LAST:event_btnCancelarActionPerformed

    private void btnBuscaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnBuscaActionPerformed
        TelaPesquisaMarca d = new TelaPesquisaMarca(null,true);
        d.setVisible(true);
        
        
        cod_mar=d.getCod_Mar();
        if(cod_mar!="")
        {
        
        HabilitaTudo();
        
        String sql = "Select * from marca where mar_cod ="+ cod_mar;    
        ResultSet rs=Banco.con.consultar(sql);
       try
       {
          while(rs.next())
            tMarca.setText(rs.getString("mar_desc"));      
          
       }catch(Exception e){}
        
        btnNovo.setEnabled(false);
        btnConfirmar.setEnabled(false);
        }
    }//GEN-LAST:event_btnBuscaActionPerformed


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
            java.util.logging.Logger.getLogger(TelaCadMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(TelaCadMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(TelaCadMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(TelaCadMarca.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the dialog */
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                TelaCadMarca dialog = new TelaCadMarca(new javax.swing.JFrame(), true);
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
    private javax.swing.JButton btnAlterar;
    private javax.swing.JButton btnBusca;
    private javax.swing.JButton btnCancelar;
    private javax.swing.JButton btnConfirmar;
    private javax.swing.JButton btnExcluir;
    private javax.swing.JButton btnNovo;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JTextField tMarca;
    // End of variables declaration//GEN-END:variables
}
