package CamadaApresentacao;

import CamadaLogica.ReadOnlyTableModel;
import CamadaLogica.UperSize;
import CamadaNegocio.Clientes;
import CamadaNegocio.Empresas;
import CamadaNegocio.Funcionarios;
import CamadaNegocio.Produtos;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JOptionPane;

public class ConsultaPadrao extends javax.swing.JDialog
{
    private int codigo;
    private String[] vetOpcoes = new String[8];
    private int tl;
    private int posDefault;
    private String tabela;

  
    public ConsultaPadrao(java.awt.Frame parent, boolean modal)
    {
        super(parent, modal);
        codigo = 0;
        initComponents();
        setLocationRelativeTo(null);
        jTFvalor.setDocument(new UperSize(50,true)); //50=tamanho, true=upperCase
        jTFvalor.requestFocus();
    }

    public int getCodigo()
    {
        return codigo;
    }

    public void configuraOpcoes(String[] vetOpcoes, int tl, int posDefault, String tabela)
    {
        this.tl = tl;
        this.vetOpcoes = vetOpcoes;
        this.posDefault = posDefault;
        this.tabela = tabela;
        this.setTitle("Localiza " + tabela);
        for (int i = 0; i < tl; i++)
        {
            jCBopcoes.addItem(vetOpcoes[i]);
        }
        jCBopcoes.setSelectedIndex(posDefault);
    }
   
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        buttonGroup1 = new javax.swing.ButtonGroup();
        jPanelBotoes = new javax.swing.JPanel();
        jBLocalizar = new javax.swing.JButton();
        jBSair = new javax.swing.JButton();
        jTFvalor = new javax.swing.JTextField();
        jCBopcoes = new javax.swing.JComboBox();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTable = new javax.swing.JTable();

        setTitle("Consulta de Produtos");
        getContentPane().setLayout(null);

        jPanelBotoes.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        jPanelBotoes.setLayout(null);

        jBLocalizar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Localizar.png"))); // NOI18N
        jBLocalizar.setText("Localizar");
        jBLocalizar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBLocalizar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBLocalizar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBLocalizar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBLocalizarActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBLocalizar);
        jBLocalizar.setBounds(426, 6, 80, 60);

        jBSair.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Sair.png"))); // NOI18N
        jBSair.setText("Sair");
        jBSair.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBSair.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBSair.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBSair.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBSairActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBSair);
        jBSair.setBounds(512, 6, 80, 60);

        jTFvalor.setColumns(50);
        jPanelBotoes.add(jTFvalor);
        jTFvalor.setBounds(10, 40, 406, 20);

        jPanelBotoes.add(jCBopcoes);
        jCBopcoes.setBounds(10, 10, 130, 20);

        getContentPane().add(jPanelBotoes);
        jPanelBotoes.setBounds(10, 11, 610, 73);

        jTable.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {

            }
        ));
        jTable.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                jTableMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(jTable);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(10, 90, 608, 275);

        setSize(new java.awt.Dimension(644, 414));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jBLocalizarActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBLocalizarActionPerformed
    {//GEN-HEADEREND:event_jBLocalizarActionPerformed
        ResultSet rs;
        int tipo=jCBopcoes.getSelectedIndex();
        if (tabela.equals("Produtos"))
        {
            try
            {
                //configura Modelo da Tabela (Grid)
                Produtos.configuraModel(jTable);

                //adicionando uma linha
                ReadOnlyTableModel model=(ReadOnlyTableModel)jTable.getModel();
                rs = Produtos.buscarDados(jTFvalor.getText(), tipo); 
                while (rs.next())
                {
                    model.addRow(new Object[] {rs.getInt("prod_codigo"), rs.getString("prod_nome")});
                }
            } catch (SQLException sqlex)
            { System.out.println("Erro: \n" + sqlex.toString()); }
        }
        else
        if (tabela.equals("Funcionarios"))
        {
            try
            {
                //configura Modelo da Tabela (Grid)
                Funcionarios.configuraModel(jTable);

                //adicionando uma linha
                ReadOnlyTableModel model=(ReadOnlyTableModel)jTable.getModel();
                rs = Funcionarios.buscarDados(jTFvalor.getText(), tipo); 
                while (rs.next())
                {
                    model.addRow(new Object[] {rs.getInt("func_codigo"), rs.getString("fis_nome")});
                }
            } catch (SQLException sqlex)
            { System.out.println("Erro: \n" + sqlex.toString()); }

            
        }
        else
        if (tabela.equals("Clientes"))
        {
            try
            {
                //configura Modelo da Tabela (Grid)
                Clientes.configuraModel(jTable);

                //adicionando uma linha
                ReadOnlyTableModel model=(ReadOnlyTableModel)jTable.getModel();
                rs = Clientes.buscarDados(jTFvalor.getText(), tipo); 
                while (rs.next())
                {
                    model.addRow(new Object[] {rs.getInt("cli_codigo"), rs.getString("fis_nome")});
                }
            } catch (SQLException sqlex)
            { System.out.println("Erro: \n" + sqlex.toString()); }

        }
        else
        if (tabela.equals("Vendas"))
        {

        }
        else
        if (tabela.equals("Empresas"))
        {
            try
            {
                //configura Modelo da Tabela (Grid)
                Empresas.configuraModel(jTable);

                //adicionando uma linha
                ReadOnlyTableModel model=(ReadOnlyTableModel)jTable.getModel();
                rs = Empresas.buscarDados(jTFvalor.getText(), tipo); 
                while (rs.next())
                {
                    model.addRow(new Object[] {rs.getInt("emp_codigo"), rs.getString("emp_nome_fantasia")});
                }
            } catch (SQLException sqlex)
            { System.out.println("Erro: \n" + sqlex.toString()); }

        }
}//GEN-LAST:event_jBLocalizarActionPerformed

    private void jBSairActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBSairActionPerformed
    {//GEN-HEADEREND:event_jBSairActionPerformed
        dispose();
}//GEN-LAST:event_jBSairActionPerformed

    private void jTableMouseClicked(java.awt.event.MouseEvent evt)//GEN-FIRST:event_jTableMouseClicked
    {//GEN-HEADEREND:event_jTableMouseClicked
        if (evt.getClickCount() == 2)
        {
            if (jTable.getSelectedRow() >= 0)
            {
                codigo = Integer.parseInt(String.valueOf(jTable.getValueAt(jTable.getSelectedRow(),0)));
                this.dispose();
            }
            else
            {
                 JOptionPane.showMessageDialog(this, "Você deve selecionar um registro", "Informação", JOptionPane.INFORMATION_MESSAGE);
            }
        }
    }//GEN-LAST:event_jTableMouseClicked

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.ButtonGroup buttonGroup1;
    private javax.swing.JButton jBLocalizar;
    private javax.swing.JButton jBSair;
    private javax.swing.JComboBox jCBopcoes;
    private javax.swing.JPanel jPanelBotoes;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField jTFvalor;
    private javax.swing.JTable jTable;
    // End of variables declaration//GEN-END:variables
}
