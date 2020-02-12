package es.iesnervion.avazquez.enciclopedia;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    TextView informacion;
    ImageView imagen;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        imagen = findViewById(R.id.imagenGrande);
        informacion = findViewById(R.id.txtInformacion);

    }


    public void mostrarDatos(View v){
        TextView elementoActual;
        switch (v.getId()){
            case R.id.elemento1:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento1);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infoOnePiece);
                imagen.setImageResource(R.drawable.onepiece);

                break;
            case R.id.elemento2:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento2);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infoBokuNoHero);
                imagen.setImageResource(R.drawable.bokunohero);
                break;
            case R.id.elemento3:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento3);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infohunterxhunter);
                imagen.setImageResource(R.drawable.hunterxhunter);
                break;
            case R.id.elemento4:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento4);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infonaruto);
                imagen.setImageResource(R.drawable.naruto);
                break;
            case R.id.elemento5:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento5);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infobokudake);
                imagen.setImageResource(R.drawable.bokudake);
                break;
            case R.id.elemento6:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento6);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.drstone);
                imagen.setImageResource(R.drawable.drstone);
                break;
            case R.id.elemento7:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento7);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infoshokugeki);
                imagen.setImageResource(R.drawable.shokugeki);
                break;
            case R.id.elemento8:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento8);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infokimetsu);
                imagen.setImageResource(R.drawable.kimetsu);
                break;
            case R.id.elemento9:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento9);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infoansatsu);
                imagen.setImageResource(R.drawable.ansatsu);
                break;
            case R.id.elemento10:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento10);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.infoyakusoku);
                imagen.setImageResource(R.drawable.yakusoku);
                break;
            case R.id.elemento11:
                apagarResaltado();
                elementoActual = findViewById(R.id.elemento11);
                elementoActual.setBackgroundColor(Color.parseColor("#48070707"));
                informacion.setText(R.string.inforokka);
                imagen.setImageResource(R.drawable.rokka);
                break;


        }
    }

    public void apagarResaltado(){
        ArrayList<TextView> elementos = new ArrayList<>();
        elementos.add((TextView) findViewById(R.id.elemento1));
        elementos.add((TextView) findViewById(R.id.elemento2));
        elementos.add((TextView) findViewById(R.id.elemento3));
        elementos.add((TextView) findViewById(R.id.elemento4));
        elementos.add((TextView) findViewById(R.id.elemento5));
        elementos.add((TextView) findViewById(R.id.elemento6));
        elementos.add((TextView) findViewById(R.id.elemento7));
        elementos.add((TextView) findViewById(R.id.elemento8));
        elementos.add((TextView) findViewById(R.id.elemento9));
        elementos.add((TextView) findViewById(R.id.elemento10));
        elementos.add((TextView) findViewById(R.id.elemento11));

        for (TextView element: elementos) {
            element.setBackgroundColor(Color.TRANSPARENT);
        }
    }

}

