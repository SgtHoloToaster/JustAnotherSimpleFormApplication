import Vue from 'vue';
import VueRouter from 'vue-router';
import AddNewProjectForm from './pages/project-forms/add-new/add-new.vue';
import ProjectFormsList from './pages/project-forms/list/list.vue';
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/main.css';

Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: [
        { path: '/project-forms/add-new', component: AddNewProjectForm },
        { path: '/project-forms/list', component: ProjectFormsList },
    ]
});

new Vue({
    router,
    template: `
        <div id="app">
            <nav class="navbar navbar-expand navbar-light bg-light">
                <a class="navbar-brand" href="#">Just Another Simple Form Application</a>
                <div class="navbar-nav">
                    <router-link to="/project-forms/add-new" class="nav-item nav-link">Add New Form</router-link>
                    <router-link to="/project-forms/list" class="nav-item nav-link">View Forms</router-link>
                </div>
            </nav>
            <div class="container page-content">
                <router-view class="view"></router-view>
            </div>
        </div>`
}).$mount('#app');