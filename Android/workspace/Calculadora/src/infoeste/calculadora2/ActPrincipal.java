package infoeste.calculadora2;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.*;

public class ActPrincipal extends Activity {
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        setTitle("Super Calculadora");
        
        final EditText eNum1;
        eNum1 = (EditText) findViewById(R.id.eNum1);
        eNum1.setText("10");
        
        final EditText eNum2 =(EditText) findViewById(R.id.eNum2);
        eNum2.setText("20");
        
        
        
        final EditText eResultado = (EditText) findViewById(R.id.eResultado);
        
        
        Button ttnCalcular = (Button) findViewById(R.id.ttnCalcular); //btnCalcular
        
        //evento do botão
        ttnCalcular.setOnClickListener(new View.OnClickListener() 
        {
			
			public void onClick(View v) {
				// TODO Auto-generated method stub
				//metodo a ser executado quando o botão é clicado
				
				try{
					int num1 = Integer.parseInt(eNum1.getText().toString());
			        int num2 = Integer.parseInt(eNum2.getText().toString());
			        
			        int resultado = num1+num2;
			        
			        eResultado.setText(String.valueOf(resultado));
			        
			        //Exibir mensagem na tela
			        Toast.makeText(ActPrincipal.this, "Resultado: " + String.valueOf(resultado) , Toast.LENGTH_SHORT).show();
			        
				   }catch(Exception ex){
					   
					   AlertDialog.Builder j= new AlertDialog.Builder(ActPrincipal.this);//ou ActPrincipal.this
					   j.setTitle("Erro");
					   j.setMessage("Ocorreu um erro." + "\n\nDeseja sair??");
					   
					   j.setPositiveButton("Sim", new  DialogInterface.OnClickListener() {
						
						public void onClick(DialogInterface dialog, int which) 
						{
							finish();
							// TODO Auto-generated method stub
							
						}
					});
					   
					   j.setNegativeButton("Não", new DialogInterface.OnClickListener() {
						
						public void onClick(DialogInterface dialog, int which) {
							// TODO Auto-generated method stub
							
						}
					});
					   
					   j.show();
					   Log.e("infoeste", "Erro: "+ ex.getMessage());
					 
					   
					   //Toast.makeText(ActPrincipal.this, "Erro:" + String.valueOf(ex.getMessage()) , Toast.LENGTH_SHORT).show();
				   }
			}
		});
        
        
    }
}