﻿import Vue from 'vue';
import VueRouter from 'vue-router';

import AddNewProjectForm from './pages/project-forms/add-new/add-new.vue';
import ProjectFormsList from './pages/project-forms/list/list.vue';

import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/main.css';

Vue.use(VueRouter);

const urls = Object.freeze({
    projectForms: {
        add: '/project-forms/add-new',
        list: '/project-forms/list'
    }
});

const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: [
        { path: urls.projectForms.add, component: AddNewProjectForm },
        { path: urls.projectForms.list, component: ProjectFormsList },
        { path: '*', redirect: urls.projectForms.add }
    ]
});

new Vue({
    router,
    template: `
        <div id="app">
            <nav class="navbar navbar-expand navbar-light bg-light">
                <a class="navbar-brand" href="#">Just Another Simple Form Application</a>
                <div class="navbar-nav">
                    <router-link to="${urls.projectForms.add}" class="nav-item nav-link">Add New Form</router-link>
                    <router-link to="${urls.projectForms.list}" class="nav-item nav-link">View Forms</router-link>
                </div>
            </nav>
            <div class="container page-content">
                <router-view class="view"></router-view>
            </div>
        </div>`
}).$mount('#app');