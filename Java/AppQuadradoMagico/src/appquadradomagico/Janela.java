package appquadradomagico;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.*;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

public class Janela extends JFrame
{
    private JPanel pTabuleiro = new JPanel();
    private JButton bTab[][] = new JButton[3][3];
    private JButton bNovoJogo, bFim, bAux;
    
    public Janela()
    {
        this.setSize(300,340);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setResizable(false);
        getContentPane().setLayout(new BorderLayout());
        
        pTabuleiro.setLayout(new GridLayout(3,3));
        pTabuleiro.setBackground(Color.black);
        getContentPane().add("Center", pTabuleiro);
        
        JPanel pComandos = new JPanel();
        pComandos.setLayout(new FlowLayout());
        pComandos.setBackground(Color.black);
        bNovoJogo = new JButton("Novo Jogo");
        bFim = new JButton ("FIm");
        pComandos.add(bNovoJogo);
        pComandos.add(bFim);
        getContentPane().add("South", pComandos);
        
        bFim.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                dispose();
            }
        });
        
        bNovoJogo.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                carregaMatrizBotoes();
                paintAll(getGraphics());
            }
        });
        
        carregaMatrizBotoes();
    }
    
    private int devolveNumero(boolean[] vJaSaiu)
    {
        int num = -1;
        boolean ok = true;
        while (ok)
        {
            num = (int)Math.round(Math.random()*10);
            if (num < 9 && vJaSaiu[num] == false)
            {
                vJaSaiu[num] = true;
                ok = false;
            }
        }
        return num;
    }
    
    @SuppressWarnings("empty-statement")
    private void carregaMatrizBotoes()
    {
        boolean vJaSaiu[] = {false,false,false,false,false,false,false,false,false};
        int posicao = 0;
        if (pTabuleiro.getComponentCount() > 0)
                    pTabuleiro.removeAll();
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                int num = devolveNumero(vJaSaiu);
                if (num != 0)
                {
                    bTab[i][j] = new JButton(String.valueOf(num));
                    bTab[i][j].setFont(new Font("Verdana",1,50)); 
                    bTab[i][j].addActionListener(new ActionListener()
                    {
                        public void actionPerformed(ActionEvent e)
                        {
                            //posicao[0] linha
                            //posicao[1] coluna
                            //posicao[2] posicaoGeral
                            int posicao[] = encontraPosicao(e.getSource());
                            boolean mecheu = false;
                            //direita
                            if (posicao[1] < 2 && bTab[posicao[0]][(posicao[1]+1)] == null)
                            {
                                Object aux = pTabuleiro.getComponent(posicao[2]);
                                pTabuleiro.add(pTabuleiro.getComponent(posicao[2]+1), posicao[2]);
                                pTabuleiro.add((JButton)aux, posicao[2]+1);

                                bTab[posicao[0]][(posicao[1]+1)] = bTab[posicao[0]][posicao[1]];
                                bTab[posicao[0]][posicao[1]] = null;

                                mecheu = true;
                            }
                            //esquerda
                            else if (posicao[1] > 0 && bTab[posicao[0]][(posicao[1]-1)] == null)
                            {
                                Object aux = pTabuleiro.getComponent(posicao[2]);
                                pTabuleiro.add(pTabuleiro.getComponent(posicao[2]-1), posicao[2]);
                                pTabuleiro.add((JButton)aux, posicao[2]-1);

                                bTab[posicao[0]][(posicao[1]-1)] = bTab[posicao[0]][posicao[1]];
                                bTab[posicao[0]][posicao[1]] = null;

                                mecheu = true;
                            }
                            //acima
                            else if (posicao[0] > 0 && bTab[(posicao[0]-1)][posicao[1]] == null)
                            {
                                Object aux = pTabuleiro.getComponent(posicao[2]);
                                pTabuleiro.add(pTabuleiro.getComponent(posicao[2]-3), posicao[2]);
                                pTabuleiro.add((JButton)aux, posicao[2]-3);

                                bTab[(posicao[0]-1)][posicao[1]] = bTab[posicao[0]][posicao[1]];
                                bTab[posicao[0]][posicao[1]] = null;

                                mecheu = true;
                            }
                            //abaixo
                            else if (posicao[0] < 2 && bTab[(posicao[0]+1)][posicao[1]] == null)
                            {
                                Object aux = pTabuleiro.getComponent(posicao[2]);
                                pTabuleiro.add(pTabuleiro.getComponent(posicao[2]+3), posicao[2]);
                                pTabuleiro.add((JButton)aux, posicao[2]+3);

                                bTab[(posicao[0]+1)][posicao[1]] = bTab[posicao[0]][posicao[1]];
                                bTab[posicao[0]][posicao[1]] = null;

                                mecheu = true;
                            }
                            
                            if (mecheu)
                            {
                                paintAll(getGraphics()); 
                                if (Correto())
                                {
                                    JOptionPane.showMessageDialog(null, "PARABÉNS VOCÊ VENCEU!!!");
                                }
                            }
                        }
                    });
                    pTabuleiro.add(bTab[i][j], posicao++);
                }
                else
                {
                    bTab[i][j] = null;
                    JPanel pan = new JPanel();
                    pan.setBackground(Color.black);
                    pTabuleiro.add(pan, posicao++);
                }
            }
        }
    }
    
    private int[] encontraPosicao(Object botaoClicado)
    {
        int linha = 0, coluna = 0, posicaoGeral = 0;
        boolean procura = true;
        for (int l = 0; l < 3 && procura; l++) 
        {
            for (int c = 0; c < 3 && procura; c++) 
            {
                posicaoGeral++;
                if (bTab[l][c] == botaoClicado)
                {
                    linha = l;
                    coluna = c;
                    procura = false;
                }
            }
        }
        return new int[]{linha, coluna, posicaoGeral-1};
    }
    
    private boolean Correto()
    {
        Integer sequencia = 1;
        boolean ok = true;
        for(int i = 0; i < 3 && ok; i++)
        {
            for(int j = 0; j < 3 && ok; j++)
            {
                if ((i != 3 && j != 3) && bTab[i][j] != null && !((JButton)bTab[i][j]).getText().equals(sequencia.toString()))
                    ok = false;
                sequencia += 1;
            }
        }
        
        return ok;
    }
    
}
