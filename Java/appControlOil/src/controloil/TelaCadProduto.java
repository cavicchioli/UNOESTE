
package controloil;

import java.sql.ResultSet;
import java.util.ArrayList;
import javax.swing.JOptionPane;

public class TelaCadProduto extends javax.swing.JDialog {
    ArrayList CodMarca = new ArrayList();
    String cod_pro="";
    /** Creates new form TelaCadProduto */
    public TelaCadProduto(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        DesabilitaTudo();
        bNovo.setEnabled(true);
        MontaTela();
    }
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        bNovo = new javax.swing.JButton();
        bAlterar = new javax.swing.JButton();
        bExcluir = new javax.swing.JButton();
        bConfirmar = new javax.swing.JButton();
        bCancela = new javax.swing.JButton();
        jPanel2 = new javax.swing.JPanel();
        tDescr = new javax.swing.JTextField();
        tEstoque = new javax.swing.JTextField();
        tPreco = new javax.swing.JTextField();
        cbMarca = new javax.swing.JComboBox();
        cbUnidade = new javax.swing.JComboBox();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jLabel5 = new javax.swing.JLabel();
        bBusca = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Cadastro de Produtos");

        jPanel1.setBackground(new java.awt.Color(0, 0, 0));

        bNovo.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        bNovo.setText("Novo");
        bNovo.setPreferredSize(new java.awt.Dimension(90, 32));
        bNovo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bNovoActionPerformed(evt);
            }
        });
        jPanel1.add(bNovo);

        bAlterar.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        bAlterar.setText("Alterar");
        bAlterar.setPreferredSize(new java.awt.Dimension(90, 32));
        bAlterar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bAlterarActionPerformed(evt);
            }
        });
        jPanel1.add(bAlterar);

        bExcluir.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        bExcluir.setText("Excluir");
        bExcluir.setPreferredSize(new java.awt.Dimension(90, 32));
        bExcluir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bExcluirActionPerformed(evt);
            }
        });
        jPanel1.add(bExcluir);

        bConfirmar.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        bConfirmar.setText("Confirmar");
        bConfirmar.setPreferredSize(new java.awt.Dimension(90, 32));
        bConfirmar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bConfirmarActionPerformed(evt);
            }
        });
        jPanel1.add(bConfirmar);

        bCancela.setFont(new java.awt.Font("Tahoma", 0, 10));
        bCancela.setText("Cancelar");
        bCancela.setPreferredSize(new java.awt.Dimension(90, 32));
        bCancela.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bCancelaActionPerformed(evt);
            }
        });
        jPanel1.add(bCancela);

        getContentPane().add(jPanel1, java.awt.BorderLayout.PAGE_END);

        jPanel2.setLayout(null);
        jPanel2.add(tDescr);
        tDescr.setBounds(10, 30, 430, 20);

        tEstoque.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        jPanel2.add(tEstoque);
        tEstoque.setBounds(190, 140, 100, 20);

        tPreco.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        jPanel2.add(tPreco);
        tPreco.setBounds(360, 140, 110, 20);

        jPanel2.add(cbMarca);
        cbMarca.setBounds(10, 80, 460, 20);

        cbUnidade.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "1L", "2L", "18L", "PÇ", ".5L", " " }));
        jPanel2.add(cbUnidade);
        cbUnidade.setBounds(10, 140, 130, 20);

        jLabel1.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel1.setText("Produto:");
        jPanel2.add(jLabel1);
        jLabel1.setBounds(10, 10, 70, 14);

        jLabel2.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel2.setText("Marca:");
        jPanel2.add(jLabel2);
        jLabel2.setBounds(10, 60, 50, 14);

        jLabel3.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel3.setText("Unidade:");
        jPanel2.add(jLabel3);
        jLabel3.setBounds(10, 120, 70, 14);

        jLabel4.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel4.setText("Qtde em Estoque:");
        jPanel2.add(jLabel4);
        jLabel4.setBounds(190, 120, 110, 14);

        jLabel5.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel5.setText("Preço:");
        jPanel2.add(jLabel5);
        jLabel5.setBounds(360, 120, 80, 14);

        bBusca.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/lupa.gif"))); // NOI18N
        bBusca.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        bBusca.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bBuscaActionPerformed(evt);
            }
        });
        jPanel2.add(bBusca);
        bBusca.setBounds(450, 30, 20, 20);

        getContentPane().add(jPanel2, java.awt.BorderLayout.CENTER);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-498)/2, (screenSize.height-254)/2, 498, 254);
    }// </editor-fold>//GEN-END:initComponents
       
    private void Clear()
        { 
            tDescr.setText("");
            tEstoque.setText("");
            tPreco.setText("");
        }
    
    private void MontaTela()
    {
        tDescr.setText("");
        tEstoque.setText("");
        tPreco.setText("");
        ResultSet rs=Banco.con.consultar("Select * from marca");
        String smarca;
        cbMarca.removeAllItems();
        try
        {
            while (rs.next())
            {
                smarca=rs.getString("mar_desc");
                cbMarca.addItem(smarca);
                CodMarca.add(rs.getString("mar_cod"));
            }
        }catch(Exception e){}
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
        bCancela.setEnabled(true);
        bBusca.setEnabled(true);
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

    private void bExcluirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bExcluirActionPerformed
        int op=JOptionPane.showConfirmDialog(this, "Confirma a exclusão?");
        if (op==JOptionPane.YES_OPTION)
        {
            //String sql = "DELETE FROM produto WHERE pro_cod="+ valor do banco;
            
            
        }
        DesabilitaTudo();
        bNovo.setEnabled(true);
        bConfirmar.setEnabled(true);    }//GEN-LAST:event_bExcluirActionPerformed
        
    private void bNovoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bNovoActionPerformed

        HabilitaTudo();
        bNovo.setEnabled(false);
        bAlterar.setEnabled(false);
        bExcluir.setEnabled(false);
        bBusca.setEnabled(false);
    }//GEN-LAST:event_bNovoActionPerformed

    private void bBuscaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bBuscaActionPerformed
        TelaPesquisaProduto dialog = new TelaPesquisaProduto(null,true);
        dialog.setVisible(true);
        
        String cod_pro=dialog.getCod_Pro();
        if(cod_pro!="")
        {
        
          HabilitaTudo();
          String sql ="Select * from produto where pro_cod ="+ cod_pro;        
          ResultSet rs=Banco.con.consultar(sql);
        
          try
          {
            while(rs.next())
            { //errado arrumar!
              tDescr.setText(rs.getString("pro_desc"));
              cbMarca.setSelectedIndex(Integer.parseInt(rs.getString("mar_cod")));
              tPreco.setText(rs.getString("pro_preco"));       
                     
              //cbUnidade=rs.getString("pro_unidade");
              
              tEstoque.setText(rs.getString("pro_estoque"));
            }
           }catch(Exception e){}
         }
        bNovo.setEnabled(false);
        bConfirmar.setEnabled(false);
    }//GEN-LAST:event_bBuscaActionPerformed

    private void bAlterarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bAlterarActionPerformed
        int op=JOptionPane.showConfirmDialog(this, "Confirma a alteração?");
        if (op==JOptionPane.YES_OPTION)
        {   
            String sql = "UPDATE produto SET mar_cod="+ CodMarca.get(cbMarca.getSelectedIndex())+ ", " 
	   + "pro_desc=" + "'" + tDescr.getText() + "', "
           + "pro_unidade=" + "'" + cbUnidade.getSelectedIndex() + "', "
           + "pro_estoque=" + "'" + tEstoque.getText() + "', " 
           + "pro_preco=" + "'" + tPreco.getText() + "'"
           + " where pro_cod="+"'"+Integer.parseInt(cod_pro)+"'";
           
            //JOptionPane.showMessageDialog(rootPane, sql);
            
            if (!Banco.con.manipular(sql))
                JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());       
        }
        DesabilitaTudo();
        bNovo.setEnabled(true);
        bConfirmar.setEnabled(true);
    }//GEN-LAST:event_bAlterarActionPerformed

    private void bConfirmarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bConfirmarActionPerformed
        int op=JOptionPane.showConfirmDialog(this, "Confirma a inclusão?");
        if (op==JOptionPane.YES_OPTION)
        {
            String sql = "insert into produto (mar_cod, pro_desc, pro_unidade, pro_estoque, pro_preco)"
                       + " Values (" + CodMarca.get(cbMarca.getSelectedIndex()) + ", "
                       + "'" + tDescr.getText() + "', "
                       + "'" + cbUnidade.getSelectedIndex() + "', "
                       + "'" + tEstoque.getText() + "', " 
                       + "'" + tPreco.getText() + "')" ;
            if (!Banco.con.manipular(sql))
                JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
        }
        DesabilitaTudo();
        bNovo.setEnabled(true);
        bConfirmar.setEnabled(true);
        Clear();
        
    }//GEN-LAST:event_bConfirmarActionPerformed

    private void bCancelaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bCancelaActionPerformed
        dispose();
    }//GEN-LAST:event_bCancelaActionPerformed

    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                TelaCadProduto dialog = new TelaCadProduto(new javax.swing.JFrame(), true);
                dialog.addWindowListener(new java.awt.event.WindowAdapter() {

                    public void windowClosing(java.awt.event.WindowEvent e) {
                        System.exit(0);
                    }
                });
                dialog.setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton bAlterar;
    private javax.swing.JButton bBusca;
    private javax.swing.JButton bCancela;
    private javax.swing.JButton bConfirmar;
    private javax.swing.JButton bExcluir;
    private javax.swing.JButton bNovo;
    private javax.swing.JComboBox cbMarca;
    private javax.swing.JComboBox cbUnidade;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JTextField tDescr;
    private javax.swing.JTextField tEstoque;
    private javax.swing.JTextField tPreco;
    // End of variables declaration//GEN-END:variables
}
