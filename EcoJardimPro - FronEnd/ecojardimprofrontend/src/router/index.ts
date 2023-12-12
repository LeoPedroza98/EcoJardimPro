import Vue from 'vue'
import VueRouter, { NavigationGuardNext, Route, RouteConfig } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { getToken, getUserPermissions } from '@/config/Token'
import { AlertaSimples, AlertaPerguntaSimOuNaoBooleano } from '@/helpers/MensagemHelper'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/Login.vue')
  },
  {
    path: '/home',
    name: 'home',
    component: () => import('@/views/HomeView.vue'),
    meta: { auth: true },
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to: Route, from: Route, next: NavigationGuardNext) => {
  const token: string | null = getToken();

  if ((to.name !== 'login' && to.name !== 'recuperarSenha' && to.name !== 'confirmaEmail') && !token) {
    next('/login' && '/recuperar-senha' && '/confirma-email');
  } else if (to.meta && to.meta.permissions) {
    const userPermissions: string[] = getUserPermissions(token);
    const requiredPermissions: string[] = to.meta.permissions as string[];

    let hasAccess: boolean;


    hasAccess = userPermissions.some(permission => requiredPermissions.includes(permission));


    if (hasAccess) {
      next();
    } else {
      AlertaSimples('Acesso não autorizado', 'Você não possui permissão para acessar esta página', 'warning');
      next('/home')
    }
  } else {
    next();
  }
});


const rotasParaForm = [
  '',
];

const rotasParaFormEditar = [
  '',
];

const naoPermitirParaRotas = [
  'home',
  'login',
];


let confirmNavigation = true;

const storedNavigation = sessionStorage.getItem('confirmNavigation');
if (storedNavigation !== null) {
  confirmNavigation = storedNavigation === 'true';
}

window.addEventListener('beforeunload', function (e) {
  if (confirmNavigation && !naoPermitirParaRotas.includes(router.currentRoute.name)) {
    e.preventDefault();
    e.returnValue = '';
  }
});

router.beforeResolve(async (to, from, next) => {
  if (rotasParaForm.includes(from.name)) {
    if (!to.params.liberar) {
      if (confirmNavigation && !(await AlertaPerguntaSimOuNaoBooleano('É possível que as alterações feitas não sejam salvas.\r\n Deseja sair?'))) {
        return false;
      }
      confirmNavigation = false;
      sessionStorage.setItem('confirmNavigation', String(confirmNavigation));
      next();
    } else {
      confirmNavigation = false;
      sessionStorage.setItem('confirmNavigation', String(confirmNavigation));
      next();
    }
  } else {
    confirmNavigation = true;
    sessionStorage.setItem('confirmNavigation', String(confirmNavigation));
    next();
  }
});


router.beforeEach(async (to, from, next) => {
  if (rotasParaFormEditar.includes(from.name)) {
    if (!to.params.liberar) {
      if (confirmNavigation && !(await AlertaPerguntaSimOuNaoBooleano('Tem certeza que deseja sair?'))) {
        return false;
      }
      confirmNavigation = false;
      sessionStorage.setItem('confirmNavigation', String(confirmNavigation));
      next();
    } else {
      confirmNavigation = false;
      sessionStorage.setItem('confirmNavigation', String(confirmNavigation));
      next();
    }
  } else {
    confirmNavigation = true;
    sessionStorage.setItem('confirmNavigation', String(confirmNavigation));
    next();
  }
});


export default router
