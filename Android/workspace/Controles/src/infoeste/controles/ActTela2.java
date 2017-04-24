package infoeste.controles;

import android.app.Activity;
import android.os.Bundle;
import android.widget.*;

public class ActTela2 extends Activity {
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tela2);
        
        TextView textView1 = (TextView) findViewById(R.id.textView1);
        
        int progresso = this.getIntent().getIntExtra("par_progresso", 0);
        
        boolean ligado  = this.getIntent().getBooleanExtra("par_ligado", false);
        
        String resultado = "Progresso: "+ String.valueOf(progresso)+"\n\n" 
        + "Ligado: " + String.valueOf(ligado);
        
        textView1.setText(resultado);
       
        
    }
}