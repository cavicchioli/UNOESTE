package controloil;
import javax.swing.JOptionPane;
import java.sql.ResultSet;

//import java.util.Date;
import javax.swing.table.DefaultTableModel;

public class TelaTrocaDeOleo extends javax.swing.JDialog {
    String cli_cod="",pro_cod="",pro_preco="";
     
    
    public TelaTrocaDeOleo(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        //calendario.setDate(new Date());
        //calendario.setFormat(1);
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        pnlCliente = new javax.swing.JPanel();
        jButton3 = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        tKM = new javax.swing.JTextField();
        tVeiculo = new javax.swing.JTextField();
        tCliente = new javax.swing.JTextField();
        tData = new javax.swing.JTextField();
        pnlBotoes = new javax.swing.JPanel();
        bConfirmar = new javax.swing.JButton();
        bCancelar = new javax.swing.JButton();
        pnlProdutos = new javax.swing.JPanel();
        pnlAddProduto = new javax.swing.JPanel();
        jButton4 = new javax.swing.JButton();
        jLabel4 = new javax.swing.JLabel();
        tProduto = new javax.swing.JTextField();
        tQdt = new javax.swing.JTextField();
        bADD = new javax.swing.JButton();
        bDEL = new javax.swing.JButton();
        pnlTable = new javax.swing.JPanel();
        jScrollPane1 = new javax.swing.JScrollPane();
        tableProdutos = new javax.swing.JTable();
        lValor = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Troca de Óleo");
        setResizable(false);

        pnlCliente.setBorder(javax.swing.BorderFactory.createEmptyBorder(1, 1, 1, 1));
        pnlCliente.setPreferredSize(new java.awt.Dimension(620, 70));

        jButton3.setFont(new java.awt.Font("Tahoma", 0, 10));
        jButton3.setText("Cliente");
        jButton3.setMaximumSize(new java.awt.Dimension(65, 23));
        jButton3.setPreferredSize(new java.awt.Dimension(72, 20));
        jButton3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton3ActionPerformed(evt);
            }
        });

        jLabel1.setText("Km.:");

        jLabel2.setText("Data:");

        jLabel3.setText("Veículo:");

        tCliente.setEditable(false);

        javax.swing.GroupLayout pnlClienteLayout = new javax.swing.GroupLayout(pnlCliente);
        pnlCliente.setLayout(pnlClienteLayout);
        pnlClienteLayout.setHorizontalGroup(
            pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, pnlClienteLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jButton3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel3, javax.swing.GroupLayout.PREFERRED_SIZE, 52, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(tCliente, javax.swing.GroupLayout.DEFAULT_SIZE, 455, Short.MAX_VALUE)
                    .addComponent(tVeiculo, javax.swing.GroupLayout.DEFAULT_SIZE, 455, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 28, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(tKM)
                    .addComponent(tData, javax.swing.GroupLayout.DEFAULT_SIZE, 67, Short.MAX_VALUE))
                .addContainerGap())
        );
        pnlClienteLayout.setVerticalGroup(
            pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlClienteLayout.createSequentialGroup()
                .addGap(12, 12, 12)
                .addGroup(pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jButton3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(tCliente, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel2)
                    .addComponent(tData, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(pnlClienteLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel3)
                    .addComponent(tVeiculo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(tKM, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel1))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        getContentPane().add(pnlCliente, java.awt.BorderLayout.PAGE_START);

        pnlBotoes.setBackground(new java.awt.Color(0, 0, 0));

        bConfirmar.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        bConfirmar.setText("Confirmar");
        bConfirmar.setPreferredSize(new java.awt.Dimension(90, 32));
        bConfirmar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bConfirmarActionPerformed(evt);
            }
        });
        pnlBotoes.add(bConfirmar);

        bCancelar.setFont(new java.awt.Font("Tahoma", 0, 10));
        bCancelar.setText("Cancelar");
        bCancelar.setPreferredSize(new java.awt.Dimension(90, 32));
        bCancelar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bCancelarActionPerformed(evt);
            }
        });
        pnlBotoes.add(bCancelar);

        getContentPane().add(pnlBotoes, java.awt.BorderLayout.PAGE_END);

        pnlProdutos.setBackground(new java.awt.Color(255, 255, 255));
        pnlProdutos.setLayout(new java.awt.BorderLayout());

        pnlAddProduto.setBackground(new java.awt.Color(204, 204, 204));
        pnlAddProduto.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        pnlAddProduto.setPreferredSize(new java.awt.Dimension(620, 47));

        jButton4.setFont(new java.awt.Font("Tahoma", 0, 10));
        jButton4.setText("Produto");
        jButton4.setPreferredSize(new java.awt.Dimension(72, 20));
        jButton4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton4ActionPerformed(evt);
            }
        });

        jLabel4.setText("Qtd.:");

        tProduto.setEditable(false);

        bADD.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        bADD.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/1321070289_add.png"))); // NOI18N
        bADD.setMaximumSize(new java.awt.Dimension(25, 25));
        bADD.setMinimumSize(new java.awt.Dimension(25, 25));
        bADD.setPreferredSize(new java.awt.Dimension(25, 25));
        bADD.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bADDActionPerformed(evt);
            }
        });

        bDEL.setFont(new java.awt.Font("Tahoma", 1, 12));
        bDEL.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/1321070284_close.png"))); // NOI18N
        bDEL.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        bDEL.setMaximumSize(new java.awt.Dimension(23, 23));
        bDEL.setMinimumSize(new java.awt.Dimension(23, 23));
        bDEL.setPreferredSize(new java.awt.Dimension(23, 23));
        bDEL.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bDELActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout pnlAddProdutoLayout = new javax.swing.GroupLayout(pnlAddProduto);
        pnlAddProduto.setLayout(pnlAddProdutoLayout);
        pnlAddProdutoLayout.setHorizontalGroup(
            pnlAddProdutoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlAddProdutoLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jButton4, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(10, 10, 10)
                .addComponent(tProduto, javax.swing.GroupLayout.DEFAULT_SIZE, 379, Short.MAX_VALUE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jLabel4, javax.swing.GroupLayout.PREFERRED_SIZE, 32, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(tQdt, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(bADD, javax.swing.GroupLayout.PREFERRED_SIZE, 24, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(bDEL, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap())
        );
        pnlAddProdutoLayout.setVerticalGroup(
            pnlAddProdutoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, pnlAddProdutoLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(pnlAddProdutoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(pnlAddProdutoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(tQdt, javax.swing.GroupLayout.DEFAULT_SIZE, 23, Short.MAX_VALUE)
                        .addComponent(jLabel4))
                    .addComponent(bADD, javax.swing.GroupLayout.Alignment.LEADING, 0, 0, Short.MAX_VALUE)
                    .addComponent(bDEL, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, pnlAddProdutoLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(jButton4, javax.swing.GroupLayout.DEFAULT_SIZE, 23, Short.MAX_VALUE)
                        .addComponent(tProduto, javax.swing.GroupLayout.DEFAULT_SIZE, 23, Short.MAX_VALUE)))
                .addContainerGap())
        );

        pnlProdutos.add(pnlAddProduto, java.awt.BorderLayout.PAGE_START);

        pnlTable.setBackground(new java.awt.Color(255, 255, 255));

        tableProdutos.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "Cod.", "Produto", "Quantidade", "Preço Und.", "Total"
            }
        ) {
            boolean[] canEdit = new boolean [] {
                false, false, false, false, false
            };

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        jScrollPane1.setViewportView(tableProdutos);
        tableProdutos.getColumnModel().getColumn(2).setResizable(false);

        lValor.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        lValor.setText("Total:  R$0,0 ");

        javax.swing.GroupLayout pnlTableLayout = new javax.swing.GroupLayout(pnlTable);
        pnlTable.setLayout(pnlTableLayout);
        pnlTableLayout.setHorizontalGroup(
            pnlTableLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 669, Short.MAX_VALUE)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, pnlTableLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(lValor, javax.swing.GroupLayout.PREFERRED_SIZE, 231, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(10, 10, 10))
        );
        pnlTableLayout.setVerticalGroup(
            pnlTableLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlTableLayout.createSequentialGroup()
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 238, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(lValor, javax.swing.GroupLayout.PREFERRED_SIZE, 14, javax.swing.GroupLayout.PREFERRED_SIZE))
        );

        pnlProdutos.add(pnlTable, java.awt.BorderLayout.CENTER);

        getContentPane().add(pnlProdutos, java.awt.BorderLayout.CENTER);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-685)/2, (screenSize.height-452)/2, 685, 452);
    }// </editor-fold>//GEN-END:initComponents

    private void bCancelarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bCancelarActionPerformed
        dispose();
    }//GEN-LAST:event_bCancelarActionPerformed

    private void jButton3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton3ActionPerformed
        TelaPesquisaCliente f = new TelaPesquisaCliente(null,true);
        f.setVisible(true);
        tCliente.setText(f.cli_nome);
        cli_cod=f.cod_cli;
    }//GEN-LAST:event_jButton3ActionPerformed

    private void jButton4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton4ActionPerformed
        TelaPesquisaProduto f = new TelaPesquisaProduto(null,true);
        f.setVisible(true);
        tProduto.setText(f.pro_nome);
        pro_cod=f.cod_pro;
        pro_preco=f.pro_preco;
    }//GEN-LAST:event_jButton4ActionPerformed

    private void bADDActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bADDActionPerformed
        String dados[]= new String[5];
        String sql ="Select pro_estoque from produto where pro_cod="+"'"+pro_cod+"'";
        ResultSet rs=Banco.con.consultar(sql);
        
        try
        {
            while(rs.next())
            {
                if(Integer.parseInt(rs.getString("pro_estoque"))- Integer.parseInt(tQdt.getText()) >=0)
                {
                    if(!verificaProduto(Integer.parseInt(pro_cod)))
                    {
                        DefaultTableModel modelo = (DefaultTableModel)tableProdutos.getModel();
       
                        dados[0]=pro_cod;
                        dados[1]=tProduto.getText();//produto
                        dados[2]=tQdt.getText();//quantidade
                        dados[3]=pro_preco;
                        //pro_preco=pro_preco.replace("R", "").replace("$", "").replace(" ", "").replace(",", ".");
                        pro_preco=pro_preco.replace("R", "").replace("$", "").replace(" ", "").replace(",", "");//.replace(",", ".");
                        //dados[4] = "233";
                        dados[4]=Float.toString(Float.parseFloat(pro_preco)*Integer.parseInt(tQdt.getText()));
        
                        modelo.addRow(dados);
        
                        lValor.setText("Total: R$" +Float.toString(calculaTotal()));
                    }
                    else
                       JOptionPane.showMessageDialog(this,"Produto existente, delete e adicione maior quantidade!!");
                        
                }
                else
                JOptionPane.showMessageDialog(this,"Estoque insuficiente!!");
            }
        }catch(Exception e){}
        
    }//GEN-LAST:event_bADDActionPerformed

    private boolean verificaProduto(int codigo_pro)
    {
        DefaultTableModel modelo = (DefaultTableModel)tableProdutos.getModel();
        int var=0;
        
        for(int i=0; i< modelo.getRowCount();i++)
            if(Integer.parseInt(tableProdutos.getValueAt(i, 0).toString())==codigo_pro)
            var=1;
        
         if(var==1)
            return true;
            else
            return false;
    }
    
    private float calculaTotal()
{
    float total=0;
    DefaultTableModel modelo = (DefaultTableModel)tableProdutos.getModel();
    
    for(int i=0;i<modelo.getRowCount();i++)
    {
        total+=Float.parseFloat((tableProdutos.getValueAt(i, 4).toString()));
    }
    return total;
}
    
    
    
    private void bDELActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bDELActionPerformed
        DefaultTableModel modelo = (DefaultTableModel)tableProdutos.getModel();
        modelo.removeRow(tableProdutos.getSelectedRow());
        
        lValor.setText("Total: R$" +Float.toString(calculaTotal()));
         
        
        
    }//GEN-LAST:event_bDELActionPerformed

    private void bConfirmarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bConfirmarActionPerformed
        int troca_cod;
        int produto_cod,item_quant;
        
        int op=JOptionPane.showConfirmDialog(this, "Confirma a Troca de Óleo?");
        if (op==JOptionPane.YES_OPTION)
        {
            String sql = "insert into troca (tro_data, tro_km, tro_veiculo, cli_cod)"
                       + " Values (" + "'" + tData.getText() + "', "
                       + "'" + tKM.getText() + "', "
                       + "'" + tVeiculo.getText() + "', "
                       + "'" + cli_cod + "')" ;
            
            
            
            if (!Banco.con.manipular(sql))
                JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
            else
            {
            
             troca_cod = Banco.con.getMaxPK("troca", "tro_cod");
            
             for(int i=0; i< tableProdutos.getRowCount();i++)
             {
                produto_cod = Integer.parseInt((tableProdutos.getValueAt(i, 0).toString()));
                item_quant = Integer.parseInt((tableProdutos.getValueAt(i, 2).toString()));
                
                
                sql = "insert into troca_itens(tro_cod, pro_cod, it_quant)"
                       + " Values(" + "'" + troca_cod + "', "
                       + "'" + produto_cod + "', "
                       + "'" + item_quant + "')";
                
                if (!Banco.con.manipular(sql))
                 JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
                else
                {
                 sql= "UPDATE produto SET pro_estoque=pro_estoque-"+"'"+item_quant+"'"+" where pro_cod="+"'"+produto_cod+"'";
                 if (!Banco.con.manipular(sql))
                    JOptionPane.showMessageDialog(rootPane,Banco.con.getMensagemErro());
               }
             }
            
            }
        }
    }//GEN-LAST:event_bConfirmarActionPerformed

    
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
            java.util.logging.Logger.getLogger(TelaTrocaDeOleo.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(TelaTrocaDeOleo.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(TelaTrocaDeOleo.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(TelaTrocaDeOleo.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the dialog */
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                TelaTrocaDeOleo dialog = new TelaTrocaDeOleo(new javax.swing.JFrame(), true);
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
    private javax.swing.JButton bADD;
    private javax.swing.JButton bCancelar;
    private javax.swing.JButton bConfirmar;
    private javax.swing.JButton bDEL;
    private javax.swing.JButton jButton3;
    private javax.swing.JButton jButton4;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JLabel lValor;
    private javax.swing.JPanel pnlAddProduto;
    private javax.swing.JPanel pnlBotoes;
    private javax.swing.JPanel pnlCliente;
    private javax.swing.JPanel pnlProdutos;
    private javax.swing.JPanel pnlTable;
    private javax.swing.JTextField tCliente;
    private javax.swing.JTextField tData;
    private javax.swing.JTextField tKM;
    private javax.swing.JTextField tProduto;
    private javax.swing.JTextField tQdt;
    private javax.swing.JTextField tVeiculo;
    private javax.swing.JTable tableProdutos;
    // End of variables declaration//GEN-END:variables
}
