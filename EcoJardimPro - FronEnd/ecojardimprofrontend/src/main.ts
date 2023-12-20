import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueTheMask from 'vue-the-mask';
import VueSweetAlert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

const sweetAlertOptions = {
  confirmButtonColor: 'var(--v-success-base)',
  cancelButtonColor: 'var(--v-error-base)',
  background: 'black',
  color: 'white',
  inputLabel: 'white'
};

import './assets/scripts/formatter'

require('./components/');

Vue.config.productionTip = false

import 'sweetalert2/dist/sweetalert2.min.css';
import vuetify from './plugins/vuetify';

Vue.use(VueTheMask);
Vue.use(VueSweetAlert2, sweetAlertOptions);

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
