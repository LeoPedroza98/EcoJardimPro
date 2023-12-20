import Vue from 'vue'

//COMPONENTES
import MasterPage from './shared/MasterPage.vue'
import TextSearch from "./shared/TextSearch.vue";
import Avatar from "./shared/Avatar.vue";
import BreadCrumb from "./shared/BreadCrumb.vue";
import Cliente from "./geral/cliente/Cadastro.vue";
import Projeto from "./geral/projeto/Cadastro.vue";
import Orcamento from "./geral/orcamento/Cadastro.vue"

Vue.component("master-page", MasterPage);
Vue.component("text-search", TextSearch);
Vue.component("avatar-component", Avatar);
Vue.component("breadCrumb-component", BreadCrumb);
Vue.component("cadastro-cliente",Cliente)
Vue.component("cadastro-projeto",Projeto)
Vue.component("cadastro-orcamento", Orcamento);
//CADASTROS
