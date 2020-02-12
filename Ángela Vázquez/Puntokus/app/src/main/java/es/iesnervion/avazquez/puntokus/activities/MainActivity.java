package es.iesnervion.avazquez.puntokus.activities;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.lifecycle.ViewModelProviders;

import android.os.Bundle;
import android.util.Log;

import es.iesnervion.avazquez.puntokus.R;
import es.iesnervion.avazquez.puntokus.fragments.LoginFragment;
import es.iesnervion.avazquez.puntokus.fragments.RegistrarseFragment;
import es.iesnervion.avazquez.puntokus.viewModels.ViewModelRegistro;

public class MainActivity extends AppCompatActivity {

    Fragment login;
    Fragment registro;
    ViewModelRegistro viewModel;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        login = new LoginFragment();
        registro = new RegistrarseFragment();
        viewModel = ViewModelProviders.of(this).get(ViewModelRegistro.class);
        FragmentManager fm = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fm.beginTransaction();

        fragmentTransaction.replace(R.id.fragment, login).commit();

    }
}
