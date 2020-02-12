package es.iesnervion.avazquez.puntokus.viewModels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class ViewModelRegistro extends ViewModel {

    private MutableLiveData<Boolean> goToSignUp;
    private String email;
    private String password;


    public ViewModelRegistro() {

        this.goToSignUp = new MutableLiveData<>();
        this.email = "";
        this.password = "";
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }



    public LiveData<Boolean> getGoToSignUp() {
        return goToSignUp;
    }

    public void setGoToSignUp(boolean goToSignUp) {
        if(goToSignUp){
            this.goToSignUp.setValue(goToSignUp);
            this.goToSignUp.setValue(false);
        }

    }
}
