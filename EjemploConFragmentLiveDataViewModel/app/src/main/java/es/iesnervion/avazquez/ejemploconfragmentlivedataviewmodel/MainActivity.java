package es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;

import android.content.res.Configuration;
import android.os.Bundle;

import java.lang.reflect.Array;
import java.util.ArrayList;

import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.entities.ContactImpl;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.fragments.DetailFragment;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.fragments.MasterFragment;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.interfaces.Contact;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.viewModel.SharedVM;

public class MainActivity extends AppCompatActivity {


    Fragment master;
    Fragment details;
    SharedVM viewModel;
    int orientacion;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        viewModel = ViewModelProviders.of(this).get(SharedVM.class);


        master = new MasterFragment();
        details = new DetailFragment();

        FragmentManager fm = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fm.beginTransaction();
        orientacion = getResources().getConfiguration().orientation;


        if(orientacion == Configuration.ORIENTATION_PORTRAIT){

            //Si estoy en modo portrait solo tengo un hueco pa un fragment
            //y su id es "fragment" en el XML
            fragmentTransaction.replace(R.id.fragment, master);

            //Aqui no debo poner .addToBackStack porque si lo pongo en el primer fragment, al darle para atras
            //como que se queda el layout base de la actividad


            /*El observer*/
            final Observer<ContactImpl> contactObserver = new Observer<ContactImpl>() {
                @Override
                public void onChanged(ContactImpl contact) {

                    /*Esto no funcionaba con un solo Fragment transaction, tengo que crear
                    * un Fragment transaction nuevo cada vez que me meto en el on click / on change
                    * lo malo de esto es que creo que getSupportFragmentManager esta deprecated ??
                    * nose, preguntar a miguelahe
                    * */
                    FragmentTransaction ft = getSupportFragmentManager().beginTransaction();

                    ft.replace(R.id.fragment, details).addToBackStack(null).commit();

                }
            };

            //Observo el LiveData con ese observer que acabo de crear
            viewModel.getContactoSeleccionado().observe(this, contactObserver);





        }else if(orientacion == Configuration.ORIENTATION_LANDSCAPE){
            //Si estoy en modo landscape tengo dos huecos, masterFragment y
            //detailsFragment

            fragmentTransaction.replace(R.id.masterFragment, master);

            fragmentTransaction.replace(R.id.detailsFragment, details);


        }

        fragmentTransaction.commit();

    }
}
