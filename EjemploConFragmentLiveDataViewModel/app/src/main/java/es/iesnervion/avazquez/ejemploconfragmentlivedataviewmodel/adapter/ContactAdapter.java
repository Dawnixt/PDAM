package es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.adapter;

import android.app.Activity;
import android.content.Context;
import android.content.res.Configuration;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

import de.hdodenhof.circleimageview.CircleImageView;

import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.R;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.entities.ContactImpl;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.viewHolder.ViewHolder;

public class ContactAdapter extends BaseAdapter {

    private final Context context;
    private final ArrayList<ContactImpl> contactoArrayList;

    public ContactAdapter(Context context, ArrayList<ContactImpl> contactoArrayList ) {
        this.context = context;
        this.contactoArrayList = contactoArrayList;
    }

    @Override
    public int getCount() {
        return contactoArrayList.size();
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }



    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        //cogemos el contacto seleccionado
        ContactImpl contacto = contactoArrayList.get(position);
        /*Ahora vamos a hacerlo con ViewHolder*/
        ViewHolder holder ;
        //int orientacion = context.getResources().getConfiguration().orientation;

            if(convertView == null){
                LayoutInflater layoutInflater = LayoutInflater.from(context);
                convertView = layoutInflater.inflate(R.layout.layout_contacto,parent, false);


                //creamos referencias
                //foto contacto
                CircleImageView fotoContacto =
                        (CircleImageView)convertView.findViewById(R.id.fotoContacto);


                //nombre
                TextView nombreContacto =
                        (TextView)convertView.findViewById(R.id.textoNombre);

                //estrella is Favorito
                ImageView isFavorito = (ImageView)convertView.findViewById(R.id.faveIcon);

                //apellido
                TextView apellidoContacto =
                            (TextView)convertView.findViewById(R.id.textoApellidos);

                //fechaNacimiento
                TextView fechaNacimientoContacto = (TextView)convertView.findViewById(R.id.textoFechaNacimiento);

                //ahora usamos esas referencias pa ponerselas al contacto actual
                apellidoContacto.setText(contacto.getApellidos());
                fotoContacto.setImageResource(contacto.getImgResource());
                nombreContacto.setText(contacto.getNombre());
                fechaNacimientoContacto.setText(contacto.obtenerFechaNacimientoCorta());
                //Con isFavorito no hace falta porque siempre es la misma imagen (la estrella)
                //solo cambiamos su visibilidad

                holder = new ViewHolder(fotoContacto, nombreContacto, apellidoContacto, fechaNacimientoContacto, isFavorito);

                convertView.setTag(holder);
            }else{
                //si no es null, recicla
                holder = (ViewHolder) convertView.getTag();
            }

            //ACTUALIZAMOS LOS ELEMENTOS
        holder.getFotoContacto().setImageResource(contacto.getImgResource());
        holder.getNombreContacto().setText(contacto.getNombre());
        holder.getApellidosContacto().setText(contacto.getApellidos());
        holder.getFechaNacimientoContacto().setText(contacto.obtenerFechaNacimientoCorta());

        if(contacto.isFavorito()){
            holder.getIsFavorito().setVisibility(View.VISIBLE);
        }else{
            holder.getIsFavorito().setVisibility(View.GONE);
        }
        return convertView;
    }
}
