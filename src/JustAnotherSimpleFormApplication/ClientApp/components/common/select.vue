<template>
    <select v-model="valueMutable">
        <option disabled :value="null" hidden>{{nullOptionName}}</option>
        <option disabled :value="undefined" hidden>{{nullOptionName}}</option>
        <option v-for="option in options" :value="valueFunc(option)">
            {{nameFunc(option)}}
        </option>
    </select>
</template>

<script>
import MultioptionsControl from './mixins/multiple-options-control'

export default {
    mixins: [MultioptionsControl]
}
</script>