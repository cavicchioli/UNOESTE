package infoeste.lista;

import android.app.Activity;
import android.app.ListActivity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.*;

public class ActPrincipal extends ListActivity {
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.main);
        
        String[] strOperacoes= new String[] {"Ligar (Telefone)","Navegar","Ver Mapa","Sair"};
        
        ArrayAdapter adp = new ArrayAdapter(ActPrincipal.this, android.R.layout.simple_list_item_1, strOperacoes);
        
        setListAdapter(adp);
        
        ListView lv = this.getListView();
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {

			public void onItemClick(AdapterView<?> arg0, View arg1, int posicao,
					long arg3) {
				Log.i("infoeste", "Posicao: " + String.valueOf(posicao));
				
				switch(posicao){
				
				case 0:{
					Uri uri = Uri.parse("tel:32291060");
					Intent it = new Intent(Intent.ACTION_CALL, uri);
					startActivity(it);
					break;}//ligar telefone
				
				case 1:{
					Uri uriSite = Uri.parse("http://www.google.com/");
					Intent it = new Intent(Intent.ACTION_VIEW,uriSite);
					startActivity(it);
					break;}//navegar
				
				case 2:{
					Uri uriMapa = Uri.parse("geo:0,0?q=Rua+Hipolito+Jose+da+Costa+236,Presidente+Prudente");
					Intent it = new Intent(Intent.ACTION_VIEW,uriMapa);
					startActivity(it);
					break;}//ver mapa
				
				case 3:{
							
					Intent it = new Intent(Intent.ACTION_SEND,null);
					it.addCategory(it.CATEGORY_DEFAULT);
					it.setType("text/plain");
					it.putExtra(it.EXTRA_TEXT, "corpo da sms que vai ser digitada;");
					startActivity(it);
					//finish();
						break;}//sair
				}
			}
		});//aqui a acaba a implemetação do evento do clik na lista...<<<
        
        
    }
}