import Vue from 'vue';
import VueRouter from 'vue-router';
import AddNewProjectForm from './pages/project-forms/add-new.vue';
import ProjectFormsList from './pages/project-forms/list.vue';
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/main.css';

Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: [
        { path: '/project-forms/add-new', component: AddNewProjectForm },
        { path: '/project-forms/search', component: ProjectFormsList },
    ]
});

new Vue({
    router,
    template: `
    <div id="app">
      <h1>Basic</h1>
      <ul>
        <li><router-link to="/project-forms/add-new">add new</router-link></li>
        <li><router-link to="/project-forms/search">list</router-link></li>
      </ul>
      <router-view class="view"></router-view>
    </div>
  `
}).$mount('#app');