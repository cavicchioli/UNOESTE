package CamadaApresentacao;

import CamadaLogica.UperSize;
import CamadaNegocio.Produtos;
import javax.swing.JFormattedTextField;
import javax.swing.JOptionPane;

public class CadastroProdutos extends javax.swing.JDialog
{
    private Produtos produtos = new Produtos();

    public CadastroProdutos(java.awt.Frame parent, boolean modal)
    {
        super(parent, modal);
        initComponents();

        arrumaJFormat();
        jTFprod_nome.setDocument(new UperSize(40, true)); //40=tamanho, true=upperCase
        setLocationRelativeTo(null);
        habilitarCampos(false);
        estadoBotoesInicial();
        jTFprod_codigo.requestFocus();
    }

     public void arrumaJFormat()
    {
        //Todo JFormattedTextField tem o problema de não apagar o seu conteúdo, a linha abaixo resolve isso
        jFTFprod_valor.setFocusLostBehavior(JFormattedTextField.COMMIT);
        jFTFprod_estoque.setFocusLostBehavior(JFormattedTextField.COMMIT);
    }

    public void estadoBotoesInicial()
    {
        jBNovo.setEnabled(true);
        jBAlterar.setEnabled(false);
        jBExcluir.setEnabled(false);
        jBSalvar.setEnabled(false);
        jBCancelar.setEnabled(false);
        jBLocalizar.setEnabled(true);
        jBSair.setEnabled(true);
    }

    public void estadoBotoesDigitacao()
    {
        jBNovo.setEnabled(false);
        jBAlterar.setEnabled(false);
        jBExcluir.setEnabled(false);
        jBSalvar.setEnabled(true);
        jBCancelar.setEnabled(true);
        jBLocalizar.setEnabled(false);
        jBSair.setEnabled(true);
    }

    public void estadoBotoesBrowse()
    {
        jBNovo.setEnabled(false);
        jBAlterar.setEnabled(true);
        jBExcluir.setEnabled(true);
        jBSalvar.setEnabled(false);
        jBCancelar.setEnabled(true);
        jBLocalizar.setEnabled(false);
        jBSair.setEnabled(true);
    }

    public void limparCampos()
    {
        jTFprod_codigo.setText("");
        jTFprod_nome.setText("");
        jFTFprod_valor.setText("");
        jFTFprod_estoque.setText("");
    }

