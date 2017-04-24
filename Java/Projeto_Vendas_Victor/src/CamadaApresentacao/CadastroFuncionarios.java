
package CamadaApresentacao;

import CamadaLogica.UperSize;
import CamadaNegocio.Funcionarios;
import javax.swing.JFormattedTextField;
import javax.swing.JOptionPane;

/**
 *
 * @author Victor
 */
public class CadastroFuncionarios extends javax.swing.JDialog {

    private Funcionarios funcionarios = new Funcionarios();
    /**
     * Creates new form CadastroFuncionarios2
     */
    public CadastroFuncionarios(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();
        
        arrumaJFormat();
        txtNome.setDocument(new UperSize(50, true));//40=tamanho, true=upperCase
        txtRG.setDocument(new UperSize(15, true));
        txtCPF.setDocument(new UperSize(14, true));
        txtLogradouro.setDocument(new UperSize(60, true));
        txtCidade.setDocument(new UperSize(40, true));
        txtCEP.setDocument(new UperSize(9, true));
        txtUF.setDocument(new UperSize(2, true));
        txtTelefone.setDocument(new UperSize(9, true));
        setLocationRelativeTo(null);
        habilitarCampos(false);
        estadoBotoesInicial();
        txtCodigo.requestFocus();
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
        txtCEP.setText("");
        txtCPF.setText("");
        txtCidade.setText("");
        txtCodigo.setText("");
        txtDDD.setText("");
        txtLogradouro.setText("");
        txtMatricula.setText("");
        txtNome.setText("");
        txtNumero.setText("");
        txtRG.setText("");
        txtTelefone.setText("");
        txtUF.setText("");
    }

    public void habilitarCampos(boolean flag)
    {
        txtCEP.setEnabled(flag);
        txtCPF.setEnabled(flag);
        txtCidade.setEnabled(flag);
        txtDDD.setEnabled(flag);
        txtLogradouro.setEnabled(flag);
        txtMatricula.setEnabled(flag);
        txtNome.setEnabled(flag);
        txtNumero.setEnabled(flag);
        txtRG.setEnabled(flag);
        txtTelefone.setEnabled(flag);
        txtUF.setEnabled(flag);
    }
    
     public void arrumaJFormat()
    {
        //Todo JFormattedTextField tem o problema de não apagar o seu conteúdo, a linha abaixo resolve isso
        txtCPF.setFocusLostBehavior(JFormattedTextField.COMMIT);
        txtCEP.setFocusLostBehavior(JFormattedTextField.COMMIT);
    }
    
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel2 = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jLabel5 = new javax.swing.JLabel();
        jLabel6 = new javax.swing.JLabel();
        jLabel7 = new javax.swing.JLabel();
        jLabel8 = new javax.swing.JLabel();
        jLabel9 = new javax.swing.JLabel();
        jLabel11 = new javax.swing.JLabel();
        txtCodigo = new javax.swing.JTextField();
        txtNome = new javax.swing.JTextField();
        txtLogradouro = new javax.swing.JTextField();
        txtNumero = new javax.swing.JTextField();
        txtCidade = new javax.swing.JTextField();
        txtUF = new javax.swing.JTextField();
        txtDDD = new javax.swing.JTextField();
        txtTelefone = new javax.swing.JTextField();
        txtCPF = new javax.swing.JFormattedTextField();
        jLabel12 = new javax.swing.JLabel();
        jLabel13 = new javax.swing.JLabel();
        txtMatricula = new javax.swing.JTextField();
        txtRG = new javax.swing.JTextField();
        txtCEP = new javax.swing.JFormattedTextField();
        jPanel1 = new javax.swing.JPanel();
        jBNovo = new javax.swing.JButton();
        jBAlterar = new javax.swing.JButton();
        jBExcluir = new javax.swing.JButton();
        jBSalvar = new javax.swing.JButton();
        jBCancelar = new javax.swing.JButton();
        jBLocalizar = new javax.swing.JButton();
        jBSair = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Cadastro de Funcionarios");
        setMaximumSize(new java.awt.Dimension(632, 400));
        setMinimumSize(new java.awt.Dimension(632, 400));
        getContentPane().setLayout(null);

        jPanel2.setBorder(javax.swing.BorderFactory.createEtchedBorder());

        jLabel1.setText("Código");

        jLabel2.setText("Logradouro");

        jLabel3.setText("Número");

        jLabel4.setText("Cidade");

        jLabel5.setText("UF");

        jLabel6.setText("CEP");

        jLabel7.setText("DDD");

        jLabel8.setText("Telefone");

        jLabel9.setText("Nome");

