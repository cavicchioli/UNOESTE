
package appheranca;

import java.util.ArrayList;

public class AppHeranca {

    public static void main(String[] args) 
    {
        //Aula 03/09
       ArrayList <Funcionario> equipe;//casting so permite esse tipo de objeto
       equipe = new ArrayList();
       
        equipe.add(new Funcionario("Jose de Lima",1234,10,40));
        Funcionario f =  new Funcionario("Catarina Melo",1234,8,40);
        equipe.add(f);
        equipe.add(new Gerente("Cloadoaaldo ", 3512,40,41,50));
        equipe.add(new Supervisor("Mariazinha ", 3512,40,41,50,10));
          
        //versao for each
        System.out.println("\nVERSAO EACH");
        for(Funcionario func:equipe)
          {
              System.out.print("\n"+func.getDados());
               if(func instanceof Gerente)
                    System.out.print("Adicional de " +((Gerente)func).getadicGerente());
                            
          }
        
          System.out.println("\nVERSAO NORMAL");
          for(int i=0; i<equipe.size();i++)
          {
              Funcionario func = /*(Funcionario*/equipe.get(i); //nao precisa mais desse casting
              
              System.out.print("\n"+func.getDados());
               if(func instanceof Gerente)
                    System.out.print("Adicional de " +((Gerente)func).getadicGerente());
                            
          }
          
          
          // outros metodos interessantes do arraylist
          if(equipe.contains(f))
              System.out.print(f.getDados() +"ja existe");
          equipe.remove(f); // remove o objeto f da arraylist
          // recupera todos os objetos inseridos no arrylist
          // retornando um vetor com todos
          
          Funcionario vequipe[];
          vequipe=new Funcionario[equipe.size()];
          equipe.toArray(vequipe);
          for(int i=0;i<vequipe.length;i++)
              System.out.println(vequipe[i].getDados());
          
          equipe.clear(); // apago todos os elementos
          
          // termino da aula 03/09
       int tl=0;
       
       //Gerente g;
     //  g= new Gerente("Cloadoaaldo ", 3512,40,41,50);
     //  new Gerente("Cloadoaaldo ", 3512,40,41,50);
      // System.out.println(g.getDados());
       /*
       Funcionario equipe[];
       equipe = new Funcionario[10];
       
       equipe[tl++] = new Funcionario("Jose de Lima",1234,10,40);
        equipe[tl++] = new Funcionario("Catarina Melo",1234,8,40);
         equipe[tl++] = new Gerente("Cloadoaaldo ", 3512,40,41,50);
          equipe[tl++] = new Supervisor("Cloadoaaldo ", 3512,40,41,50,10);
       
       for(int i=0; i<tl; i++)
       {
         System.out.print("\n"+equipe[i].getDados());
         if(equipe[i] instanceof Gerente)
             System.out.println("Adicional de " +((Gerente)equipe[i]).getadicGerente()+"%");
         
        // System.out.println(equipe[i].getadicGerente()) PAra funcionar tem que perguntar de equipe´[i] é funcuionar ou gernete
          */
      // }
       
       
    }
}
