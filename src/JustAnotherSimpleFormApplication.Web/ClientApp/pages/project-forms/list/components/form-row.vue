<template>
    <tr>
        <td>{{form.name}}</td>
        <td>{{projectType}}</td>
        <td>{{contractStartDate}}</td>
        <td>{{contractEndDate}}</td>
        <td>{{paymentType}}</td>
        <td>{{form.isFormerClient}}</td>
    </tr>
</template>

<script>
    import moment from 'moment';
    import PaymentTypeEnum from '../../../../enums/payment-type-enum';
    import ProjectTypeEnum from '../../../../enums/project-type-enum';
    import EnumHelper from '../../../../helpers/enum-helper';
    import { ifNotNull } from '../../../../helpers/initialization-helpers';

    export default {
        props: {
            form: {
                type: Object,
                required: true
            }
        },
        computed: {
            projectType: function () {
                return ifNotNull(this.form.projectType, v => EnumHelper.getName(v, ProjectTypeEnum));
            },
            paymentType: function () {
                return ifNotNull(this.form.paymentType, v => EnumHelper.getName(v, PaymentTypeEnum));
            },
            contractStartDate: function () {
                return ifNotNull(this.form.contractStartDate, v => this.formatDate(v));
            },
            contractEndDate: function () {
                return ifNotNull(this.form.contractEndDate, v => this.formatDate(v));
            }
        },
        methods: {
            formatDate: function (date) {
                return moment(date).format('MM/DD/YYYY');
            }
        }
    }
</script>