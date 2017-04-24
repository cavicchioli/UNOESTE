package br.unoeste.calculadora;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;


public class MainActivity extends ActionBarActivity {

    private EditText edtNum1, edtNum2;
    private Button btnCalcular;
    private TextView tvResultado;
    private SeekBar skBarra;
    private CheckBox cbMostrarProgresso;

    private static final String TAG = "FIPP";

    public void calcular(View v)
    {
        try
        {
            int num1 = Integer.parseInt(edtNum1.getText().toString());
            int num2 = Integer.parseInt(edtNum2.getText().toString());
            int res = num1 + num2;

            tvResultado.setText(String.valueOf(res));
        }
        catch (Exception e)
        {
            AlertDialog.Builder janela = new AlertDialog.Builder(MainActivity.this);
            janela.setTitle("ERRO");
            janela.setTitle("Verifique os dados informados. \n\n Deseja Sair?");

            janela.setPositiveButton("SIM", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {

                }
            });

            janela.setNegativeButton("Não",null);
            janela.show();

            //Toast.makeText(this, "Verifique os dados:" + e.getMessage(),Toast.LENGTH_SHORT).show();
            Log.e(TAG,"ERRO:"+ e.getMessage());
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        edtNum1 = (EditText)findViewById(R.id.edtNum1);
        edtNum2 = (EditText)findViewById(R.id.edtNum2);
        btnCalcular = (Button)findViewById(R.id.btnCalcular);
        tvResultado = (TextView)findViewById(R.id.tvResultado);
        skBarra = (SeekBar)findViewById(R.id.skBarra);
        cbMostrarProgresso = (CheckBox)findViewById(R.id.cbMostrarProgresso);
        tvResultado.setVisibility(View.INVISIBLE);


        skBarra.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                tvResultado.setText(String.valueOf(progress));
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });

        cbMostrarProgresso.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

                if(isChecked)
                    tvResultado.setVisibility(View.VISIBLE);
                else
                    tvResultado.setVisibility(View.INVISIBLE);
            }
        });
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
