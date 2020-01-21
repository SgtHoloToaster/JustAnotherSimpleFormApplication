<template>
    <div>
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
                <ProjectFormRow v-for="form in forms" :form="form"></ProjectFormRow>
            </tbody>
        </table>    
    </div>
</template>

<script>
    import ProjectFormsApiClient from '../../../api-clients/project-forms';
    import ProjectFormRow from './components/form-row.vue';

    export default {
        components: {
            ProjectFormRow
        },
        created: function () {
            ProjectFormsApiClient.getForms()
                .then(async response => await response.json())
                .then(forms => this.forms = forms);
        },
        data: function () {
            return {
                forms: []
            }
        }
    }
</script>