    public void habilitarCampos(boolean flag)
    {
        jTFprod_nome.setEnabled(flag);
        jFTFprod_valor.setEnabled(flag);
        jFTFprod_estoque.setEnabled(flag);
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanelDados = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        jTFprod_nome = new javax.swing.JTextField();
        jLabel2 = new javax.swing.JLabel();
        jTFprod_codigo = new javax.swing.JTextField();
        jFTFprod_estoque = new javax.swing.JFormattedTextField();
        jFTFprod_valor = new javax.swing.JFormattedTextField();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jPanelBotoes = new javax.swing.JPanel();
        jBNovo = new javax.swing.JButton();
        jBAlterar = new javax.swing.JButton();
        jBExcluir = new javax.swing.JButton();
        jBSalvar = new javax.swing.JButton();
        jBCancelar = new javax.swing.JButton();
        jBLocalizar = new javax.swing.JButton();
        jBSair = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Cadastro de Produtos");
        getContentPane().setLayout(null);

        jPanelDados.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        jPanelDados.setLayout(null);

        jLabel1.setText("Código");
        jPanelDados.add(jLabel1);
        jLabel1.setBounds(10, 10, 60, 14);

        jTFprod_nome.setColumns(50);
        jPanelDados.add(jTFprod_nome);
        jTFprod_nome.setBounds(10, 80, 406, 20);

        jLabel2.setText("Nome do Produto");
        jPanelDados.add(jLabel2);
        jLabel2.setBounds(10, 60, 150, 14);

        jTFprod_codigo.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusLost(java.awt.event.FocusEvent evt) {
                jTFprod_codigoFocusLost(evt);
            }
        });
        jPanelDados.add(jTFprod_codigo);
        jTFprod_codigo.setBounds(10, 30, 80, 20);

        jFTFprod_estoque.setColumns(10);
        jFTFprod_estoque.setFormatterFactory(new javax.swing.text.DefaultFormatterFactory(new javax.swing.text.NumberFormatter(new java.text.DecimalFormat("#,##0"))));
        jPanelDados.add(jFTFprod_estoque);
        jFTFprod_estoque.setBounds(110, 130, 86, 20);

        jFTFprod_valor.setColumns(10);
        jFTFprod_valor.setFormatterFactory(new javax.swing.text.DefaultFormatterFactory(new javax.swing.text.NumberFormatter(new java.text.DecimalFormat("#,##0.00"))));
        jPanelDados.add(jFTFprod_valor);
        jFTFprod_valor.setBounds(10, 130, 86, 20);

        jLabel3.setText("Valor");
        jPanelDados.add(jLabel3);
        jLabel3.setBounds(10, 110, 40, 14);

        jLabel4.setText("Estoque");
        jPanelDados.add(jLabel4);
        jLabel4.setBounds(110, 110, 50, 14);

        getContentPane().add(jPanelDados);
        jPanelDados.setBounds(10, 11, 610, 170);

        jPanelBotoes.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        jPanelBotoes.setLayout(null);

        jBNovo.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Novo.png"))); // NOI18N
        jBNovo.setText("Novo");
        jBNovo.setToolTipText("Novo Registro");
        jBNovo.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBNovo.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBNovo.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBNovo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBNovoActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBNovo);
        jBNovo.setBounds(6, 6, 80, 60);

        jBAlterar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Alterar.png"))); // NOI18N
        jBAlterar.setText("Alterar");
        jBAlterar.setToolTipText("Altera Dados");
        jBAlterar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBAlterar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBAlterar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBAlterar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBAlterarActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBAlterar);
        jBAlterar.setBounds(92, 6, 80, 60);

        jBExcluir.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Excluir.png"))); // NOI18N
        jBExcluir.setToolTipText("Exclui Registro");
        jBExcluir.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBExcluir.setLabel("Excluir");
        jBExcluir.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBExcluir.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBExcluir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBExcluirActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBExcluir);
        jBExcluir.setBounds(178, 6, 80, 60);

        jBSalvar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Salvar.png"))); // NOI18N
        jBSalvar.setToolTipText("Salva Dados");
        jBSalvar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBSalvar.setLabel("Salvar");
        jBSalvar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBSalvar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBSalvar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBSalvarActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBSalvar);
        jBSalvar.setBounds(264, 6, 80, 60);

        jBCancelar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Cancelar.png"))); // NOI18N
        jBCancelar.setText("Cancelar");
        jBCancelar.setToolTipText("Cancela Inserção ou Alteração");
        jBCancelar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBCancelar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBCancelar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBCancelar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBCancelarActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBCancelar);
        jBCancelar.setBounds(350, 6, 80, 60);

        jBLocalizar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Localizar.png"))); // NOI18N
        jBLocalizar.setText("Localizar");
        jBLocalizar.setToolTipText("Localiza Registro");
        jBLocalizar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBLocalizar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBLocalizar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBLocalizar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBLocalizarActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBLocalizar);
        jBLocalizar.setBounds(436, 6, 80, 60);

        jBSair.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Sair.png"))); // NOI18N
        jBSair.setText("Sair");
        jBSair.setToolTipText("Sair do Cadastro");
        jBSair.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBSair.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBSair.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBSair.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBSairActionPerformed(evt);
            }
        });
        jPanelBotoes.add(jBSair);
        jBSair.setBounds(522, 6, 80, 60);

        getContentPane().add(jPanelBotoes);
        jPanelBotoes.setBounds(10, 190, 610, 73);

        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setBounds((screenSize.width-644)/2, (screenSize.height-307)/2, 644, 307);
    }// </editor-fold>//GEN-END:initComponents

    private void jBNovoActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBNovoActionPerformed
    {//GEN-HEADEREND:event_jBNovoActionPerformed
        jTFprod_codigo.setText("0");
        jTFprod_codigo.setEnabled(false);
        habilitarCampos(true);
        estadoBotoesDigitacao();
        jTFprod_nome.requestFocus();
    }//GEN-LAST:event_jBNovoActionPerformed

    private void jBAlterarActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBAlterarActionPerformed
    {//GEN-HEADEREND:event_jBAlterarActionPerformed
        jTFprod_codigo.setEnabled(false);
        habilitarCampos(true);
        estadoBotoesDigitacao();
        jTFprod_nome.requestFocus();
    }//GEN-LAST:event_jBAlterarActionPerformed

    private void jBExcluirActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBExcluirActionPerformed
    {//GEN-HEADEREND:event_jBExcluirActionPerformed
        if (JOptionPane.showConfirmDialog(this, "Confirma Exclusão?", "Confirmação", JOptionPane.YES_OPTION) == JOptionPane.YES_OPTION)
        {
            try
            {
                //efetua a exclusão no banco
                produtos.setProd_codigo(Integer.valueOf(jTFprod_codigo.getText()));
                produtos.excluir();
                //..........................
                limparCampos();
                estadoBotoesInicial();
                jTFprod_codigo.requestFocus();
            }
            catch(Exception ex)
            {
                JOptionPane.showMessageDialog(this, "Registro não pode ser Excluído pois está em uso em outra Tabela!", "Informação", JOptionPane.INFORMATION_MESSAGE);
                System.out.println("Erro: \n" + ex.toString());
            }
        }
    }//GEN-LAST:event_jBExcluirActionPerformed

    private void jBSalvarActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBSalvarActionPerformed
    {//GEN-HEADEREND:event_jBSalvarActionPerformed
        if (jTFprod_nome.getText().equals(""))
        {
            JOptionPane.showMessageDialog(this, "Entre com o Nome do Produto", "Informação", JOptionPane.INFORMATION_MESSAGE);
        }
        if (!jTFprod_nome.getText().equals(""))
        {
            try
            {
                //efetua a gravação no banco
                produtos.setProd_codigo(Integer.valueOf(jTFprod_codigo.getText()));
                produtos.setProd_nome(jTFprod_nome.getText());
                if (!jFTFprod_valor.getText().equals(""))
                    produtos.setProd_valor(Double.valueOf(jFTFprod_valor.getText().replace(".", "").replace(",", ".")));
                else
                    produtos.setProd_valor(0.0);
                if (!jFTFprod_estoque.getText().equals(""))
                    produtos.setProd_estoque(Integer.valueOf(jFTFprod_estoque.getText().replace(".", "")));
                else
                    produtos.setProd_estoque(0);
                produtos.salvarDados();
                //..........................
                limparCampos();
                jTFprod_codigo.setEnabled(true);
                habilitarCampos(false);
                estadoBotoesInicial();
                jTFprod_codigo.requestFocus();
            }
            catch(Exception ex)
            {
                JOptionPane.showMessageDialog(this, "Algum campo possui Valor Incorreto!", "Informação", JOptionPane.INFORMATION_MESSAGE);
                System.out.println("Erro: \n" + ex.toString());
            }
        }
    }//GEN-LAST:event_jBSalvarActionPerformed

    private void jBCancelarActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBCancelarActionPerformed
    {//GEN-HEADEREND:event_jBCancelarActionPerformed
        limparCampos();
        jTFprod_codigo.setEnabled(true);
        habilitarCampos(false);
        estadoBotoesInicial();
        jTFprod_codigo.requestFocus();
    }//GEN-LAST:event_jBCancelarActionPerformed

    private void jBLocalizarActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBLocalizarActionPerformed
    {//GEN-HEADEREND:event_jBLocalizarActionPerformed
        ConsultaPadrao consProd = new ConsultaPadrao(null, true);
        //Configurando a Consulta
        String[] vet = new String[2];
        vet[0] = "Código";
        vet[1] = "Nome";
        //configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, String tabela)
        consProd.configuraOpcoes(vet, 2, 1, "Produtos");
        //........................

        consProd.setVisible(true);
        if (consProd.getCodigo() != 0)
        {
            jTFprod_codigo.setText(String.valueOf(consProd.getCodigo()));
            consProd.dispose();
            jTFprod_codigoFocusLost(null);
            estadoBotoesBrowse();
        }
        else
        {
            consProd.dispose();
            jTFprod_codigo.requestFocus();
        }
    }//GEN-LAST:event_jBLocalizarActionPerformed

    private void jBSairActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_jBSairActionPerformed
    {//GEN-HEADEREND:event_jBSairActionPerformed
        dispose();
    }//GEN-LAST:event_jBSairActionPerformed

    private void jTFprod_codigoFocusLost(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_jTFprod_codigoFocusLost
        if (!jTFprod_codigo.getText().equals(""))
        {
            produtos.setProd_codigo(Integer.valueOf(jTFprod_codigo.getText()));
            if (produtos.buscarPorCodigo())
            {
                //Preenche a Tela
                jTFprod_nome.setText(produtos.getProd_nome());
                jFTFprod_valor.setValue(produtos.getProd_valor());
                jFTFprod_estoque.setValue(produtos.getProd_estoque());
                estadoBotoesBrowse();
            }
            else
            {
                JOptionPane.showMessageDialog(this, "Produto não Encontrado", "Informação", JOptionPane.INFORMATION_MESSAGE);
                limparCampos();
                jTFprod_codigo.requestFocus();
            }
        }
    }//GEN-LAST:event_jTFprod_codigoFocusLost

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jBAlterar;
    private javax.swing.JButton jBCancelar;
    private javax.swing.JButton jBExcluir;
    private javax.swing.JButton jBLocalizar;
    private javax.swing.JButton jBNovo;
    private javax.swing.JButton jBSair;
    private javax.swing.JButton jBSalvar;
    private javax.swing.JFormattedTextField jFTFprod_estoque;
    private javax.swing.JFormattedTextField jFTFprod_valor;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JPanel jPanelBotoes;
    private javax.swing.JPanel jPanelDados;
    private javax.swing.JTextField jTFprod_codigo;
    private javax.swing.JTextField jTFprod_nome;
    // End of variables declaration//GEN-END:variables
}
