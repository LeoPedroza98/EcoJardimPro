import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import vuetify from './plugins/vuetify'


import Sidebar from './components/Sidebar.vue'
Vue.config.productionTip = false


Vue.component('sidebar', Sidebar)

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
