import { createApp } from 'vue'
import App from './App.vue'
import rutas from './Router'

var app = createApp(App)
app.use(rutas).mount('#app')
