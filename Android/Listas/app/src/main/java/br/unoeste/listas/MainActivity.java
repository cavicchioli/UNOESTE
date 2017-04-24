package br.unoeste.listas;

import android.content.Intent;
import android.net.Uri;
import android.provider.Telephony;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.text.Layout;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;


public class MainActivity extends ActionBarActivity {

    List<String> colecao;
    ArrayAdapter<String> adaptador;
    ListView lvOpcoes;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        lvOpcoes = (ListView)findViewById(R.id.lvOpcoes);


        colecao =  new ArrayList<String>();

        colecao.add("Navegar na Internet");
        colecao.add("Fazer uma Ligação");
        colecao.add("Sobre");
        colecao.add("Sair");

/*
        for (int i=0;i<100;i++)
            colecao.add("Opção "+i+":");
*/
        adaptador = new ArrayAdapter<String>(MainActivity.this,android.R.layout.simple_list_item_1,colecao);

        lvOpcoes.setAdapter(adaptador);

        lvOpcoes.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                switch (position) {
                    case 0:
                        navegarInternet();
                        break;
                    case 1:
                        ligarUnoeste();
                        break;
                    case 2:
                        abrirSobre();
                        break;
                    case 3:
                        finish();
                        break;
                }
            }
        });

    }

    private void abrirSobre() {

        Intent itAbrirSobre = new Intent(MainActivity.this, ActSobre.class);
        //Intent itLigar = new Intent(Intent.ACTION_DIAL, number);
        startActivity(itAbrirSobre);
    }

    private void ligarUnoeste() {

        Uri number = Uri.parse("tel:0151832291060");
        Intent itLigar = new Intent(Intent.ACTION_CALL, number);
        //Intent itLigar = new Intent(Intent.ACTION_DIAL, number);
        startActivity(itLigar);
    }

    private void navegarInternet() {
        Uri uri = Uri.parse("http://www.unoeste.br");
        Intent itNavegar = new Intent(Intent.ACTION_VIEW, uri);
        startActivity(itNavegar);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
