private void btnEfetivar_Click(object sender, EventArgs e)
        {
            int saida_m_cod, valorCombo1;

            // FACADE--------------------------
            EstoqueFacade verificarSaldoEstoque = new EstoqueFacade(1, Convert.ToInt32(txtQtde.Text));

            verificarSaldoEstoque.verficarSaldo();
            //----------------------------------

            int qtde;
            int cad_m_cod;
            valorCombo1 = Convert.ToInt32(cbbFunc.SelectedValue);
            
            try
            {
                DadosSaida saida = new DadosSaida();
                saida_m_cod = saida.gravar(valorCombo1, 0, dtpData.Value, txtTipo.Text);
                if (dgvItensSaida.Rows.Count > 1)
                {
                    for (int i = 0; i < dgvItensSaida.Rows.Count - 1; i++)
                    {
                        //cad_m_cod = Convert.ToInt32(dgvItensSaida.Rows[i].Cells["cad_m_cod"].Value); 
                        cad_m_cod = saida.codigoMaterial(Convert.ToString(dgvItensSaida.Rows[i].Cells["cad_m_cod"].Value));
                        qtde = Convert.ToInt32(dgvItensSaida.Rows[i].Cells["Quantidade"].Value);

                        saida.gravarItens(saida_m_cod, cad_m_cod, qtde);
                        saida.atualizarQtde(cad_m_cod, qtde);

                        MessageBox.Show("Operação efetuada com sucesso!");

                        limpar();
                        
                    }
                }
                else
                    MessageBox.Show("Não há dados na tabela");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao gravar Dados");
            }
                

        }