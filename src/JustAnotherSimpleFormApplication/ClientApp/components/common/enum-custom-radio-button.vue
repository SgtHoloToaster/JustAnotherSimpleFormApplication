<template>
    <CustomRadioButton v-model="valueMutable" :options="optionsList" :value-func="valueFunc"
                       :name-func="nameFunc" :null-option-name="nullOptionName"></CustomRadioButton>
</template>

<script>
    import MultioptionsControl from './mixins/multiple-options-control'
    import EnumOptionsConverter from './mixins/enum-options-to-list';
    import CustomRadioButton from './custom-radio-button.vue';

    export default {
        mixins: [MultioptionsControl, EnumOptionsConverter],
        components: {
            CustomRadioButton
        }
    }
</script>