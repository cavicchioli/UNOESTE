
package controloil;
import java.sql.ResultSet;
import javax.swing.table.DefaultTableModel;


public class TelaPesquisaProduto extends javax.swing.JDialog {
    String cod_pro="",pro_nome="",pro_preco="";
    
    public TelaPesquisaProduto(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        carregaTabela("");
        
    }
    
    private void carregaTabela(String complemento)
    {
    
        String sql ="Select pro_cod,pro_desc,pro_preco,marca.mar_desc,pro_unidade from produto,marca where produto.mar_cod=marca.mar_cod "+complemento;
                
        ResultSet rs=Banco.con.consultar(sql);
        String dados[]=new String[5];
        DefaultTableModel modelo = (DefaultTableModel)tablePesquisa.getModel();
        modelo.setRowCount(0);               
        
        try
        {
        while(rs.next())
        {
            dados[0]=rs.getString("pro_cod");
            dados[1]=rs.getString("pro_desc");
            dados[2]=rs.getString("mar_desc");
            dados[3]=rs.getString("pro_unidade");
            dados[4]=rs.getString("pro_preco");
                    
            modelo.addRow(dados);
        }
        }catch(Exception e){}
    }
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        tProcura = new javax.swing.JTextField();
        bProcura = new javax.swing.JButton();
        Cancelar = new javax.swing.JPanel();
        bConfirma = new javax.swing.JButton();
        bCancela = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        tablePesquisa = new javax.swing.JTable();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Pesquisa de Produtos");

        jPanel1.setBackground(new java.awt.Color(255, 255, 255));

        tProcura.setPreferredSize(new java.awt.Dimension(200, 20));
        jPanel1.add(tProcura);

        bProcura.setText("Procurar");
        bProcura.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bProcuraActionPerformed(evt);
            }
        });
        jPanel1.add(bProcura);

        getContentPane().add(jPanel1, java.awt.BorderLayout.PAGE_START);

        Cancelar.setBackground(new java.awt.Color(0, 0, 0));

        bConfirma.setText("Confirmar");
        bConfirma.setPreferredSize(new java.awt.Dimension(90, 32));
        bConfirma.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bConfirmaActionPerformed(evt);
            }
        });
        Cancelar.add(bConfirma);

        bCancela.setText("Cancelar");
        bCancela.setPreferredSize(new java.awt.Dimension(90, 32));
        bCancela.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bCancelaActionPerformed(evt);
            }
        });
        Cancelar.add(bCancela);

        getContentPane().add(Cancelar, java.awt.BorderLayout.PAGE_END);

        tablePesquisa.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "Código", "Descrição", "Marca", "Unidade", "Preço"
            }
        ));
        tablePesquisa.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tablePesquisaMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(tablePesquisa);
        tablePesquisa.getColumnModel().getColumn(0).setPreferredWidth(50);
        tablePesquisa.getColumnModel().getColumn(1).setPreferredWidth(200);
        tablePesquisa.getColumnModel().getColumn(2).setPreferredWidth(50);
        tablePesquisa.getColumnModel().getColumn(3).setPreferredWidth(50);
        tablePesquisa.getColumnModel().getColumn(4).setPreferredWidth(50);

        getContentPane().add(jScrollPane1, java.awt.BorderLayout.CENTER);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-643)/2, (screenSize.height-482)/2, 643, 482);
    }// </editor-fold>//GEN-END:initComponents

    private void bProcuraActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bProcuraActionPerformed
        String comp = " and pro_desc like '%"+tProcura.getText()+"%'";
        carregaTabela(comp);
    }//GEN-LAST:event_bProcuraActionPerformed

    private void tablePesquisaMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tablePesquisaMouseClicked
        DefaultTableModel modelo = (DefaultTableModel)tablePesquisa.getModel();
        
        cod_pro=modelo.getValueAt(tablePesquisa.getSelectedRow(),0).toString();
        pro_nome = modelo.getValueAt(tablePesquisa.getSelectedRow(),1).toString();
        pro_preco = modelo.getValueAt(tablePesquisa.getSelectedRow(),4).toString();
    }//GEN-LAST:event_tablePesquisaMouseClicked

    private void bConfirmaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bConfirmaActionPerformed
        dispose();
    }//GEN-LAST:event_bConfirmaActionPerformed

    private void bCancelaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bCancelaActionPerformed
        cod_pro="";
        pro_nome ="";
        pro_preco="";
        dispose();
    }//GEN-LAST:event_bCancelaActionPerformed
    
    public String getPro_Preco()
    {
        return pro_preco;
    }
    
    public String getCod_Pro()
    {
        return cod_pro;
    }
    
    public String getPro_Nome()
    {
        return pro_nome;
    }
    
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                TelaPesquisaProduto dialog = new TelaPesquisaProduto(new javax.swing.JFrame(), true);
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
    private javax.swing.JPanel Cancelar;
    private javax.swing.JButton bCancela;
    private javax.swing.JButton bConfirma;
    private javax.swing.JButton bProcura;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField tProcura;
    private javax.swing.JTable tablePesquisa;
    // End of variables declaration//GEN-END:variables
}
