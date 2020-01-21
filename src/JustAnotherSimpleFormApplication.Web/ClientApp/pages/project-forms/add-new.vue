<template>
    <div>
        <div class="container">
            <div class="row">
                <label>Project Name</label>
                <input class="form-control" v-model="form.name" />
            </div>
            <div class="row">
                <label>Project Type</label>
                <EnumSelect class="form-control" v-model="form.projectType" :options="projectTypeEnum"></EnumSelect>
            </div>
            <div class="row">
                <label>Contract Start Date</label>
                <DatePicker v-model="form.contractStartDate" class="full-width" input-class="form-control"></DatePicker>
            </div>
            <div class="row">
                <label>Contract End Date</label>
                <DatePicker v-model="form.contractEndDate" class="full-width" input-class="form-control"></DatePicker>
            </div>
            <div class="row">
                <label>Payment Type</label>
                <EnumCustomRadio v-model="form.paymentType" :options="paymentTypeEnum" class="full-width flex" />
            </div>
            <div class="row checkbox-row">
                <label>Is a former client?</label>
                <CustomCheckbox v-model="form.isFormerClient"></CustomCheckbox>
            </div>
            <div class="row"><button @click="save" class="btn btn-success">Submit</button></div>
        </div>
    </div>
</template>

<script>
    import EnumSelect from '../../components/common/enum-select.vue';
    import EnumCustomRadio from '../../components/common/enum-custom-radio-button.vue';
    import CustomCheckbox from '../../components/common/custom-checkbox.vue';
    import DatePicker from 'vuejs-datepicker'
    import ProjectForm from '../../models/project-form';
    import PaymentTypeEnum from '../../enums/payment-type-enum';
    import ProjectTypeEnum from '../../enums/project-type-enum';
    import ProjectFormsApiClient from '../../api-clients/project-forms';

    export default {
        components: {
            CustomCheckbox,
            DatePicker,
            EnumSelect,
            EnumCustomRadio
        },
        created: function () {
            this.projectTypeEnum = ProjectTypeEnum;
            this.paymentTypeEnum = PaymentTypeEnum;
        },
        data: function () {
            return {
                form: new ProjectForm()
            };
        },
        methods: {
            save: function () {
                ProjectFormsApiClient.addNew(this.form);
            }
        }
    };
</script>

<style scoped>
    .container {
        max-width: 370px;
    }

    .checkbox-row label {
        margin-right: 15px;
    }

    .row {
        margin-bottom: 1rem;
    }
</style>