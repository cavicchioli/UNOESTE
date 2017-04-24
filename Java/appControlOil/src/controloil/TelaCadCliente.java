
package controloil;

import java.sql.ResultSet;
import java.util.ArrayList;
import javax.swing.JOptionPane;

public class TelaCadCliente extends javax.swing.JDialog {
    
    String cod_cli="";
    public TelaCadCliente(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        DesabilitaTudo();
        btnNovo.setEnabled(true);
        Clear();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        btnNovo = new javax.swing.JToggleButton();
        btnAlterar = new javax.swing.JToggleButton();
        btnExcluir = new javax.swing.JToggleButton();
        btnConfirmar = new javax.swing.JToggleButton();
        btnCancelar = new javax.swing.JToggleButton();
        jPanel2 = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        tNome = new javax.swing.JTextField();
        btnBuscar = new javax.swing.JButton();
        jLabel2 = new javax.swing.JLabel();
        tEndereco = new javax.swing.JTextField();
        tBairro = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        tCidade = new javax.swing.JTextField();
        jLabel5 = new javax.swing.JLabel();
        tUf = new javax.swing.JTextField();
        jLabel6 = new javax.swing.JLabel();
        tTelefone = new javax.swing.JTextField();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Cadastro de Clientes");
        setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));

        jPanel1.setBackground(new java.awt.Color(0, 0, 0));
        jPanel1.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        jPanel1.setPreferredSize(new java.awt.Dimension(480, 42));

        btnNovo.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        btnNovo.setText("Novo");
        btnNovo.setPreferredSize(new java.awt.Dimension(90, 32));
        btnNovo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnNovoActionPerformed(evt);
            }
        });
        jPanel1.add(btnNovo);

        btnAlterar.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        btnAlterar.setText("Alterar");
        btnAlterar.setPreferredSize(new java.awt.Dimension(90, 32));
        btnAlterar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnAlterarActionPerformed(evt);
            }
        });
        jPanel1.add(btnAlterar);

        btnExcluir.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        btnExcluir.setText("Excluir");
        btnExcluir.setPreferredSize(new java.awt.Dimension(90, 32));
        btnExcluir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnExcluirActionPerformed(evt);
            }
        });
        jPanel1.add(btnExcluir);

        btnConfirmar.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
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

        jLabel1.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel1.setText("Nome:");
        jPanel2.add(jLabel1);
        jLabel1.setBounds(10, 11, 50, 14);
        jPanel2.add(tNome);
        tNome.setBounds(10, 30, 450, 20);

        btnBuscar.setForeground(new java.awt.Color(240, 240, 240));
        btnBuscar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/lupa.gif"))); // NOI18N
        btnBuscar.setInheritsPopupMenu(true);
        btnBuscar.setMaximumSize(new java.awt.Dimension(33, 33));
        btnBuscar.setMinimumSize(new java.awt.Dimension(33, 33));
        btnBuscar.setPreferredSize(new java.awt.Dimension(33, 33));
        btnBuscar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnBuscarActionPerformed(evt);
            }
        });
        jPanel2.add(btnBuscar);
        btnBuscar.setBounds(470, 30, 20, 20);

        jLabel2.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel2.setText("Endereço:");
        jPanel2.add(jLabel2);
        jLabel2.setBounds(10, 60, 70, 14);
        jPanel2.add(tEndereco);
        tEndereco.setBounds(10, 80, 320, 20);
        jPanel2.add(tBairro);
        tBairro.setBounds(340, 80, 150, 20);

        jLabel3.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel3.setText("Bairro:");
        jPanel2.add(jLabel3);
        jLabel3.setBounds(340, 60, 40, 14);

        jLabel4.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel4.setText("Cidade:");
        jPanel2.add(jLabel4);
        jLabel4.setBounds(10, 110, 60, 14);
        jPanel2.add(tCidade);
        tCidade.setBounds(10, 130, 220, 20);

        jLabel5.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel5.setText("UF:");
        jPanel2.add(jLabel5);
        jLabel5.setBounds(240, 110, 30, 14);
        jPanel2.add(tUf);
        tUf.setBounds(240, 130, 50, 20);

        jLabel6.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel6.setText("Telefone:");
        jPanel2.add(jLabel6);
        jLabel6.setBounds(310, 110, 60, 14);
        jPanel2.add(tTelefone);
        tTelefone.setBounds(310, 130, 180, 20);

        getContentPane().add(jPanel2, java.awt.BorderLayout.CENTER);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-515)/2, (screenSize.height-245)/2, 515, 245);
    }// </editor-fold>//GEN-END:initComponents


        private void Clear()
        {
            tBairro.setText("");
            tNome.setText("");
            tCidade.setText("");
            tEndereco.setText("");
            tTelefone.setText("");
            tUf.setText("");
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
        btnBuscar.setEnabled(true);
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
    
    private void btnBuscarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnBuscarActionPerformed
        
        TelaPesquisaCliente dialog = new TelaPesquisaCliente(null,true);
        dialog.setVisible(true);
        
        cod_cli=dialog.getCod_Cli();
        if(cod_cli!="")
        {
        
        HabilitaTudo();
        
        String sql ="Select * from cliente where cli_cod ="+ cod_cli;    
        ResultSet rs=Banco.con.consultar(sql); 
        try
        {
        while(rs.next())
        {
            
            tNome.setText(rs.getString("cli_nome"));
            tEndereco.setText(rs.getString("cli_endereco"));
            tBairro.setText(rs.getString("cli_bairro"));
            tCidade.setText(rs.getString("cli_cidade"));
            tUf.setText(rs.getString("cli_uf"));
            tTelefone.setText(rs.getString("cli_fone"));
        }
        }catch(Exception e){}
        
        btnNovo.setEnabled(false);
        btnConfirmar.setEnabled(false);
        }
    }//GEN-LAST:event_btnBuscarActionPerformed

    private void btnNovoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnNovoActionPerformed
        HabilitaTudo();
        btnNovo.setEnabled(false);
        btnAlterar.setEnabled(false);
        btnExcluir.setEnabled(false);
        btnBuscar.setEnabled(false);
    }//GEN-LAST:event_btnNovoActionPerformed

    private void btnCancelarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnCancelarActionPerformed
        dispose();
    }//GEN-LAST:event_btnCancelarActionPerformed

    private void btnConfirmarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnConfirmarActionPerformed
        int op=JOptionPane.showConfirmDialog(this, "Confirma a inclusão?");
        if (op==JOptionPane.YES_OPTION)
        {
            String sql = "insert into cliente (cli_nome, cli_endereco, cli_bairro, cli_cidade, cli_uf, cli_fone)"
                       + " Values (" + "'" + tNome.getText() + "', "
                       + "'" + tEndereco.getText() + "', "
                       + "'" + tBairro.getText() + "', "
                       + "'" + tCidade.getText() + "', "
                       + "'" + tUf.getText() + "', "
                       + "'" + tTelefone.getText() + "')" ;
            
            JOptionPane.showMessageDialog(rootPane, sql);
            
            if (!Banco.con.manipular(sql))
                JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
        }
        DesabilitaTudo();
        btnNovo.setEnabled(true);
        btnConfirmar.setEnabled(false);
        Clear();
        
    }//GEN-LAST:event_btnConfirmarActionPerformed

    private void btnAlterarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnAlterarActionPerformed
        int op=JOptionPane.showConfirmDialog(this, "Confirma a alteração?");
        if (op==JOptionPane.YES_OPTION)
        {   
            String sql = "UPDATE cliente SET cli_nome=" + "'" + tNome.getText() + "', "
	   + "cli_endereco=" + "'" + tEndereco.getText() + "', "
           + "cli_bairro=" + "'" + tBairro.getText() + "', "
           + "cli_cidade=" + "'" + tCidade.getText() + "', " 
           + "cli_uf=" + "'" + tUf.getText() + "', " 
           + "cli_fone=" + "'" + tTelefone.getText() + "'" 
           + "where cli_cod = "+ Integer.parseInt(cod_cli);
           
            if (Banco.con.manipular(sql))
        {
            cod_cli="";
            tNome.setText("");
            tEndereco.setText("");
            tBairro.setText("");
            tCidade.setText("");
            tUf.setText("");
            tTelefone.setText("");
            
        DesabilitaTudo();
        btnNovo.setEnabled(true);
        }
        else
            JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
        }
    }//GEN-LAST:event_btnAlterarActionPerformed

    private void btnExcluirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnExcluirActionPerformed
        
        String sql = "DELETE FROM cliente WHERE cli_cod="+ cod_cli;
        
        if (Banco.con.manipular(sql))
        {
            cod_cli="";
            tNome.setText("");
            tEndereco.setText("");
            tBairro.setText("");
            tCidade.setText("");
            tUf.setText("");
            tTelefone.setText("");
            
        DesabilitaTudo();
        btnNovo.setEnabled(true);
        }
        else
            JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
        
    }//GEN-LAST:event_btnExcluirActionPerformed

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
            java.util.logging.Logger.getLogger(TelaCadCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(TelaCadCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(TelaCadCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(TelaCadCliente.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the dialog */
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                TelaCadCliente dialog = new TelaCadCliente(new javax.swing.JFrame(), true);
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
    private javax.swing.JToggleButton btnAlterar;
    private javax.swing.JButton btnBuscar;
    private javax.swing.JToggleButton btnCancelar;
    private javax.swing.JToggleButton btnConfirmar;
    private javax.swing.JToggleButton btnExcluir;
    private javax.swing.JToggleButton btnNovo;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JTextField tBairro;
    private javax.swing.JTextField tCidade;
    private javax.swing.JTextField tEndereco;
    private javax.swing.JTextField tNome;
    private javax.swing.JTextField tTelefone;
    private javax.swing.JTextField tUf;
    // End of variables declaration//GEN-END:variables
}
