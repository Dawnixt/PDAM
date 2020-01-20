package es.iesnervion.avazquez.pruebapicasso.interfaces;


import es.iesnervion.avazquez.pruebapicasso.RespuestaAPI;
import retrofit2.Call;
import retrofit2.http.*;
public interface APIInterface {

    @GET("/api/breed/{raza_perro}/images")
    Call<RespuestaAPI> getFotosDeRaza(@Path(value = "raza_perro") String raza_perro);
}
