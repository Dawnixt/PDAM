package es.iesnervion.avazquez.pruebapicasso.activities;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.ListView;

import com.squareup.picasso.Picasso;

import java.util.ArrayList;

import es.iesnervion.avazquez.pruebapicasso.R;
import es.iesnervion.avazquez.pruebapicasso.adapter.ImageAdapter;
import es.iesnervion.avazquez.pruebapicasso.fragments.BreedListFragment;
import es.iesnervion.avazquez.pruebapicasso.fragments.ImageListFragment;
import es.iesnervion.avazquez.pruebapicasso.viewModel.SharedViewModel;

public class MainActivity extends AppCompatActivity {

    Fragment listadoRazas;
    Fragment listadoImagenes;
    SharedViewModel viewModel;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        viewModel = ViewModelProviders.of(this).get(SharedViewModel.class);

        listadoRazas = new BreedListFragment();
        listadoImagenes = new ImageListFragment();

        FragmentManager fm = getSupportFragmentManager();
        FragmentTransaction ft = fm.beginTransaction();

        ft.replace(R.id.fragment, listadoRazas);
        ft.commit();


        /*El observer*/
        final Observer<Boolean> isCargadaObserver = new Observer<Boolean>() {
            @Override
            public void onChanged(Boolean isCargada) {
                FragmentTransaction ft2 = getSupportFragmentManager().beginTransaction();
                if(viewModel.isCargada().getValue()){
                    ft2.replace(R.id.fragment, listadoImagenes).addToBackStack(null).commit();
                    viewModel.setIsCargada(false);
                }


            }
        };
        //Observo el LiveData con ese observer que acabo de crear
        viewModel.isCargada().observe(this, isCargadaObserver);


//        /*El observer*/
//        final Observer<String> razaObserver = new Observer<String>() {
//            @Override
//            public void onChanged(String razaElegida) {
//                FragmentTransaction ft2 = getSupportFragmentManager().beginTransaction();
//                ft2.replace(R.id.fragment, listadoImagenes).addToBackStack(null).commit();
//
//            }
//        };
//        //Observo el LiveData con ese observer que acabo de crear
//        viewModel.getRazaElegida().observe(this, razaObserver);

    }
}
