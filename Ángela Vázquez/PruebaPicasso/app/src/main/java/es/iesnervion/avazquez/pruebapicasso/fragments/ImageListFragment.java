package es.iesnervion.avazquez.pruebapicasso.fragments;

import android.os.Bundle;
import android.provider.ContactsContract;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import java.util.ArrayList;
import java.util.Arrays;

import es.iesnervion.avazquez.pruebapicasso.R;
import es.iesnervion.avazquez.pruebapicasso.adapter.ImageAdapter;
import es.iesnervion.avazquez.pruebapicasso.viewModel.SharedViewModel;

public class ImageListFragment extends Fragment {

    SharedViewModel viewModel;
    ListView listView;


    public ImageListFragment() {
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.image_list, container, false);
        viewModel = ViewModelProviders.of(getActivity()).get(SharedViewModel.class);

        listView = view.findViewById(R.id.listViewImagenes);

        ArrayList<String> listaURLs = viewModel.getListaURLs().getValue();
        if(listaURLs == null){
            listaURLs = new ArrayList<>();
            listaURLs.add("https://love2dev.com/img/error-message-laptop-1920x1297.jpg");
        }

        ImageAdapter adapter = new ImageAdapter(listaURLs, getActivity().getBaseContext());
        listView.setAdapter(adapter);
        return view;
    }
}
