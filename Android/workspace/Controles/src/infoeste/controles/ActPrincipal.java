package infoeste.controles;

import android.app.Activity;
import android.content.Intent;
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
        
        final CheckBox cbLigado = (CheckBox) findViewById(R.id.cbLigado);
        final SeekBar sbProgresso = (SeekBar) findViewById(R.id.sbProgresso);
        Button btnTela2 = (Button) findViewById(R.id.btnTela2);
        
        btnTela2.setOnClickListener(new View.OnClickListener() {
			
			public void onClick(View v) {
				
				Intent it = new Intent(ActPrincipal.this, ActTela2.class);
				//cria uma classe de intenção, ou seja... chamar tela, ligar gps... etc etc
				
				it.putExtra("par_progresso", sbProgresso.getProgress());
				it.putExtra("par_ligado", cbLigado.isChecked());
				
				startActivity(it);//manda para o sistema a intenção;
				
				
			}
		});//aqui termina o controile do botão.
        
        cbLigado.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
			
			public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
				if(isChecked)
					Log.i("infoeste", "Marcado");
				else
					Log.i("infoeste", "Desmarcado");	
			}
		});//terminou o clike do checkbox aqui<<<<
        
        
        sbProgresso.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
			
			public void onStopTrackingTouch(SeekBar seekBar) {
				
				
			}
			
			public void onStartTrackingTouch(SeekBar seekBar) {
				
				
			}
			
			public void onProgressChanged(SeekBar seekBar, int progress,
					boolean fromUser) {
				Log.i("Infoeste", "Progresso" + String.valueOf(progress));
				
				
			}
		}); //aqui acaba os controles do evento do seekbar;<<<<
    }
}