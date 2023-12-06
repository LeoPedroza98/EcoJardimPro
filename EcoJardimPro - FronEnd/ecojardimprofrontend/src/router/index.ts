// Composables
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    component: () => import('@/layouts/default/Default.vue'),
    children: [
      {
        path:'',
        name: 'Login',
        component:() => import('@/views/Login.vue'),
      },
      {
        path:'',
        name: 'Home',
        component:() => import('@/views/Home/Home.vue')
      }
    ],
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
