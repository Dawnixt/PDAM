package es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;

import de.hdodenhof.circleimageview.CircleImageView;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.R;

import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.entities.ContactImpl;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.viewModel.SharedVM;

public class DetailFragment extends Fragment {
    SharedVM viewModel;

    TextView nombreCompleto;
    TextView fechaNacimiento;
    TextView bio;
    CircleImageView foto;
    ImageView isFavorito;

    public DetailFragment() {
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.detailslayout, container, false);

        /*Aqui es getActivity porque si no lo que haces
        * es como crear un view model nuevo para "this" (este fragment)
        * y lo que queremos es que nos de el de la actividad
        * */
        viewModel = ViewModelProviders.of(getActivity()).get(SharedVM.class);


        //hago los vinculos entre el java y el xml
        foto = view.findViewById(R.id.imgContacto);
        nombreCompleto = view.findViewById(R.id.txtViewNombreCompleto);
        fechaNacimiento = view.findViewById(R.id.txtViewFechaNacimiento);
        bio = view.findViewById(R.id.txtViewBio);
        isFavorito = view.findViewById(R.id.faveIcon);

        if(viewModel.getContactoSeleccionado().getValue() != null){
            if(viewModel.getContactoSeleccionado().getValue().isFavorito()){
                isFavorito.setVisibility(View.VISIBLE);
            }else{
                isFavorito.setVisibility(View.GONE);
            }

            //Actualizar la UI
            //le pongo al xml los datos del objeto en cuestion
            foto.setImageResource(viewModel.getContactoSeleccionado().getValue().getImgResource());
            nombreCompleto.setText(viewModel.getContactoSeleccionado().getValue().getNombre() +" " +viewModel.getContactoSeleccionado().getValue().getApellidos());
            fechaNacimiento.setText(viewModel.getContactoSeleccionado().getValue().obtenerFechaNacimientoCorta());
            bio.setText(viewModel.getContactoSeleccionado().getValue().getBiografia());
        }



        /*El observer*/
        final Observer<ContactImpl> contactObserver = new Observer<ContactImpl>() {
            @Override
            public void onChanged(ContactImpl contact) {
                //Actualizar la UI
                //le pongo al xml los datos del objeto en cuestion
                if(viewModel.getContactoSeleccionado().getValue() != null){


                        if(viewModel.getContactoSeleccionado().getValue().isFavorito()){
                            isFavorito.setVisibility(View.VISIBLE);
                        }else {
                            isFavorito.setVisibility(View.GONE);
                        }

                    foto.setImageResource(viewModel.getContactoSeleccionado().getValue().getImgResource());
                    nombreCompleto.setText(viewModel.getContactoSeleccionado().getValue().getNombre() +" " +viewModel.getContactoSeleccionado().getValue().getApellidos());
                    fechaNacimiento.setText(viewModel.getContactoSeleccionado().getValue().obtenerFechaNacimientoCorta());
                    bio.setText(viewModel.getContactoSeleccionado().getValue().getBiografia());
                }



            }
        };

            //Observo el LiveData con ese observer que acabo de crear
        viewModel.getContactoSeleccionado().observe(this, contactObserver);



        return view;
    }
}
