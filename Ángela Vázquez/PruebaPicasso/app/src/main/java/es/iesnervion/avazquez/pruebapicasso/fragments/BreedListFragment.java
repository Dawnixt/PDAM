package es.iesnervion.avazquez.pruebapicasso.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

import es.iesnervion.avazquez.pruebapicasso.R;
import es.iesnervion.avazquez.pruebapicasso.viewModel.SharedViewModel;

public class BreedListFragment extends Fragment implements AdapterView.OnItemClickListener {

    SharedViewModel viewModel;
    ListView listView;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_breed_list, container, false);
        ArrayList<String> razasPerro = new ArrayList<>();
        razasPerro.add("akita");
        razasPerro.add("malamute");
        razasPerro.add("husky");
        razasPerro.add("labrador");
        razasPerro.add("beagle");
        razasPerro.add("boxer");
        razasPerro.add("bulldog");
        razasPerro.add("chihuahua");
        razasPerro.add("corgi");
        razasPerro.add("dalmatian");
        razasPerro.add("doberman");
        razasPerro.add("hound");
        razasPerro.add("kelpie");
        razasPerro.add("pitbull");

        Collections.sort(razasPerro);
        viewModel = ViewModelProviders.of(getActivity()).get(SharedViewModel.class);
        listView = view.findViewById(R.id.listViewRazas);
        ArrayAdapter<String> adapter =
                    new ArrayAdapter<>(getContext(), android.R.layout.simple_list_item_1, razasPerro);
        listView.setAdapter(adapter);

        listView.setOnItemClickListener(this);


        return view;
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        /*Cuando un elemento se clicka, pongo ese elemento
        * como raza seleccionada en el VM*/
        String razaElegida = "";
        //Cojo la raza elegida
        if(position >= 0){
            razaElegida = (String) listView.getItemAtPosition(position);
        }


        //Le digo al view model que este es el contacto seleccionado
        viewModel.setRazaElegida(razaElegida);
    }
}
