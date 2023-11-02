import { createApp } from 'vue'
import App from './App.vue'
import rutas from './Router'

var app = createApp(App)

app.config.globalProperties.$filters = {
    IsParHTML(numero){
        var color = "'color: red'";
        if(numero%2 == 0)
            color = "'color : green'";

        return( "<text style="+ color  +" >"+numero+"</text>");
    },
    IsPar(numero){
        if(numero%2 == 0)
            return(true)

        return(false);
    },
    Multiplicar(numero1, numero2){
        return(numero1 * numero2);
    }
}

app.use(rutas).mount('#app')