        jLabel11.setText("CPF");

        txtCodigo.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusLost(java.awt.event.FocusEvent evt) {
                txtCodigoFocusLost(evt);
            }
        });

        try {
            txtCPF.setFormatterFactory(new javax.swing.text.DefaultFormatterFactory(new javax.swing.text.MaskFormatter("###.###.###-##")));
        } catch (java.text.ParseException ex) {
            ex.printStackTrace();
        }

        jLabel12.setText("RG");

        jLabel13.setText("Matrícula");

        txtRG.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtRGActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout jPanel2Layout = new javax.swing.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel2Layout.createSequentialGroup()
                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addGroup(javax.swing.GroupLayout.Alignment.LEADING, jPanel2Layout.createSequentialGroup()
                                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(jPanel2Layout.createSequentialGroup()
                                        .addComponent(jLabel2)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel2Layout.createSequentialGroup()
                                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                            .addGroup(javax.swing.GroupLayout.Alignment.LEADING, jPanel2Layout.createSequentialGroup()
                                                .addComponent(txtCidade, javax.swing.GroupLayout.PREFERRED_SIZE, 231, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                .addComponent(txtUF, javax.swing.GroupLayout.PREFERRED_SIZE, 39, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                .addComponent(txtCEP, javax.swing.GroupLayout.PREFERRED_SIZE, 97, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                .addComponent(txtDDD, javax.swing.GroupLayout.PREFERRED_SIZE, 42, javax.swing.GroupLayout.PREFERRED_SIZE))
                                            .addComponent(txtLogradouro, javax.swing.GroupLayout.PREFERRED_SIZE, 439, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)))
                                .addComponent(txtNumero, javax.swing.GroupLayout.PREFERRED_SIZE, 134, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(jPanel2Layout.createSequentialGroup()
                                .addGap(0, 0, Short.MAX_VALUE)
                                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                    .addGroup(jPanel2Layout.createSequentialGroup()
                                        .addComponent(jLabel4)
                                        .addGap(204, 204, 204)
                                        .addComponent(jLabel5)
                                        .addGap(32, 32, 32)
                                        .addComponent(jLabel6)
                                        .addGap(90, 90, 90)
                                        .addComponent(jLabel7)
                                        .addGap(37, 37, 37)
                                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel3)
                                            .addComponent(txtTelefone, javax.swing.GroupLayout.PREFERRED_SIZE, 134, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addComponent(jLabel8)))
                                    .addGroup(jPanel2Layout.createSequentialGroup()
                                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(txtCodigo, javax.swing.GroupLayout.PREFERRED_SIZE, 111, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addComponent(jLabel1))
                                        .addGap(474, 474, 474)))))
                        .addGap(0, 13, Short.MAX_VALUE))
                    .addGroup(jPanel2Layout.createSequentialGroup()
                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(txtNome, javax.swing.GroupLayout.PREFERRED_SIZE, 583, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel9)
                            .addGroup(jPanel2Layout.createSequentialGroup()
                                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel13)
                                    .addComponent(txtMatricula, javax.swing.GroupLayout.PREFERRED_SIZE, 144, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel11)
                                    .addComponent(txtCPF, javax.swing.GroupLayout.PREFERRED_SIZE, 156, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel12)
                                    .addComponent(txtRG, javax.swing.GroupLayout.PREFERRED_SIZE, 158, javax.swing.GroupLayout.PREFERRED_SIZE))))
                        .addGap(0, 0, Short.MAX_VALUE))))
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1)
                .addGap(1, 1, 1)
                .addComponent(txtCodigo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(9, 9, 9)
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel2Layout.createSequentialGroup()
                        .addComponent(jLabel13)
                        .addGap(1, 1, 1)
                        .addComponent(txtMatricula, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                        .addGroup(jPanel2Layout.createSequentialGroup()
                            .addComponent(jLabel11)
                            .addGap(1, 1, 1)
                            .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                .addComponent(txtCPF, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addComponent(txtRG, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGroup(jPanel2Layout.createSequentialGroup()
                            .addComponent(jLabel12)
                            .addGap(21, 21, 21))))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jLabel9)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(txtNome, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel2)
                    .addComponent(jLabel3))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(txtLogradouro, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(txtNumero, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel4)
                    .addComponent(jLabel5)
                    .addComponent(jLabel6)
                    .addComponent(jLabel7)
                    .addComponent(jLabel8))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(txtCidade, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(txtUF, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(txtDDD, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(txtTelefone, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(txtCEP, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(20, 20, 20))
        );

        getContentPane().add(jPanel2);
        jPanel2.setBounds(10, 11, 612, 260);

        jPanel1.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        jPanel1.setLayout(null);

        jBNovo.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Novo.png"))); // NOI18N
        jBNovo.setText("Novo");
        jBNovo.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBNovo.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBNovo.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBNovo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBNovoActionPerformed(evt);
            }
        });
        jPanel1.add(jBNovo);
        jBNovo.setBounds(6, 6, 80, 60);

        jBAlterar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Alterar.png"))); // NOI18N
        jBAlterar.setText("Alterar");
        jBAlterar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBAlterar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBAlterar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBAlterar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBAlterarActionPerformed(evt);
            }
        });
        jPanel1.add(jBAlterar);
        jBAlterar.setBounds(92, 6, 80, 60);

        jBExcluir.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Excluir.png"))); // NOI18N
        jBExcluir.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBExcluir.setLabel("Excluir");
        jBExcluir.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBExcluir.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBExcluir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBExcluirActionPerformed(evt);
            }
        });
        jPanel1.add(jBExcluir);
        jBExcluir.setBounds(178, 6, 80, 60);

        jBSalvar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Salvar.png"))); // NOI18N
        jBSalvar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBSalvar.setLabel("Salvar");
        jBSalvar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBSalvar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBSalvar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBSalvarActionPerformed(evt);
            }
        });
        jPanel1.add(jBSalvar);
        jBSalvar.setBounds(264, 6, 80, 60);

        jBCancelar.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icones/Cancelar.png"))); // NOI18N
        jBCancelar.setText("Cancelar");
        jBCancelar.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jBCancelar.setMargin(new java.awt.Insets(1, 1, 1, 1));
        jBCancelar.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jBCancelar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jBCancelarActionPerformed(evt);
            }
        });
        jPanel1.add(jBCancelar);
        jBCancelar.setBounds(350, 6, 80, 60);

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
        jPanel1.add(jBLocalizar);
        jBLocalizar.setBounds(436, 6, 80, 60);

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
        jPanel1.add(jBSair);
        jBSair.setBounds(522, 6, 80, 60);

        getContentPane().add(jPanel1);
        jPanel1.setBounds(10, 281, 610, 70);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jBNovoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jBNovoActionPerformed
        txtCodigo.setText("0");
        txtCodigo.setEnabled(false);
        habilitarCampos(true);
        estadoBotoesDigitacao();
        txtMatricula.requestFocus();
    }//GEN-LAST:event_jBNovoActionPerformed

    private void jBAlterarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jBAlterarActionPerformed
        txtCodigo.setEnabled(false);
        habilitarCampos(true);
        estadoBotoesDigitacao();
        txtMatricula.requestFocus();
    }//GEN-LAST:event_jBAlterarActionPerformed

    private void jBExcluirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jBExcluirActionPerformed
        if (JOptionPane.showConfirmDialog(this, "Confirma Exclusão?", "Confirmação", JOptionPane.YES_OPTION) == JOptionPane.YES_OPTION)
               {
                   try
                   {
                       //efetua a exclusão no banco
                       funcionarios.setFunc_codigo(Integer.valueOf(txtCodigo.getText()));
                       funcionarios.excluir();
                       //..........................
                       limparCampos();
                       estadoBotoesInicial();
                       txtCodigo.requestFocus();
                   }
                   catch(Exception ex)
                   {
                       JOptionPane.showMessageDialog(this, "Registro não pode ser Excluído pois está em uso em outra Tabela!", "Informação", JOptionPane.INFORMATION_MESSAGE);
                       System.out.println("Erro: \n" + ex.toString());
                   }
               }
    }//GEN-LAST:event_jBExcluirActionPerformed

    private void jBSalvarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jBSalvarActionPerformed
        if (txtNome.getText().equals(""))
               {
                   JOptionPane.showMessageDialog(this, "Entre com o Nome do Funcionario", "Informação", JOptionPane.INFORMATION_MESSAGE);
               }
               if (!txtNome.getText().equals(""))
               {
                   try
                   {
                       //efetua a gravação no banco
                        funcionarios.setFunc_codigo(Integer.valueOf(txtCodigo.getText()));
                        funcionarios.setPes_cep(txtCEP.getText());
                        funcionarios.setFis_cpf(txtCPF.getText()); 
                        funcionarios.setPes_cidade(txtCidade.getText()); 
                        funcionarios.setPes_ddd(Integer.valueOf(txtDDD.getText())); 
                        funcionarios.setPes_logradouro(txtLogradouro.getText()); 
                        funcionarios.setFunc_matricula(Integer.valueOf(txtMatricula.getText())); 
                        funcionarios.setFis_nome(txtNome.getText()); 
                        funcionarios.setPes_nro(Integer.valueOf(txtNumero.getText())); 
                        funcionarios.setFis_rg(txtRG.getText()); 
                        funcionarios.setPes_telefone(txtTelefone.getText()); 
                        funcionarios.setPes_uf(txtUF.getText()); 
                        
                        funcionarios.salvarDados();
                       
                       //..........................
                       limparCampos();
                       txtCodigo.setEnabled(true);
                       habilitarCampos(false);
                       estadoBotoesInicial();
                       txtCodigo.requestFocus();
                   }
                   catch(Exception ex)
                   {
                       JOptionPane.showMessageDialog(this, "Algum campo possui Valor Incorreto!", "Informação", JOptionPane.INFORMATION_MESSAGE);
                       System.out.println("Erro: \n" + ex.toString());
                   }
               }
    }//GEN-LAST:event_jBSalvarActionPerformed

    private void jBCancelarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jBCancelarActionPerformed
        limparCampos();
        txtCodigo.setEnabled(true);
        habilitarCampos(false);
        estadoBotoesInicial();
        txtCodigo.requestFocus();
    }//GEN-LAST:event_jBCancelarActionPerformed

    private void jBLocalizarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jBLocalizarActionPerformed
        ConsultaPadrao cons = new ConsultaPadrao(null, true);
        //Configurando a Consulta
        String[] vet = new String[2];
        vet[0] = "Código";
        vet[1] = "Nome";
        //configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, String tabela)
        cons.configuraOpcoes(vet, 2, 1, "Funcionarios");
        //........................

        cons.setVisible(true);
        if (cons.getCodigo() != 0)
        { 
            
           txtCodigo.setText(String.valueOf(cons.getCodigo()));
            cons.dispose();
            txtCodigoFocusLost(null);
            estadoBotoesBrowse();
        }
        else
        {
            cons.dispose();
            txtCodigo.requestFocus();
        }
    }//GEN-LAST:event_jBLocalizarActionPerformed

    private void jBSairActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jBSairActionPerformed
