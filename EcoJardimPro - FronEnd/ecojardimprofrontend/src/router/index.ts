import Vue from 'vue'
import VueRouter, { NavigationGuardNext, Route, RouteConfig } from 'vue-router'
import { AlertaSimples, AlertaPerguntaSimOuNaoBooleano } from '@/components/shared/AlertService'
import { getToken, getUserPermissions } from '@/core/config/Token'
import PermissoesPadrao from '@/core/config/PermissoesPadrao'

Vue.use(VueRouter)

const routes = [
  {
    path: "*",
    redirect: "/home"
  },
  { path: '/', redirect: '/login' },
  {
    path: '/login', name: 'Login', component: () => import('../views/Login.vue')
  },
  {
    path: '/home', name: 'Home', component: () => import('../views/Home.vue'),
    meta: { auth: true }
  },
  {
    path: '/geral/clientes', name: 'Cliente', component: () => import('../views/geral/clientes/Lista.vue'),
  },
  {
    path: '/geral/projetos', name: 'Projeto', component: () => import('../views/geral/projetos/Lista.vue'),
  },
  {
    path: '/geral/orcamentos', name: 'Orcamento', component: () => import('../views/geral/orcamentos/Lista.vue'),
  },
  {
    path: '/geral/servicos', name: 'Servico', component: () => import('../views/geral/servicos/Lista.vue'),
  },
  {
    path: '/geral/usuario', name: 'Usuario', component: () => import('../views/geral/usuario/Lista.vue'),
    meta: { auth: true}
  }
]

const router = new VueRouter({
  mode: 'history',
  linkExactActiveClass: 'active',
  base: process.env.BASE_URL,
  routes
})

let isRedirected = false;

router.beforeEach((to: Route, from: Route, next: NavigationGuardNext) => {
  const token: string | null = getToken();

  if ((to.name !== 'login') && !token && !isRedirected) {
      isRedirected = true;
      next('/login');
  } else if (to.meta && to.meta.permissions) {
      const userPermissions: string[] = getUserPermissions(token);
      const requiredPermissions: string[] = to.meta.permissions as string[];

      var hasAccess: boolean;

      if (requiredPermissions && requiredPermissions.length > 0) {
        const hasAccess = requiredPermissions.every(item => userPermissions.includes(item));
      }

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

router.afterEach(() => {
  isRedirected = false;
});

const rotasParaForm = [
  '',
];

const rotasParaFormEditar = [
  '',
];

const naoPermitirParaRotas = [

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
