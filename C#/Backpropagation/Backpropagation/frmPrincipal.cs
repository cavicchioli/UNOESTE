using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Backpropagation.classe;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Backpropagation
{
    public partial class frmPrincipal : Form
    {
        private Int32 numNeurosEntrada;
        private Int32 numNeurosOculta;
        private Int32 numNeurosSaida;
        private Int32 numeroIteracoes;
        private Double taxaAprendizagem;
        private String funcaoTreinamento;
        
        private Int32 numLinhasArquivo;
        private Int32 numColunasArquivo;

        private String[,] matrizTreinamento;
        private String[,] matrizTeste;
        private String[,] matrizResultado;
        private String[,] matrizConfusao;
        
        private String[,] matrizDesejado;
        private String[] vetorSaidas;

        private Neuronio[] neurosEntrada;
        private Neuronio[] neurosOcultos;
        private Neuronio[] neurosSaidas;

        private Double ErroRede;

        private Boolean treinou = false;
        private Double derivada;
        private Double desejado;

        private Int32 vRound = 8;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        // CALCULAR DERIVADA LINEAR //
        private Double DerivadaNetLinear(Double fNet)
        {
            return 1/10.0;
        }

        // CALCULAR DERIVADA LOGISTICA //
        private Double DerivadaNetLogistica(Double fNet)
        {
            return Math.Round((fNet * (1.0-fNet)),vRound);
        }

        // CALCULAR DERIVADA HIPERBOLICA //
        private Double DerivadaNetHiperbolica(Double fNet)
        {
            return Math.Round((1.0 - (fNet*fNet)),vRound);
        }

        // CALCULAR FNET LINEAR //
        private Double fNetLinear(Double net)
        {
            return net/10.0;
        }

        // CALCULAR FNET LOGISTICA //
        private Double fNetLogistica(Double net)
        {
            return Math.Round((1.0 / (1.0 + Math.Exp(-net))),vRound);
        }

        // CALCULAR FNET HIPERBOLICA //
        private Double fNetHiperbolica(Double net)
        {
            return Math.Round((1.0 - Math.Exp(-2.0 * net)) / (1.0 + Math.Exp(-2.0 * net)),vRound);
        }

        private void NormalizaTreinamento()
        {
            Double maior;
            Double menor;
            Double intervalo;

            for (Int32 j = 0; j < numColunasArquivo - 1; j++)
            {
                maior = Convert.ToDouble(matrizTreinamento[1,0]);
                menor = Convert.ToDouble(matrizTreinamento[1,0]);
                intervalo = 0;

                for (Int32 i = 1; i < numLinhasArquivo; i++)
                {
                    if (Convert.ToDouble(matrizTreinamento[i, j]) > maior)
                        maior = Convert.ToDouble(matrizTreinamento[i, j]);

                    if (Convert.ToDouble(matrizTreinamento[i, j]) < menor)
                        menor = Convert.ToDouble(matrizTreinamento[i, j]);
                }

                intervalo = (maior - menor);

                for (Int32 i = 1; i < numLinhasArquivo; i++)
                {
                    Double valor = Math.Round((Convert.ToDouble(matrizTreinamento[i, j]) / intervalo),vRound);
                    matrizTreinamento[i, j] = Convert.ToString(Math.Abs(valor));
                }
            }
        }

        private void NormalizaTeste()
        {
            Double maior;
            Double menor;
            Double intervalo;

            for (Int32 j = 0; j < numColunasArquivo - 1; j++)
            {
                maior = Convert.ToDouble(matrizTeste[1, 0]);
                menor = Convert.ToDouble(matrizTeste[1, 0]);
                intervalo = 0;

                for (Int32 i = 1; i < numLinhasArquivo; i++)
                {
                    if (Convert.ToDouble(matrizTeste[i, j]) > maior)
                        maior = Convert.ToDouble(matrizTeste[i, j]);

                    if (Convert.ToDouble(matrizTeste[i, j]) < menor)
                        menor = Convert.ToDouble(matrizTeste[i, j]);
                }

                intervalo = (maior - menor);

                for (Int32 i = 1; i < numLinhasArquivo; i++)
                {
                    Double valor = Math.Round((Convert.ToDouble(matrizTeste[i, j]) / intervalo), vRound);
                    matrizTeste[i, j] = Convert.ToString(Math.Abs(valor));
                }
            }
        }

        private Int32 posDesejado(Double desejado)
        {
            Int32 indice = 0;

            while (indice < vetorSaidas.Length 
                && desejado.ToString() != vetorSaidas[indice])
                indice++;
            
            return indice;
        }

        private void btnArquivoTreina_Click(object sender, EventArgs e)
        {
            // VERIFICA SE O VALOR DE INTERAÇÕES É O MINIMO DE 100 //
            if (int.TryParse(txtIntera.Text, out numeroIteracoes) && Convert.ToInt32(txtIntera.Text) >= 100)
            {
                numeroIteracoes = Convert.ToInt32(txtIntera.Text);

                // VERIFICA SE O VALOR DA TAXA DE APRENDIZAGEM ESTÁ ENTRE 0.1 E 1.0 //
                if (double.TryParse(txtTaxaAprende.Text, out taxaAprendizagem)
                    && Convert.ToDouble(txtTaxaAprende.Text) > 0.1 && Convert.ToDouble(txtTaxaAprende.Text) <= 1)
                {
                    taxaAprendizagem = Convert.ToDouble(txtTaxaAprende.Text);

                    // RECEBE NOME DO ARQUIVO PARA CARREGAR NA MATRIZ //
                    if (openFileAmostras.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            StreamReader arqStream = new StreamReader(openFileAmostras.OpenFile());

                            if (arqStream != null)
                            {
                                using (arqStream)
                                {
                                    string sLine = "";
                                    numLinhasArquivo = 0;
                                    numColunasArquivo = 0;
                                    txtArquivoTreina.Text = openFileAmostras.FileName;
                                    ArrayList arrText = new ArrayList();

                                    // LÊ O ARQUIVO DE DADOS //
                                    while (sLine != null)
                                    {
                                        sLine = arqStream.ReadLine();

                                        if (sLine != null)
                                        {
                                            arrText.Add(sLine);
                                            numLinhasArquivo++;
                                        }
                                    }
                                    arqStream.Close();

                                    // TRANSFORMAR O ARRAY LIST EM UMA MATRIZ //
                                    String[] linha = arrText[0].ToString().Split(',');
                                    numColunasArquivo = linha.Length;
                                    matrizTreinamento = new String[numLinhasArquivo, numColunasArquivo];

                                    for (Int32 i = 0; i < numLinhasArquivo; i++)
                                    {
                                        linha = arrText[i].ToString().Split(',');
                                        for (Int32 j = 0; j < linha.Length; j++)
                                            matrizTreinamento[i, j] = linha[j];
                                    }
                                    NormalizaTreinamento();

                                    // CONSTROI COLUNAS DO DATA GRID //
                                    for (Int32 i = 0; i < numColunasArquivo; i++)
                                        dgvTreinamento.Columns.Add(matrizTreinamento[0, i], matrizTreinamento[0, i]);

                                    // ALOCA VALORES NAS LINHAS DO DATA GRID //
                                    for (Int32 i = 1; i < numLinhasArquivo; i++)
                                    {
                                        dgvTreinamento.Rows.Add();
                                        for (Int32 j = 0; j < numColunasArquivo; j++)
                                            dgvTreinamento[j, i-1].Value = matrizTreinamento[i, j];
                                        //dgvTreinamento.Rows.Add(arrText[i].ToString().Split(','));
                                    }

                                    // DEFINIR NEURONIOS ENTRADA, OCULTOS, SAIDA //
                                    String Classes = "";
                                    numNeurosEntrada = (numColunasArquivo - 1);

                                    // Conta quantas saidas existem na matriz, Ex: 1,2,3,4,5 //
                                    for (Int32 i = 1; i < numLinhasArquivo; i++)
                                        if (!Classes.Contains(matrizTreinamento[i, (numColunasArquivo - 1)]))
                                            Classes = Classes + matrizTreinamento[i, (numColunasArquivo - 1)] + "|";

                                    vetorSaidas = Classes.Split('|');
                                    
                                    numNeurosSaida = (vetorSaidas.Length-1);
                                    numNeurosOculta = ((numNeurosEntrada + numNeurosSaida) / 2);

                                    matrizDesejado = new String[numNeurosSaida, numNeurosSaida];
                                    for (Int32 i = 0; i < numNeurosSaida; i++)
                                        for (Int32 j = 0; j < numNeurosSaida; j++)
                                            matrizDesejado[i, j] = (i == j) ? "1" : "0";

                                    txtNeuroEntrada.Text = numNeurosEntrada.ToString();
                                    txtNeuroOculto.Text = numNeurosOculta.ToString();
                                    txtNeuroSaida.Text = numNeurosSaida.ToString();
                                    // FIM NEURONIOS //

                                    // DEFINE FUNÇÃO DE TREINAMENTO //
                                    if (rdbLinear.Checked)
                                        funcaoTreinamento = "linear";
                                    else
                                        if (rdbLogistica.Checked)
                                            funcaoTreinamento = "logistica";
                                    else
                                            funcaoTreinamento = "hiperbolica";

                                    // CRIA NEURONIOS //
                                    neurosEntrada = new Neuronio[numNeurosEntrada];
                                    neurosOcultos = new Neuronio[numNeurosOculta];
                                    neurosSaidas = new Neuronio[numNeurosSaida];

                                    // Cria ligações dos neuronios entrada com neuronios ocultos //
                                    for (Int32 i = 0; i < numNeurosEntrada; i++)
                                        neurosEntrada[i] = new Neuronio(numNeurosOculta);

                                    // Cria ligações dos neuronios ocultos com neironios saida //
                                    for (Int32 i = 0; i < numNeurosOculta; i++)
                                        neurosOcultos[i] = new Neuronio(numNeurosSaida);

                                    for (Int32 i = 0; i < numNeurosSaida; i++)
                                        neurosSaidas[i] = new Neuronio(1);
                                    // FIM NEURONIOS //

                                    // GERA PESOS INICIAIS COM RANDON//
                                    Random rnd = new Random();

                                    // Gerar pesos para conexão de entrada e oculta //
                                    for (Int32 i = 0; i < numNeurosEntrada; i++)
                                        for (Int32 j = 0; j < numNeurosOculta; j++)
                                        {
                                            Double valor = (rnd.NextDouble() * 2.0) - 1;
                                            neurosEntrada[i].setW(j, valor);
                                        }

                                    // Gerar pesos para conexão de oculta e saida //
                                    for (Int32 i = 0; i < numNeurosOculta; i++)
                                        for (Int32 j = 0; j < numNeurosSaida; j++)
                                        {
                                            Double valor = (rnd.NextDouble() * 2.0) -1;
                                            neurosOcultos[i].setW(j, valor);
                                        }
                                    // FIM GERAR PESOS//
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao acessar arquivo de amostas. " + ex.ToString());
                        }
                    }
                }
                else
                    MessageBox.Show("Taxa de aprendizagem inválida, deve estar entre 0,1 e 1,0", "Taxa de Aprendizagem");
            }
            else
                MessageBox.Show("O número de iterações é inválido ou menor que 100.","Número de Iterações");
        }

        private void btnTreinamento_Click(object sender, EventArgs e)
        {
            Int32 graficoAtraso;
            Int32 graficoItera;
            Double ErroSaida = 0;
            
            if (int.TryParse(txtGraficoAtraso.Text, out graficoAtraso)
                && Convert.ToInt32(txtGraficoAtraso.Text) >= 0 && Convert.ToInt32(txtGraficoAtraso.Text) <= 10)
            {
                graficoAtraso = Convert.ToInt32(txtGraficoAtraso.Text);

                if (int.TryParse(txtGraficoItera.Text, out graficoItera)
                    && Convert.ToInt32(txtGraficoItera.Text) > 0 && Convert.ToInt32(txtGraficoItera.Text) <= 30)
                {
                    graficoItera = Convert.ToInt32(txtGraficoItera.Text);

                    if (!treinou)
                    {
                        Series erro = new Series();
                        erro.Name = "Erro";

                        graficoTreinamento.Series.Add(erro);

                        // ITERAÇÃO PARA PERCORRER X VEZES TODAS AS AMOSTRAS //
                        // EX: PERCORRER 100 VEZES TODAS AS AMOSTRAS (850 LINHAS) //
                        Int32 contador = 0;
                        while (contador < numeroIteracoes) //&& ErroSaida > 0.001
                        {
                            Double ErroIntera = 0.0;
                            // ITERAÇÃO QUE PERCORRE AS LINHAS DA MATRIZ DE TREINAMENTO) //
                            
                            for (Int32 k = 1; k < numLinhasArquivo; k++)
                            {
                                // INSERE AS AMOSTRAS NA CAMADA DE ENTRADA (COLUNAS DA MATRIZ DE TREINAMENTO) //
                                for (Int32 x = 0; x < (numColunasArquivo - 1); x++)
                                    neurosEntrada[x].setValor(Convert.ToDouble(matrizTreinamento[k, x]));

                                // VALOR DESEJADO DA ULTIMA COLUNA (CLASSE) //
                                desejado = Convert.ToDouble(matrizTreinamento[k, (numColunasArquivo - 1)]);

                                // MULTIPLICA E SOMA AS ENTRADAS PARA GERAR VALORES DA CAMADA OCULTA //
                                // netC = A.wc,a + B.wc,b //
                                for (Int32 posOculto = 0; posOculto < numNeurosOculta; posOculto++)
                                {
                                    Double netTemporario = 0;
                                    for (Int32 xw = 0; xw < numNeurosEntrada; xw++)
                                        netTemporario = Math.Round((netTemporario + (neurosEntrada[xw].getValor() * neurosEntrada[xw].getW(posOculto))),vRound);

                                    // Seta valor de Net no neuronio da camada oculta //
                                    neurosOcultos[posOculto].setNet(netTemporario);

                                    // Calcula a saida 'i' do neuronio da camada oculta //
                                    if (funcaoTreinamento == "linear") 
                                        neurosOcultos[posOculto].setI(Math.Round(fNetLinear(netTemporario),vRound));
                                    else
                                        if (funcaoTreinamento == "logistica")
                                            neurosOcultos[posOculto].setI(Math.Round(fNetLogistica(netTemporario),vRound));
                                        else // hiperbolica //
                                            neurosOcultos[posOculto].setI(Math.Round(fNetHiperbolica(netTemporario),vRound));
                                }

                                // MULTIPLICA E SOMA A CAMADA OCULTA PARA GERAR A CAMADA DE SAIDA //
                                // 'i' AGORA PASSA A SER A ENTRADA PARA A CAMADA DE SAIDA //
                                // netG = iC*wg,c + iD * wg,d + iE * wg,e + iF * wg,f //
                                ErroRede = 0;
                                for (Int32 posSaida = 0; posSaida < numNeurosSaida; posSaida++)
                                {
                                    Double netTemporario = 0;
                                    for (Int32 xw = 0; xw < numNeurosOculta; xw++)
                                        netTemporario = Math.Round(netTemporario + (neurosOcultos[xw].getI() * neurosOcultos[xw].getW(posSaida)),vRound);

                                    // Seta valor de Net no neuronio da camada de saida //
                                    neurosSaidas[posSaida].setNet(netTemporario);
                                    
                                    // Calcula a saida 'i' do neuronio da camada de saida //
                                    if (funcaoTreinamento == "linear")
                                    {
                                        neurosSaidas[posSaida].setI(Math.Round(fNetLinear(netTemporario),vRound));
                                        derivada = DerivadaNetLinear(Math.Round(fNetLinear(netTemporario),vRound));
                                    }
                                    else
                                        if (funcaoTreinamento == "logistica")
                                        {
                                            neurosSaidas[posSaida].setI(Math.Round(fNetLogistica(netTemporario),vRound));
                                            derivada = DerivadaNetLogistica(Math.Round(fNetLogistica(netTemporario),vRound));
                                        }
                                        else // hiperbolica //
                                        {
                                            neurosSaidas[posSaida].setI(Math.Round(fNetHiperbolica(netTemporario),vRound));
                                            derivada = DerivadaNetHiperbolica(Math.Round(fNetHiperbolica(netTemporario),vRound));
                                        }

                                    // CALCULA O ERRO DA SAIDA //
                                    // ErroG = (DesejadoG – iG).f’(netG) //
                                    ErroSaida = Math.Round(((Convert.ToDouble(matrizDesejado[posDesejado(desejado),posSaida]) - neurosSaidas[posSaida].getI()) * derivada),vRound);
                                    neurosSaidas[posSaida].setErro(ErroSaida);

                                    ErroRede += ErroSaida * ErroSaida;
                                }

                                ErroRede = ErroRede / 2.0;
                                ErroIntera = ErroIntera + ErroRede;

                                // MULTIPLICA E SOMA PARA GERAR OS ERROS DA CAMADA OCULTA E FAZ CORREÇÃO DO PESO DA LIGAÇÃO OCULTA ==> SAIDA //
                                for (Int32 posOculto = 0; posOculto < numNeurosOculta; posOculto++)
                                {
                                    // Calcula o erro para o neuronio da camada oculta //
                                    Double erroTemporario = 0;
                                    for (Int32 xw = 0; xw < numNeurosSaida; xw++)
                                        erroTemporario = Math.Round(erroTemporario + (neurosSaidas[xw].getErro() * neurosOcultos[posOculto].getW(xw)),vRound);

                                    if (funcaoTreinamento == "linear")
                                        erroTemporario *=  DerivadaNetLinear(neurosOcultos[posOculto].getI());
                                    else
                                        if (funcaoTreinamento == "logistica")
                                            erroTemporario *= DerivadaNetLogistica(neurosOcultos[posOculto].getI());
                                        else
                                            erroTemporario *= DerivadaNetHiperbolica(neurosOcultos[posOculto].getI());

                                    // Seta o erro no neuronio da camada oculta //
                                    neurosOcultos[posOculto].setErro(erroTemporario);
                                    
                                    // Faz a correção dos pesos do neuronio da camada oculta para o neuronio da camada de saida //
                                    // Novopeso wg,c = wg,c + n.ErroG.iC //
                                    for (Int32 xw = 0; xw < numNeurosSaida; xw++)
                                    {
                                        Double peso = Math.Round(neurosOcultos[posOculto].getW(xw),vRound);
                                        Double erroX = Math.Round(neurosSaidas[xw].getErro(),vRound);
                                        Double iX = Math.Round(neurosOcultos[posOculto].getI(),vRound);
                                        neurosOcultos[posOculto].setW(xw, Math.Round((peso + (taxaAprendizagem * erroX * iX)),vRound));
                                    }
                                }

                                // CORREÇÃO DOS PESSOS DA CAMADA ENTRADA ==> OCULTA //
                                for (Int32 posEntrada = 0; posEntrada < numNeurosEntrada; posEntrada++)
                                {
                                    // Novopeso  wc,a = wc,a + n.ErroC.EntradaA //
                                    for (Int32 xw = 0; xw < numNeurosOculta; xw++)
                                    {
                                        Double peso = Math.Round(neurosEntrada[posEntrada].getW(xw),vRound);
                                        Double erroX = Math.Round(neurosOcultos[xw].getErro(),vRound);
                                        Double entradaX = Math.Round(neurosEntrada[posEntrada].getValor(),vRound);
                                        neurosEntrada[posEntrada].setW(xw, Math.Round((peso + (taxaAprendizagem * erroX * entradaX)),vRound));
                                    }
                                }
                            }
                            

                            // ATUALIZAR O GRÁFICO TREINAMENTO //
                            // A CADA CICLO DE ITERAÇÃO DE TODAS AS AMOSTRAS //
                            // O ULTIMO ERRO GERADO É COLOCADO NO GRÁFICO //
                            if (contador % graficoItera == 0)
                            {
                                erro.Points.Add(ErroIntera / Convert.ToDouble(numLinhasArquivo));
                                graficoTreinamento.Update();
                            }
                            // FIM ATUALIZAR //

                            // AGUARDA TEMPO DEFINIDO (ATRASO) PARA INICIAR A PRÓXIMA ITERAÇÃO //
                            Thread.Sleep(graficoAtraso);

                            contador++;
                        }

                        treinou = true;
                        MessageBox.Show("Treinamento Completo", "Treinamento");
                    }
                    else
                        MessageBox.Show("Treinamento Completo", "Treinamento");

                }
                else
                    MessageBox.Show("Taxa de iteração do gráfico inválido. Definia um valor entre 1 e 30.", "Atualização do Gráfico");

            }
            else
                MessageBox.Show("Atraso de atualização do gráfico inválido. Definia um valor entre 0 e 10.","Atualização do Gráfico");
        }

        private void btnArquivoTeste_Click(object sender, EventArgs e)
        {
            // RECEBE NOME DO ARQUIVO PARA CARREGAR NA MATRIZ //
            if (openFileAmostras.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader arqStream = new StreamReader(openFileAmostras.OpenFile());

                    if (arqStream != null)
                    {
                        using (arqStream)
                        {
                            string sLine = "";
                            numLinhasArquivo = 0;
                            //numColunasArquivo = 0;
                            txtArquivoTeste.Text = openFileAmostras.FileName;
                            ArrayList arrText = new ArrayList();

                            // LÊ O ARQUIVO DE DADOS //
                            while (sLine != null)
                            {
                                sLine = arqStream.ReadLine();

                                if (sLine != null)
                                {
                                    arrText.Add(sLine);
                                    numLinhasArquivo++;
                                }
                            }
                            arqStream.Close();

                            // TRANSFORMAR O ARRAY LIST EM UMA MATRIZ //
                            String[] linha = arrText[0].ToString().Split(',');
                            //numColunasArquivo = linha.Length;
                            matrizTeste = new String[numLinhasArquivo, numColunasArquivo];

                            for (Int32 i = 0; i < numLinhasArquivo; i++)
                            {
                                linha = arrText[i].ToString().Split(',');
                                for (Int32 j = 0; j < linha.Length; j++)
                                    matrizTeste[i, j] = linha[j];
                            }
                            NormalizaTeste();

                            // CONSTROI COLUNAS DO DATA GRID //
                            for (Int32 i = 0; i < numColunasArquivo; i++)
                                dgvTeste.Columns.Add(matrizTeste[0, i], matrizTeste[0, i]);

                            // ALOCA VALORES NAS LINHAS DO DATA GRID //
                            for (Int32 i = 1; i < numLinhasArquivo; i++)
                            {
                                dgvTeste.Rows.Add();
                                for (Int32 j = 0; j < numColunasArquivo; j++)
                                    dgvTeste[j, i - 1].Value = matrizTeste[i, j];
                                //dgvTeste.Rows.Add(arrText[i].ToString().Split(','));
                            }

                            // == //

                            // DEFINI MATRIZ DE RESULTADOS //
                            matrizResultado = new String[numLinhasArquivo, numNeurosSaida+1];
                            // CONSTROI COLUNAS DO DATA GRID //
                            for (Int32 i = 0; i < numNeurosSaida; i++)
                            {
                                matrizResultado[0, i] = "S" + (i+1);
                                dgvResultados.Columns.Add("S" + (i + 1), "S" + (i + 1));
                            }
                            matrizResultado[0, numNeurosSaida] = "Desej";
                            dgvResultados.Columns.Add("Desej", "Desej");

                            // == //

                            // DEFINI MATRIZ DE CONFUSAO //
                            matrizConfusao = new String[numNeurosSaida+1, numNeurosSaida];
                            // CONSTROI COLUNAS DO DATA GRID //
                            for (Int32 i = 0; i < numNeurosSaida; i++)
                            {
                                matrizConfusao[0, i] = (i + 1).ToString();
                                dgvMatrizConfusa.Columns.Add((i+1).ToString(), (i+1).ToString());
                            }
                            for (Int32 i = 0; i < numNeurosSaida; i++)
                                dgvMatrizConfusa.Rows.Add();

                            for (Int32 i = 0; i < numNeurosSaida; i++)
                                for (Int32 j = 0; j < numNeurosSaida; j++)
                                    dgvMatrizConfusa[j, i].Value = "0";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar arquivo de amostas. " + ex.ToString());
                }
            }
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            // ENTRA COM VALORES DE TESTE NA REDE E GERA OS ERROS //
            Double maior;
            Int32 neuroIndice;
            Int32 linhaMatResultado = 0;
            Double ErroSaida = 0;

            pbTeste.Minimum = 0;
            pbTeste.Maximum = numLinhasArquivo;

            for (Int32 k = 1; k < numLinhasArquivo; k++)
            {
                // INSERE AS AMOSTRAS NA CAMADA DE ENTRADA //
                for (Int32 x = 0; x < (numColunasArquivo - 1); x++)
                    neurosEntrada[x].setValor(Convert.ToDouble(matrizTeste[k, x]));

                // VALOR DESEJADO DA ULTIMA COLUNA (CLASSE) //
                desejado = Convert.ToDouble(matrizTeste[k, (numColunasArquivo - 1)]);

                // MULTIPLICA E SOMA AS ENTRADAS PARA GERAR VALORES DA CAMADA OCULTA //
                // netC = A.wc,a + B.wc,b //
                for (Int32 posOculto = 0; posOculto < numNeurosOculta; posOculto++)
                {
                    Double netTemporario = 0;
                    for (Int32 xw = 0; xw < numNeurosEntrada; xw++)
                        netTemporario = Math.Round((netTemporario + (neurosEntrada[xw].getValor() * neurosEntrada[xw].getW(posOculto))), vRound);

                    // Seta valor de Net no neuronio da camada oculta //
                    neurosOcultos[posOculto].setNet(netTemporario);

                    // Calcula a saida 'i' do neuronio da camada oculta //
                    if (funcaoTreinamento == "linear")
                        neurosOcultos[posOculto].setI(Math.Round(fNetLinear(netTemporario), vRound));
                    else
                        if (funcaoTreinamento == "logistica")
                            neurosOcultos[posOculto].setI(Math.Round(fNetLogistica(netTemporario), vRound));
                        else // hiperbolica //
                            neurosOcultos[posOculto].setI(Math.Round(fNetHiperbolica(netTemporario), vRound));
                }

                // MULTIPLICA E SOMA A CAMADA OCULTA PARA GERAR A CAMADA DE SAIDA //
                // 'i' AGORA PASSA A SER A ENTRADA PARA A CAMADA DE SAIDA //
                // netG = iC*wg,c + iD * wg,d + iE * wg,e + iF * wg,f //
                for (Int32 posSaida = 0; posSaida < numNeurosSaida; posSaida++)
                {
                    Double netTemporario = 0;
                    for (Int32 xw = 0; xw < numNeurosOculta; xw++)
                        netTemporario = Math.Round(netTemporario + (neurosOcultos[xw].getI() * neurosOcultos[xw].getW(posSaida)), vRound);

                    // Seta valor de Net no neuronio da camada de saida //
                    neurosSaidas[posSaida].setNet(netTemporario);

                    // Calcula a saida 'i' do neuronio da camada de saida //
                    if (funcaoTreinamento == "linear")
                    {
                        neurosSaidas[posSaida].setI(Math.Round(fNetLinear(netTemporario), vRound));
                        derivada = DerivadaNetLinear(Math.Round(fNetLinear(netTemporario), vRound));
                    }
                    else
                        if (funcaoTreinamento == "logistica")
                        {
                            neurosSaidas[posSaida].setI(Math.Round(fNetLogistica(netTemporario), vRound));
                            derivada = DerivadaNetLogistica(Math.Round(fNetLogistica(netTemporario), vRound));
                        }
                        else // hiperbolica //
                        {
                            neurosSaidas[posSaida].setI(Math.Round(fNetHiperbolica(netTemporario), vRound));
                            derivada = DerivadaNetHiperbolica(Math.Round(fNetHiperbolica(netTemporario), vRound));
                        }

                    // CALCULA O ERRO DA SAIDA //
                    // ErroG = (DesejadoG – iG).f’(netG) //
                    ErroSaida = Math.Round(((Convert.ToDouble(matrizDesejado[posDesejado(desejado), posSaida]) - neurosSaidas[posSaida].getI()) * derivada), vRound);
                    neurosSaidas[posSaida].setErro(ErroSaida);
                }

                // COLOCA VALORES DE SAIDA NO GRID DE RESULTADOS //
                dgvResultados.Rows.Add();
                for (Int32 i = 0; i < numNeurosSaida; i++)
                {
                    matrizResultado[linhaMatResultado, i] = Math.Round(neurosSaidas[i].getI(), 3).ToString();
                    dgvResultados[i, linhaMatResultado].Value = matrizResultado[linhaMatResultado, i];
                }

                matrizResultado[linhaMatResultado, numNeurosSaida] = desejado.ToString();
                dgvResultados[numNeurosSaida, linhaMatResultado].Value = matrizResultado[linhaMatResultado, numNeurosSaida];
                linhaMatResultado++;
                
                // VERIFICA QUAL A SAIDA É MAIOR (SAIDA EX: ID, IE, IG)
                maior = 0;
                neuroIndice = 0;
                for (Int32 i = 0; i < numNeurosSaida; i++)
                    if (neurosSaidas[i].getI() > maior)
                    {
                        maior = neurosSaidas[i].getI();
                        neuroIndice = i;
                    }

                Int32 v = Convert.ToInt32(dgvMatrizConfusa[posDesejado(desejado), neuroIndice].Value)+1;
                dgvMatrizConfusa[posDesejado(desejado), neuroIndice].Value = Convert.ToString(v);

                pbTeste.Value = k;
            }

            MessageBox.Show("Teste Concluido.","Teste");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
