package es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.entities;

import androidx.annotation.Nullable;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.GregorianCalendar;

import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.R;
import es.iesnervion.avazquez.ejemploconfragmentlivedataviewmodel.interfaces.Contact;


public class ContactImpl implements Contact,
        Comparable,
        Serializable    //esto es pa pasar un obj a otra actividad, para hacer el MasterFragment/Details

{
    private String nombre;
    private String apellidos ;
    private GregorianCalendar fechaNacimiento ;
    private String biografia ;
    private int imgResource ;
    private boolean isFavorito ;

    public ContactImpl(String nombre, String apellidos, GregorianCalendar fechaNacimiento, String biografia, int imgResource) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.biografia = biografia;
        this.imgResource = imgResource;
        this.isFavorito = false;
    }

    public ContactImpl(String nombre, String apellidos, GregorianCalendar fechaNacimiento, String biografia, int imgResource, boolean isFavorito) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.biografia = biografia;
        this.imgResource = imgResource;
        this.isFavorito = isFavorito;
    }

    public ContactImpl(String nombre, String apellidos, boolean isFavorito) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = new GregorianCalendar(1900,0,1);
        this.biografia = "";
        this.imgResource = R.drawable.imgdefault;
        this.isFavorito = isFavorito;
    }

    public ContactImpl() {
        this.nombre = "";
        this.apellidos = "";
        this.fechaNacimiento = new GregorianCalendar(1900,0,1);
        this.biografia = "";
        this.imgResource = R.drawable.imgdefault;
        this.isFavorito = false;
    }

    public ContactImpl(String nombre, String apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = new GregorianCalendar(1900,0,1);
        this.biografia = "";
        this.imgResource = R.drawable.imgdefault;
        this.isFavorito = false;
    }

    public ContactImpl(String nombre, String apellidos, GregorianCalendar fechaNacimiento) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.biografia = "";
        this.imgResource = R.drawable.imgdefault;
        this.isFavorito = false;
    }

    public ContactImpl(String nombre, String apellidos, GregorianCalendar fechaNacimiento, int imgResource) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.biografia = "";
        this.imgResource = imgResource;
        this.isFavorito = false;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public GregorianCalendar getFechaNacimiento() {
        return fechaNacimiento;
    }

    public void setFechaNacimiento(GregorianCalendar fechaNacimiento) {
        this.fechaNacimiento = fechaNacimiento;
    }

    public String getBiografia() {
        return biografia;
    }

    public void setBiografia(String biografia) {
        this.biografia = biografia;
    }

    public int getImgResource() {
        return imgResource;
    }

    public void setImgResource(int imgResource) {
        this.imgResource = imgResource;
    }

    public boolean isFavorito() {
        return isFavorito;
    }

    public void setFavorito(boolean favorito) {
        isFavorito = favorito;
    }

    //metodo añadido

    public String obtenerFechaNacimientoCorta(){
        String dateFormatted;
        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
        sdf.setCalendar(getFechaNacimiento());
        dateFormatted = sdf.format(getFechaNacimiento().getTime());

        return dateFormatted;

    }


    @Override
    public int compareTo(Object o) {
        int resultado = 0;
        if(o != null){
        if(o instanceof ContactImpl){
                ContactImpl otro = (ContactImpl) o;
                resultado = this.getNombre().compareTo(otro.getNombre());

            }
        }
        return resultado;
    }

    @Override
    public String toString() {
        return getNombre()+" "+getApellidos();
    }


    @Override
    public boolean equals(@Nullable Object obj) {
        boolean isEqual = false;



        return isEqual;
    }
}
