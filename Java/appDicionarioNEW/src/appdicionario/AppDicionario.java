package appdicionario;

import javax.swing.JOptionPane;

public class AppDicionario 
{

    public static void main(String[] args) 
    {  Dicionario dic;
       Termo vet[];
       
       //dic=new Dicionario(10);
       dic=new Dicionario();
       
       
      
          //MENU
       
          int opcao;
          String port,ingl,palavra,def;
          
          do{
             opcao=Integer.parseInt(JOptionPane.showInputDialog("-------------------------------------\n1: Abrir Dicionário\n2: Cadastrar termo\n3: Pesquisar\n4: Total Cadrastrado\n5: Salva\n6: Finalizar\n7: Copiar\n-------------------------------------\n"));
          
             switch(opcao){
                 case 1:{ 
                         dic.LoadFromFile("D:\\dic.dad");
                         JOptionPane.showMessageDialog(null,"Dicionário Carregado!!");break;
                        }
                 case 2:{
                            port=JOptionPane.showInputDialog("Digite uma palavra em português!");
                            ingl=JOptionPane.showInputDialog("Digite a tradução da palavra em Ingles!");
                            def=JOptionPane.showInputDialog("Digite a Definição!");
                            
                            if(dic.addTerm(port,ingl,def));
                                JOptionPane.showMessageDialog(null,"OK, Cadastrado");  
                        }break;
                 case 3:{
                            palavra=JOptionPane.showInputDialog("Digite a palavra a ser pesquisada!");
          
                            if(dic.contains(palavra))
                                JOptionPane.showMessageDialog(null,dic.translate(palavra));
                               else
                                JOptionPane.showMessageDialog(null,"Palavra não Encontrada"); }break;
                 case 4:{
                            JOptionPane.showMessageDialog(null,"Quantidade de termos cadastrados: "+dic.getTotal());} break;
                 case 5:{ 
                         dic.SaveToFile("D:\\dic.dad");
                         JOptionPane.showMessageDialog(null,"Dicionário Savo!!");break;
                        }
                 case 6: JOptionPane.showMessageDialog(null,"Aplicativo Fechado!");break;
                 case 7: {
                           vet=dic.getTermos();
                           //vet[0]=null;
                           
                            JOptionPane.showMessageDialog(null, dic.todosTermos(vet));
                         };break;
                 default: JOptionPane.showMessageDialog(null,"Opção Inválida!");
                 
             }
                 
          }while(opcao!=6);
          
          
          
    }
}


 


 