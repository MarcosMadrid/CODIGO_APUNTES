import { createApp } from 'vue'
import App from './App.vue'

var app = createApp(App);

app.config.globalProperties.$filters = {
    mayuscula(dato){
        return dato.toUpperCase();
    },
    getNumeroDoble(numero){
        return numero * 2;
    }
}

app.mount('#app');
