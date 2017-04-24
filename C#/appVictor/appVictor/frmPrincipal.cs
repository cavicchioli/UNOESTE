using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace appVictor
{
    public partial class frmPrincipal : Form
    {
        int qtdLinhasTeste, neuronioEntrada, iteracoes, qtdLinhasTreino, neuronioSaida, cOculta;

        double[][] pCamadaOculta, pCamadaSaida, arqEntrada, resultado, auxNormalizar;

        double[] netOculta, netSaida, sCamadaOculta, sCamadaSaida, eCamadaOculta, eCamadaSaida, sDesejada, sArquivo;

        double erroRede, txAprendizagem, erro_max;

        string funCalculo; 

        string[] classes, cabecalho;


        public frmPrincipal()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar() //inicialização
        {
            btnInicializar.Enabled = false;
            btnLoadTeste.Enabled = false;
            pnlConfig.Enabled = false;
            tabInformacoes.Enabled = false;

            ttbAprendizagem.Clear();
            ttbEntrada.Clear();
            ttbErro.Clear();
            ttbIteracao.Clear();
            ttbOculta.Clear();
            ttbSaida.Clear();

            rbLinear.Checked = true;

            ttbEntrada.Focus();

            dgvMatriz.Rows.Clear();
            dgvTeste.Rows.Clear();
            dgvTreino.Rows.Clear();

            mensagem.Text = "";
            tabInformacoes.SelectedIndex = 0;
        }

        #region CLIKES BOTOES
        private void btnLoadTreino_Click(object sender, EventArgs e)
        {
            String arq;

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "CSV Files(*.csv)|*.csv";
            op.FileName = "";
            op.RestoreDirectory = true;

            if (op.ShowDialog() == DialogResult.OK)
                arq = op.FileName;
            else
                arq = "";

            if (!arq.Equals(""))
            {
                qtdLinhasTreino = 0;//alimentar as variáveis com dados do arquivo
                carregaDadosArquivo(arq, qtdLinhasTreino, "T");

                calcCamadaOculta(1);//calculando a quantidada de neuronios da camada oculta 1- media aritmética, 2- media geométrica

                // cada text box recebe os valores consultados dentro do arquivo:
                ttbEntrada.Text = neuronioEntrada.ToString(); //O número de neurônios da camada de entrada.
                ttbSaida.Text = neuronioSaida.ToString(); //O número de Neurônios da camada de saída.
                ttbOculta.Text = cOculta.ToString(); //O número de Neurônios da camada Oculta.

                iniMatNormalizacao(); // inicializa a matriz de normalização

                normalizaArq(qtdLinhasTreino); //normaliza o arquivo com base na quantidade de exemplos para treino

                LoadDgvTreino();//carrega dgv de treino

                dgvTreino.ClearSelection(); 

                btnInicializar.Enabled = true;
                pnlConfig.Enabled = true;
                btnLoadTreino.Enabled = false;

                mensagem.Text = "O Arquivo de Treino foi carregado com sucesso!";

            }
        }

        private void btnInicializar_Click(object sender, EventArgs e)
        {
            mensagem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            //carrega todas as variáveis para conseguir treinar a rede
            if (!int.TryParse(ttbIteracao.Text, out iteracoes))
            {
                mensagem.Text = "Digite um número de Iterações Válida";
                ttbIteracao.Focus();
            }
            else
                if(!int.TryParse(ttbOculta.Text, out cOculta))
                {
                    mensagem.Text = "Camada Oculta inválida!";
                    ttbOculta.Focus();
                }
                else
                    if(!Double.TryParse(ttbAprendizagem.Text, out txAprendizagem) )
                    {
                        mensagem.Text = "Digite uma Taxa de Aprendizagem Válida!";
                        ttbAprendizagem.Focus();
                    }
                    else
                        if (!Double.TryParse(ttbErro.Text, out erro_max))
                        {
                            mensagem.Text = "Digite um Erro Máximo Válido!";
                            ttbErro.Focus();
                        }
                        else
                        {
                            mensagem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000FF");
                            btnInicializar.Enabled = false;
                            Treinar();// treina a rede
                            mensagem.Text="Rede Inicializada e Treinada com sucesso!";
                        }

        }

        private void Treinar()
        {
            int iteracao, linhaAnalisada;
            Random rand = new Random();
            int j; int i = 0;
           iteracao = 0;

            //matrizes da camada oculta
            netOculta = new double[cOculta];
            sCamadaOculta = new double[cOculta];
            eCamadaOculta = new double[cOculta];

            //matrizes da camada de saída
            netSaida = new double[neuronioSaida];
            sCamadaSaida = new double[neuronioSaida];
            eCamadaSaida = new double[neuronioSaida];

            //peso da camada oculta
            pCamadaOculta = new double[neuronioEntrada][];

            for (i = 0; i < pCamadaOculta.Length; i++)
                pCamadaOculta[i] = new double[cOculta];//criando a matriz com o tamanho necessario para camada oculta

            //peso da cama de saída
            pCamadaSaida = new double[cOculta][];

            for (i = 0; i < pCamadaSaida.Length; i++)
                pCamadaSaida[i] = new double[neuronioSaida];//criando a matriz com o tamanho necessario para camada de saida


            //0- inicializa os pesos com valores aleatórios
            //1- Aplica seta os valores nas matrizes
            for (i = 0; i < neuronioEntrada; i++)
                for (j = 0; j < cOculta; j++)// atribuindo pesos a camada oculta
                    pCamadaOculta[i][j] = (double)(rand.Next(-1, 1) + Math.Round(rand.NextDouble(), 5));


            sDesejada = new double[neuronioSaida];

            for (i = 0; i < cOculta; i++)//atribuindo pesos a camada de saida
                for (j = 0; j < neuronioSaida; j++)
                    pCamadaSaida[i][j] = (double)(rand.Next(-1, 1) + Math.Round(rand.NextDouble(), 5));


            if (rbLinear.Checked) // selecionando a função para o calculo
                funCalculo = "LINEAR";
            else
                if (rbLogistica.Checked)
                    funCalculo = "LOGISTICA";
                else
                    funCalculo = "HIPERBOLICA";
            do
            {
                iteracao++;
                for (linhaAnalisada = 0; linhaAnalisada < qtdLinhasTreino; linhaAnalisada++)
                {

                    double valorDesejado = funCalculo.Equals("HIPERBOLICA") ? -1 : 0;

                    for(i = 0; i< neuronioSaida; i++)
                        sDesejada[i] = valorDesejado;

                    sDesejada[Convert.ToInt32(sArquivo[linhaAnalisada]) - 1] = 1;

                    //2- calcular os nets da camada oculta
                    calNet(linhaAnalisada, "ocu");
                    //3-calcular as saidas da camada oculta
                    calSaida("ocu");
                    //4-calcular o net da camada de saida
                    calNet(linhaAnalisada, "");
                    //5-calcular a saida da camada de saída
                    calSaida("");
                    //executar o procedimento de backpropagation
                    BackPropagation(linhaAnalisada);
                }

            } while (iteracao < iteracoes);

            btnLoadTeste.Enabled = true;

        }

        private void btnLoadTeste_Click(object sender, EventArgs e)
        {
            String arq;
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "CSV Files (*.csv)|*.csv";
            op.FileName = "";
            op.RestoreDirectory = true;
            if (op.ShowDialog() == DialogResult.OK)
                arq = op.FileName;
            else
                arq = "";

            if (!arq.Equals(""))
            {
                qtdLinhasTeste = 0;
                carregaDadosArquivo(arq, qtdLinhasTeste, "");

                
                ttbEntrada.Text = neuronioEntrada.ToString(); 
                ttbSaida.Text = neuronioSaida.ToString(); 
                ttbOculta.Text = cOculta.ToString(); 


                int i, j;
                for (i = 0; i < qtdLinhasTeste; i++)
                    for (j = 0; j < neuronioEntrada; j++)
                        arqEntrada[i][j] = Math.Round((arqEntrada[i][j] - auxNormalizar[0][j]) / (auxNormalizar[1][j] - auxNormalizar[0][j]), 4);


               dgvTeste.ColumnHeadersVisible = true;
                for (j = 0; j < qtdLinhasTeste; j++)
                {
                    dgvTeste.RowCount += 1;

                    for (i = 0; i < neuronioEntrada; i++)
                    {
                        dgvTeste.Rows[j].Cells[i].Value = arqEntrada[j][i].ToString();
                    }

                    dgvTeste.Rows[j].Cells[i].Value = sArquivo[j];
                }

               
                btnLoadTeste.Enabled = false;
                pnlConfig.Enabled = false;

                Testar();
                Matriz();
                mensagem.Text = "Rede Testada com sucesso";
            }
        }

        private void Testar()
        {

            int indice, maior;
            double saida_maior;

            //inicializando tudo.
            for (int j = 0; j < cOculta; j++)
            {
                sCamadaOculta[j] = 0;
                netOculta[j] = 0;
            }

            for (int j = 0; j < neuronioSaida; j++)
            {
                netSaida[j] = 0;
                sCamadaSaida[j] = 0;
            }

            resultado = new double[neuronioSaida][];

            for(int i = 0; i < resultado.Length; i++)
                resultado[i] = new double[neuronioSaida];


            for (int j = 0; j < neuronioSaida; j++ )
                for (int k = 0; k < neuronioSaida; k++ )
                    resultado[j][k] = 0;

             //reexecuta as contas, para ver se o treino surtiu efeito
            for (int i = 0; i < qtdLinhasTeste; i++)
            {
                calNet(i, "ocu");
                calSaida("ocu");
                calNet(i, "");
                calSaida("");
                indice = Convert.ToInt32(sArquivo[i]) - 1;
                maior = 0;
                saida_maior = -2;


                for (int j = 0; j < neuronioSaida; j++)
                {
                    if (sCamadaSaida[j] > saida_maior)
                    {
                        maior = j;
                        saida_maior = sCamadaSaida[j];
                    }
                }

                resultado[indice][maior]++;
            }
        }
        
        private void Matriz()//transferere os valores obtidos para a matriz de confusão
        {
            
            tabInformacoes.TabIndex = 3;

            dgvMatriz.ColumnCount = 1;

            dgvMatriz.Columns[0].Width = 63;
            for (int i = 0; i < neuronioSaida; i++)
            {
                dgvMatriz.RowCount += 1;
                dgvMatriz.Rows[i].Cells[0].Value = classes.ElementAt(i);
                dgvMatriz.Rows[i].Cells[0].Style = dgvMatriz.ColumnHeadersDefaultCellStyle;
            }
            for (int i = 0; i < neuronioSaida; i++)
            {
                dgvMatriz.ColumnCount += 1;
                dgvMatriz.Columns[i + 1].Name = classes.ElementAt(i);
                dgvMatriz.Columns[i + 1].Width = 63;
                dgvMatriz.Columns[i].Width = 63;
                for (int j = 0; j < neuronioSaida; j++)
                {
                    dgvMatriz.Rows[j].Cells[i + 1].Value = resultado[j][i].ToString(); //pega o resultado e joga para a data grid view.
                }
            }

            tabInformacoes.Enabled = true;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Inicializar();
            btnLoadTreino.Enabled =true;
        }
        #endregion;

        public void carregaDadosArquivo(String arqCsv, int exemplos, String tipo)
        {
            int i;
            StreamReader arq;
            String linha;
            String[] vetClasses;
            arq = new StreamReader(arqCsv);

            if (tipo.Equals("T"))
                classes = new String[100];

            linha = arq.ReadLine();

            if (tipo.Equals("T"))
            {
                neuronioEntrada = 0;
                neuronioSaida = 0;

                //contar os neuronios de entrada por virgula
                for (i = 0; i < linha.Length; i++)
                    if (linha.ElementAt(i).Equals(','))
                        neuronioEntrada++; //as colunas do documento;

                //recebe cabeçalho separado por virgula
                cabecalho = new string[neuronioEntrada + 1]; //total de virgulas + 1, para a classe.
                cabecalho = linha.Split(',');//cada posição da string recebe um campo.. ex: X1, X2, X3...Classe

            }

            //leu a primeira linha com valores da tabela
            linha = arq.ReadLine();

            //atribui o tamanho corre ao vetor de classes
            vetClasses = new String[neuronioEntrada + 1];

            while (linha != null)//se a linha tem conteúdo começa a contar o numero de exemplos de treino/teste
            {   
                //numero de exemplos
                exemplos++;

                //recebe a linha de classes separada por virgula
                vetClasses = linha.Split(','); //vetor de strings

                if (tipo.Equals("T"))
                {
                    i = 0;//percorrer cada linha e pegar os valores de cada neurônio de saida diferentes
                    while (i < neuronioSaida && !classes[i].Equals(vetClasses[neuronioEntrada]))// repetição menor que o neurônio de saída e o que está na classe não 
                        i++;                                                                    //pode ser igual a ultima entrada que é classe(resposta desejada)
                                                                                                //para não pegar repetido
                    if (i == neuronioSaida)    //encontrou o valor do neuronio de saida então                                                 
                        classes[neuronioSaida++] = vetClasses[neuronioEntrada];//recebe o valor de cada classe de saida possivel (1...5)
                }
                linha = arq.ReadLine();//lê a proxima linha e começa denovo
            }
            arq.Close();

            if (tipo.Equals("T"))
                qtdLinhasTreino = exemplos;//quantidade de linhas ou seja quantidade de exemplos que existem no arquivo.
            else
                qtdLinhasTeste = exemplos;

            carregaEntradas(exemplos, arqCsv);
            
        }

        private void carregaEntradas(int exemplos, String arq)
        {
            int i, j = 0;
            StreamReader arquivo;
            String linha;
            String[] vetClasses;

            arqEntrada = new double[exemplos][];//cria uma matriz para colocar cada valor ex Linha [1][1=z, 2=d, 3=j ... ] 

            for (i = 0; i < arqEntrada.Length; i++)//
                arqEntrada[i] = new double[neuronioEntrada];//arquivo/matriz com o numero e conteúdo de cada linha do arquivo csv.

            sArquivo = new double[exemplos];//valores de saida para linha x saida 1
            arquivo = new StreamReader(arq);

            linha = arquivo.ReadLine();//leu a linha de cabeçalho
            linha = arquivo.ReadLine();//leu a linha que interessa que contem as entradas..

            while (linha != null)
            {//converte para double
                vetClasses = linha.Split(',');//recebe a linha do arquivo contendo as entradas.
                for (i = 0; i < neuronioEntrada; i++)
                    arqEntrada[j][i] = Convert.ToDouble(vetClasses[i]);//carrega essas entradas dentro da matriz que contem linha[]entradas[]
                sArquivo[j] = Convert.ToDouble(vetClasses[i]);//carrega o vetor de saidas esperadas ex. linha[] = valor esperado 1.0
                linha = arquivo.ReadLine();//le a linha e vai continuar até terminar o arquivo.
                j++;
            }
            arquivo.Close();
        }

        public void calcCamadaOculta(int calOculta)
        {
            // calculando a quantidade de neuronios na camada oculta
            if (calOculta == 1)
            {
                cOculta = (neuronioEntrada + neuronioSaida) / 2; //por média aritmética
                ttbOculta.Text = cOculta.ToString();
                ttbOculta.ReadOnly = true;
            }
            else
            {
                if (calOculta == 2)
                {
                    cOculta = Convert.ToInt32(Math.Sqrt(neuronioEntrada * neuronioSaida)); //por média geométrica
                    ttbOculta.Text = cOculta.ToString();
                    ttbOculta.ReadOnly = true;
                }
                else
                {
                    ttbOculta.ReadOnly = false;
                    ttbOculta.Focus();
                    ttbOculta.SelectionStart = ttbOculta.Text.Length + 1;
                }
            }
        }

        private void iniMatNormalizacao()
        {
            int i, j;
            //cria os pesos para a matriz de normalização de acordo com os valores guardados dentro do arquivo de entrada (matriz). 
            auxNormalizar = new double[2][];
            for (i = 0; i < auxNormalizar.Length; i++)//tamanho das entradas no caso tem 6..
                auxNormalizar[i] = new double[neuronioEntrada];

            for (j = 0; j < neuronioEntrada; j++)
            {
                auxNormalizar[0][j] = 100;
                auxNormalizar[1][j] = 0;
            }

            for (i = 0; i < qtdLinhasTreino; i++)
            {
                for (j = 0; j < neuronioEntrada; j++)
                {
                    if (arqEntrada[i][j] < auxNormalizar[0][j])
                        auxNormalizar[0][j] = arqEntrada[i][j];
                    if (arqEntrada[i][j] > auxNormalizar[1][j])
                        auxNormalizar[1][j] = arqEntrada[i][j];
                }
            }
        }

        private void normalizaArq(int qtdEx)
        {
            for( int k = 0; k < qtdEx; k++)
                for(int v=0; v < neuronioEntrada; v++)
                    arqEntrada[k][v] = Math.Round((arqEntrada[k][v] - auxNormalizar[0][v]) / (auxNormalizar[1][v] - auxNormalizar[0][v]), 4);//normaliza e pega 4 casas
        }

        public void LoadDgvTreino()
        {
            int k;
            dgvTreino.ColumnHeadersVisible = true;

            for (int v = 0; v < qtdLinhasTreino; v++ )
            {
                dgvTreino.RowCount += 1;

                k = 0;
                while( k < neuronioEntrada)
                {

                    dgvTreino.Rows[v].Cells[k].Value = arqEntrada[v][k].ToString();
                    k++;
                }         
                dgvTreino.Rows[v].Cells[k].Value = sArquivo[v];
            }
           
        }

        private void BackPropagation(int linha)
        {
            int i,j;

            //6-calcular o erros da camada de saída
            //7-calcular o erros da camada oculta
            calErros(); //calcula os erros
            //10 - calcula o erro da rede.
            calErroRede(); //calcula o erro da rede.

            if (erroRede > erro_max)
            {
                //8- atualiza os pesos da camada de saída
                for (i = 0; i < cOculta; i++)
                    for (j = 0; j < neuronioSaida; j++ )
                        pCamadaSaida[i][j] = (double)(Math.Round((pCamadaSaida[i][j] + (txAprendizagem * eCamadaSaida[j] * sCamadaOculta[i])), 5));

                //9- atualiza os pesoas da camada oculta
                for (i = 0; i < neuronioEntrada; i++)
                    for (j = 0; j < cOculta; j++)
                        pCamadaOculta[i][j] = (double)(Math.Round((pCamadaOculta[i][j] + (txAprendizagem * eCamadaOculta[j] * arqEntrada[linha][i])), 5));
            }
        }

        #region CALCULOS
        private void calNet(int linha, string tipo)
        {
            double net;
            int i, j;
            

            if (tipo == "ocu")
            {
                
                for(i = 0; i< cOculta; i++)
                {
                    net = 0;

                    for (j = 0; j < neuronioEntrada; j++)
                        net += (double)(Math.Round(arqEntrada[linha][j] * pCamadaOculta[j][i], 8));

                    netOculta[i] = net;
                }
            }
            else
            {
                for (i = 0; i < neuronioSaida; i++)
                {
                    net = 0;

                    for (j = 0; j < cOculta; j++)
                        net += (double)(Math.Round(sCamadaOculta[j] * pCamadaSaida[j][i], 8));

                    netSaida[i] = net;
                }
            }
        }

        private void calSaida(string tipo)
        {
            if (rbLinear.Checked)
                FunLinear(tipo);
            else
            {
                if (rbLogistica.Checked)
                    FunLogistica(tipo);
                else
                    FunTgHiberbolica(tipo);
            }
        }

        private void FunLinear(string camada)
        {
            int i;

            if (camada =="ocu")
            {
                for(i = 0; i< cOculta; i++)
                    sCamadaOculta[i] = (double)(Math.Round(netOculta[i] / 5.0, 8));
            }
            else//calcula para a camada de saída então.
            {
                for (i = 0; i < neuronioSaida; i++)
                    sCamadaSaida[i] = (double)(Math.Round(netSaida[i] / 5.0, 8));
            }
        }

        private void FunLogistica(string camada)
        {
            int i;

            if (camada.Equals("ocu"))
            {
               for(i = 0; i<cOculta; i++)
                    sCamadaOculta[i] = (double)(Math.Round(1 / (1 + Math.Round(Math.Exp(-netOculta[i]), 8)), 8));
            }
            else
            {
                for (i = 0; i < neuronioSaida; i++)
                    sCamadaSaida[i] = (double)(Math.Round(1 / (1 + Math.Round(Math.Exp(-netSaida[i]), 8)), 8));
            }
        }

        private void FunTgHiberbolica(string camada)
        {
            int i;
            double obtido;

            if (camada.Equals("ocu"))
            {
                for (i = 0; i < cOculta; i++)
                {
                    obtido = (double)(Math.Round((1 - Math.Round(Math.Exp(-2 * netOculta[i]), 8)) / (1 + Math.Round(Math.Exp(-2 * netOculta[i]), 8)), 8));

                    if (Double.IsNaN(obtido))
                        obtido = (netOculta[i] > 0) ? (double)1 : (double)-1;
                    sCamadaOculta[i] = (double)(obtido);
                }
            }
            else
            {
                for (i = 0; i < neuronioSaida; i++)
                {
                    obtido = (double)(Math.Round((1 - Math.Round(Math.Exp(-2 * netSaida[i]), 8)) / (1 + Math.Round(Math.Exp(-2 * netSaida[i]), 8)), 8));
                    if (Double.IsNaN(obtido))
                        obtido = (netSaida[i] > 0) ? (double)1 : (double)-1;
                    sCamadaSaida[i] = (double)(obtido);
                }
            }
        }

        private void calErros()
        {
            if (rbLinear.Checked)
            {
                erroFunLinear("");//camada de saída
                erroFunLinear("ocu");//camada oculta
            }
            else
            {
                if (rbLogistica.Checked)
                {
                    erroFunLogistica("");//camada de saida
                    erroFunLogistica("ocu");//camada oculta
                }
                else
                {
                    erroFunTgHiberbolica("");//camada de saida
                    erroFunTgHiberbolica("ocu");//camada oculta
                }
            }
        }

        private void calErroRede()
        {
            Double Erros = 0;

            for (int i = 0; i < neuronioSaida; i++)
                Erros += (double)(Math.Round(Math.Pow(eCamadaSaida[i], 2), 8));
         
            erroRede = (double)(Math.Round((0.5 * Erros), 8));
        }

        private void erroFunLinear(string camada)
        {
            int i, j;
            double Erros;

            if (camada.Equals("ocu"))
            {
                i = 0;
                for (i = 0; i < cOculta; i++)  
                {
                    Erros = 0;
                    for (j = 0; j < neuronioSaida; j++)
                        Erros += Math.Round(eCamadaSaida[j] * pCamadaSaida[i][j], 8);

                    eCamadaOculta[i] = Math.Round(Erros * 0.2, 8);
                }
            }
            else
                for (i = 0; i < neuronioSaida; i++)
                    eCamadaSaida[i] = (double)(Math.Round(((sDesejada[i] - sCamadaSaida[i]) * 0.2), 8));
            
        }

        private void erroFunLogistica(string camada)
        {
            int i, j;
            double somatorioErros;

            if (camada.Equals("ocu"))
            {
                for (i = 0; i < cOculta; i++)
                {
                    somatorioErros = 0;
                    for (j = 0; j < neuronioSaida; j++)
                        somatorioErros += Math.Round(eCamadaSaida[j] * pCamadaSaida[i][j], 8);

                    eCamadaOculta[i] = Math.Round(somatorioErros * (sCamadaOculta[i] * (1 - sCamadaOculta[i])), 8);
                }
            }
            else
                for (i = 0; i < neuronioSaida; i++)
                    eCamadaSaida[i] = (double)(Math.Round(((sDesejada[i] - sCamadaSaida[i]) * (sCamadaSaida[i] * (1 - sCamadaSaida[i]))), 8));
        }

        private void erroFunTgHiberbolica(string camada)
        {
            double sumErros;

            if (camada.Equals("ocu"))
            {
                for (int i = 0; i < cOculta; i++)
                {
                    sumErros = 0;
                    for (int j = 0; j < neuronioSaida; j++)
                        sumErros += Math.Round(eCamadaSaida[j] * pCamadaSaida[i][j], 8);

                    eCamadaOculta[i] = Math.Round(sumErros * (1 - Math.Round(Math.Pow(sCamadaOculta[i], 2), 4)), 8);

                }

            }
            else
                for (int i = 0; i < neuronioSaida; i++)
                   eCamadaSaida[i] = (double)(Math.Round((Math.Round((sDesejada[i] - sCamadaSaida[i]), 8) * (1 - Math.Round(Math.Pow(sCamadaSaida[i], 2), 8))), 8));
        }

        #endregion;

        #region CARREGAR MATRIZ
        private void carregarMatrizLinhas()
        {
            dgvMatriz.ColumnCount = 1;
            dgvMatriz.Columns[0].Width = 63;


            for (int i = 0; i < neuronioSaida; i++)
            {
                dgvMatriz.RowCount += 1;
                dgvMatriz.Rows[i].Cells[0].Value = classes.ElementAt(i);
                dgvMatriz.Rows[i].Cells[0].Style = dgvMatriz.ColumnHeadersDefaultCellStyle;
            }
        }

        private void carregarMatrizColunas()
        {
            for (int i = 0; i < neuronioSaida; i++)
            {
                dgvMatriz.ColumnCount += 1;
                dgvMatriz.Columns[i + 1].Name = classes.ElementAt(i);
                dgvMatriz.Columns[i + 1].Width = 63;
                dgvMatriz.Columns[i].Width = 63;

                for (int j = 0; j < neuronioSaida; j++)
                {
                    dgvMatriz.Rows[j].Cells[i + 1].Value = resultado[j][i].ToString();
                }
            }
        }
        #endregion;
    }
 
}
