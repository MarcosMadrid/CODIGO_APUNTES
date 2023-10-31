import { createApp } from 'vue'
import App from './App.vue'
import rutas from './Router'

var app = createApp(App)

app.config.globalProperties.$filters = {
    IsPar(num){
        if(num%2 == 0)
            return true;
        return;
    }
}

app.use(rutas).mount('#app')
