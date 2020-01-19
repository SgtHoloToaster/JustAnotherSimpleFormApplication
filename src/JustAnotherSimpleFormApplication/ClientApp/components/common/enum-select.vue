<template>
    <VueSelect v-model="valueMutable" :options="optionsList" :value-func="valueFunc" 
               :name-func="nameFunc" :null-option-name="nullOptionName"></VueSelect>
</template>

<script>
    import MultioptionsControl from './mixins/multiple-options-control'
    import EnumOptionsConverter from './mixins/enum-options-to-list';
    import VueSelect from './select.vue';

    export default {
        mixins: [MultioptionsControl, EnumOptionsConverter],
        components: {
            VueSelect
        }
    }
</script>