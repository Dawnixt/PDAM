package es.iesnervion.avazquez.pruebapicasso.viewModel;

import androidx.fragment.app.FragmentTransaction;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.io.IOException;
import java.util.ArrayList;

import es.iesnervion.avazquez.pruebapicasso.R;
import es.iesnervion.avazquez.pruebapicasso.RespuestaAPI;
import es.iesnervion.avazquez.pruebapicasso.interfaces.APIInterface;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class SharedViewModel extends ViewModel {
    private MutableLiveData<ArrayList<String>> listaURLs;
    private MutableLiveData<String> razaElegida;
    private MutableLiveData<Boolean> isCargada;

    //Constructor
    public SharedViewModel() {
        this.listaURLs = new MutableLiveData<>();
        this.razaElegida = new MutableLiveData<>();
        this.isCargada = new MutableLiveData<>();
    }

    //getters y setters
    public LiveData<String> getRazaElegida(){
        if(this.razaElegida == null){
            this.razaElegida = new MutableLiveData<>();
        }
        return this.razaElegida;
    }

    public LiveData<Boolean> isCargada(){
        if(this.isCargada == null){
            this.isCargada = new MutableLiveData<>();
        }
        return this.isCargada;
    }

    public void setIsCargada(boolean isCargada){
        //this.isCargada.setValue(isCargada);
        this.isCargada.postValue(isCargada);
    }

    public void setRazaElegida(String razaElegida){
        this.razaElegida.setValue(razaElegida);
        cargarListaURLs();

    }

    public LiveData<ArrayList<String>> getListaURLs(){
        if(this.listaURLs == null ){
            this.listaURLs = new MutableLiveData<>();
        //no puedes poner el cargarListaURLs aqui porque listaURLs no sera null. Si acaso
            //tendrias que poner si listaURLs.value es null
        }
//        cargarListaURLs();
        return this.listaURLs;
    }


    public void setListaURLs(ArrayList<String> listaURLs) {
        this.listaURLs.setValue(listaURLs);
    }

    private void cargarListaURLs() {


        if(this.getRazaElegida().getValue() != null){
            Retrofit retrofit;
            retrofit = new Retrofit.Builder()
                    .baseUrl("https://dog.ceo/")
                    .addConverterFactory(GsonConverterFactory.create())
                    .build();

            APIInterface apiInterface = retrofit.create(APIInterface.class);

            Call<RespuestaAPI> call = apiInterface
                    .getFotosDeRaza(this.getRazaElegida().getValue());

//            TODO esto es asíncrono y entonces el view model recibe un null porque no se espera

            //https://stackoverflow.com/questions/47553632/wait-for-retrofit-asynchronous-call-response-on-an-adapter
            call.enqueue(new Callback<RespuestaAPI>() {
                @Override
                public void onResponse(Call<RespuestaAPI> call, Response<RespuestaAPI> response) {

                    if(response.isSuccessful()){
                        setListaURLs((ArrayList<String>) response.body().getLista());
                        //TODO haz aqui el cambio de fragment
                        setIsCargada(true);

                    }else{
                        ArrayList img = new ArrayList();
                        img.add("https://love2dev.com/img/error-message-laptop-1920x1297.jpg");

                        setListaURLs(img);
                    }

                }

                @Override
                public void onFailure(Call<RespuestaAPI> call, Throwable t) {
                    t.getStackTrace();
                    ArrayList img = new ArrayList();
                    img.add("https://love2dev.com/img/error-message-laptop-1920x1297.jpg");

                    setListaURLs(img);
                }
            });

        }
    }


}