dispose();
    }//GEN-LAST:event_jBSairActionPerformed

    private void txtRGActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtRGActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtRGActionPerformed

    private void txtCodigoFocusLost(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_txtCodigoFocusLost
        if (!txtCodigo.getText().equals(""))
        {
            funcionarios.setFunc_codigo(Integer.valueOf(txtCodigo.getText()));
            if (funcionarios.buscarPorCodigo())
            {
                //Preenche a Tela
                txtCEP.setText(funcionarios.getPes_cep());
                txtCPF.setText(funcionarios.getFis_cpf());
                txtCidade.setText(funcionarios.getPes_cidade());
                txtDDD.setText(String.valueOf(funcionarios.getPes_ddd()));
                txtLogradouro.setText(funcionarios.getPes_logradouro());
                txtMatricula.setText(String.valueOf(funcionarios.getFunc_matricula()));
                txtNome.setText(funcionarios.getFis_nome());
                txtNumero.setText(String.valueOf(funcionarios.getPes_nro()));
                txtRG.setText(funcionarios.getFis_rg());
                txtTelefone.setText(funcionarios.getPes_telefone());
                txtUF.setText(funcionarios.getPes_uf());
                
                estadoBotoesBrowse();
            }
            else
            {
                JOptionPane.showMessageDialog(this, "Funcionário não Encontrado", "Informação", JOptionPane.INFORMATION_MESSAGE);
                limparCampos();
                txtCodigo.requestFocus();
            }
        }
    }//GEN-LAST:event_txtCodigoFocusLost


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jBAlterar;
    private javax.swing.JButton jBCancelar;
    private javax.swing.JButton jBExcluir;
    private javax.swing.JButton jBLocalizar;
    private javax.swing.JButton jBNovo;
    private javax.swing.JButton jBSair;
    private javax.swing.JButton jBSalvar;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel11;
    private javax.swing.JLabel jLabel12;
    private javax.swing.JLabel jLabel13;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JFormattedTextField txtCEP;
    private javax.swing.JFormattedTextField txtCPF;
    private javax.swing.JTextField txtCidade;
    private javax.swing.JTextField txtCodigo;
    private javax.swing.JTextField txtDDD;
    private javax.swing.JTextField txtLogradouro;
    private javax.swing.JTextField txtMatricula;
    private javax.swing.JTextField txtNome;
    private javax.swing.JTextField txtNumero;
    private javax.swing.JTextField txtRG;
    private javax.swing.JTextField txtTelefone;
    private javax.swing.JTextField txtUF;
    // End of variables declaration//GEN-END:variables

}
