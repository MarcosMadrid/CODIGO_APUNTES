import { createApp } from 'vue'
import App from './App.vue'
import rutas from './Router'
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

var app = createApp(App)
app.use(VueSweetalert2);
app.use(rutas).mount('#app')
