<template>
    <div>
        <div class="container">
            <div class="row">
                <label>Project Name</label>
                <input class="form-control" v-model="form.name" />
                <Validation field-name="name" :validator="validator"></Validation>
            </div>
            <div class="row">
                <label>Project Type</label>
                <EnumSelect class="form-control" v-model="form.projectType" :options="projectTypeEnum"></EnumSelect>
                <Validation field-name="projectType" :validator="validator"></Validation>
            </div>
            <div class="row">
                <label>Contract Start Date</label>
                <DatePicker v-model="form.contractStartDate" class="full-width" input-class="form-control"></DatePicker>
                <Validation field-name="contractStartDate" :validator="validator"></Validation>
            </div>
            <div class="row">
                <label>Contract End Date</label>
                <DatePicker v-model="form.contractEndDate" class="full-width" input-class="form-control"></DatePicker>
                <Validation field-name="contractEndDate" :validator="validator"></Validation>
            </div>
            <div class="row">
                <label>Payment Type</label>
                <EnumCustomRadio v-model="form.paymentType" :options="paymentTypeEnum" class="full-width flex" />
                <Validation field-name="paymentType" :validator="validator"></Validation>
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
    import EnumSelect from '../../../components/common/enum-select.vue';
    import EnumCustomRadio from '../../../components/common/enum-custom-radio-button.vue';
    import CustomCheckbox from '../../../components/common/custom-checkbox.vue';
    import DatePicker from 'vuejs-datepicker'
    import ProjectForm from '../../../models/project-form';
    import PaymentTypeEnum from '../../../enums/payment-type-enum';
    import ProjectTypeEnum from '../../../enums/project-type-enum';
    import ProjectFormsApiClient from '../../../api-clients/project-forms';
    import getValidator from '../../../models/validation/project-form-validation';
    import Validation from '../../../components/common/validation.vue';
    import { throttle } from '../../../helpers/timing-helpers';
    import Notification from '../../../helpers/notification';


    export default {
        components: {
            CustomCheckbox,
            DatePicker,
            EnumSelect,
            EnumCustomRadio,
            Validation
        },
        created: function () {
            this.projectTypeEnum = ProjectTypeEnum;
            this.paymentTypeEnum = PaymentTypeEnum;
            this.lazyValidation = throttle(() => this.validator.validate(this.form), 300);
        },
        data: function () {
            return {
                form: new ProjectForm(),
                validator: getValidator()
            };
        },
        updated: function () {
            if (this.validator.haveErrors())
                this.lazyValidation();
        },
        methods: {
            save: function () {
                if (!this.validator.validate(this.form))
                    return;

                ProjectFormsApiClient.addNew(this.form);
                this.form = new ProjectForm();
                Notification.success('The project form has been successfuly added');
            }
        }
    };
</script>

<style scoped>
    .container {
        max-width: 460px;
    }

    .checkbox-row label {
        margin-right: 15px;
    }

    .row {
        margin-bottom: 1rem;
    }
</style>