<template>
    <div>
        <div id="project-forms-search">
            <label>Filter by name</label>
            <div>
                <input v-model="searchQuery" class="form-control" type="text" @keyup.enter="search" placeholder="Start Typing" />
            </div>
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Project Name</th>
                    <th scope="col">Project Type</th>
                    <th scope="col">Contract Start Date</th>
                    <th scope="col">Contract End Date</th>
                    <th scope="col">Payment Type</th>
                    <th scope="col">Former Client</th>
                </tr>
            </thead>
            <tbody>
                <ProjectFormRow v-for="(form, index) in forms" :key="index" :form="form"></ProjectFormRow>
            </tbody>
        </table>    
    </div>
</template>

<script>
    import ProjectFormsApiClient from '../../../api-clients/project-forms';
    import ProjectFormRow from './components/form-row.vue';
    import { throttle } from '../../../helpers/timing-helpers';

    export default {
        components: {
            ProjectFormRow
        },
        created: function () {
            this.updateFormsList();
            this.lazySearch = throttle(this.search, 500);
        },
        data: function () {
            return {
                forms: [],
                searchQuery: ''
            }
        },
        methods: {
            search: function () {
                this.updateFormsList(this.searchQuery || undefined);
            },
            updateFormsList: function (name) {
                ProjectFormsApiClient.getForms(name)
                    .then(async response => await response.json())
                    .then(forms => this.forms = forms);
            }
        },
        watch: {
            searchQuery: function () {
                this.lazySearch();
            }
        }
    }
</script>

<style scoped>    
    th {
        text-align: center;
    }
</style>

<style>
    #project-forms-search {
        max-width: 500px;
        margin-bottom: 30px;
        display: flex;
    }

    #project-forms-search label {
        white-space: nowrap;
        margin-right: 10px;
        line-height: 34px;    
        margin-bottom: 0px;
    }
</style>