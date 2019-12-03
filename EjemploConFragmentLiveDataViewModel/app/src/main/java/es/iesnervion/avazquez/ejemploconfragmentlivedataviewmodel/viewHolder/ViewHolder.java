package es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.viewHolder;

import android.widget.ImageView;
import android.widget.TextView;

import de.hdodenhof.circleimageview.CircleImageView;

public class ViewHolder {

    CircleImageView fotoContacto;
    TextView nombreContacto;
    TextView apellidosContacto;
    TextView fechaNacimientoContacto;
    ImageView isFavorito;

    public ViewHolder(CircleImageView fotoContacto, TextView nombreContacto, TextView apellidosContacto, TextView fechaNacimientoContacto, ImageView isFavorito) {
        this.fotoContacto = fotoContacto;
        this.nombreContacto = nombreContacto;
        this.apellidosContacto = apellidosContacto;
        this.fechaNacimientoContacto = fechaNacimientoContacto;
        this.isFavorito = isFavorito;
    }

    public CircleImageView getFotoContacto() {
        return fotoContacto;
    }

    public TextView getNombreContacto() {
        return nombreContacto;
    }

    public TextView getApellidosContacto() {
        return apellidosContacto;
    }

    public TextView getFechaNacimientoContacto() {
        return fechaNacimientoContacto;
    }

    public ImageView getIsFavorito() {
        return isFavorito;
    }
}
