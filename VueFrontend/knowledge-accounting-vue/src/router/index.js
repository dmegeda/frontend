import Vue from 'vue'
import Router from 'vue-router'
import Home from '../components/Home'
import SingleTest from '../components/SingleTest'
import Statistic from '../components/Statistic'
import Registration from '../components/auth/Registration.vue'
import Login from '../components/auth/Login.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/test/:id',
      name: 'SingleTest',
      component: SingleTest
    },
    {
      path: '/statistic',
      name: 'Statistic',
      component: Statistic
    },
    {
      path: '/register',
      name: 'Registration',
      component: Registration
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '*',
      redirect: '/'
    }
  ]
})
