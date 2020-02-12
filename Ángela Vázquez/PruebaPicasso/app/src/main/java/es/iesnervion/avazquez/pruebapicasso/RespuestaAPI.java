package es.iesnervion.avazquez.pruebapicasso;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class RespuestaAPI {
    @SerializedName("status")
    private String exito;

    // @SerializedName indica el nombre exacto del valor
    // que devuelve la API
    // (se puede quitar si el nombre que tu le pones es el mismo)

    @SerializedName("message")
    private List<String> lista;


    public RespuestaAPI() {
    }

    public RespuestaAPI(String exito, List<String> lista) {
        this.exito = exito;
        this.lista = lista;
    }

    public String getExito() {
        return exito;
    }

    public void setExito(String exito) {
        this.exito = exito;
    }

    public List<String> getLista() {
        return lista;
    }

    public void setLista(List<String> lista) {
        this.lista = lista;
    }
}
