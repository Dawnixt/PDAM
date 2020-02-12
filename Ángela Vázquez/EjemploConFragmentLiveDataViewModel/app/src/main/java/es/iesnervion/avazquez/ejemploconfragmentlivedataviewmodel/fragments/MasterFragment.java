package es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;

import java.util.ArrayList;

import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.R;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.adapter.ContactAdapter;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.entities.ContactImpl;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.viewModel.SharedVM;

public class MasterFragment extends Fragment
implements AdapterView.OnItemClickListener
{

    SharedVM viewModel;
    ListView listView;


    public MasterFragment() {
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.masterlayout, container, false);
        viewModel = ViewModelProviders.of(getActivity()).get(SharedVM.class);
        
        //ListView
        listView = view.findViewById(R.id.listViewContactos);

        //Adapter
        final ContactAdapter contactAdapter = new ContactAdapter(getActivity().getBaseContext(), viewModel.getContactList().getValue());
        listView.setAdapter(contactAdapter);

        //El observer de la lista
        final Observer<ArrayList<ContactImpl>> listContactObserver = new Observer<ArrayList<ContactImpl>>() {
            @Override
            public void onChanged(ArrayList<ContactImpl> listContact) {
                //Actualizar la UI
                listView.setAdapter(contactAdapter);
            }
        };

        //Observo el LiveData con ese observer que acabo de crear
        viewModel.getContactList().observe(this, listContactObserver);


        listView.setOnItemClickListener(this);

        return view;
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        //Cuando un elemento se clicka, pongo ese elemento como
        //contacto seleccionado en el view model
        ContactImpl contactoSeleccionado = null;
        //Cojo el contacto seleccionado
        if(position >= 0){
            contactoSeleccionado = viewModel.getContactList().getValue().get(position);
        }


        //Le digo al view model que este es el contacto seleccionado
        viewModel.setContactoSeleccionado(contactoSeleccionado);

    }
}
