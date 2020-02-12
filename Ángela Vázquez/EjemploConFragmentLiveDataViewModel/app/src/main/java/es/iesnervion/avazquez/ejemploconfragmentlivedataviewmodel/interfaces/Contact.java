package es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.interfaces;

import java.util.GregorianCalendar;

public interface Contact {

    public String getNombre();

    public void setNombre(String nombre);

    public String getApellidos();

    public void setApellidos(String apellidos);

    public GregorianCalendar getFechaNacimiento();

    public void setFechaNacimiento(GregorianCalendar fechaNacimiento);

    public String getBiografia();

    public void setBiografia(String biografia);

    public int getImgResource();

    public void setImgResource(int imgResource);

    public boolean isFavorito();

    public void setFavorito(boolean favorito);
}