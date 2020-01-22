<template>
    <span style="display:grid;">
        <small v-for="error in validator.getErrors(fieldName)" class="validatior-error-text">{{error}}</small>
    </span>
</template>

<script>
    export default {
        props: {
            name: {
                type: String,
                required: true
            },
            validator: {
                type: Object,
                required: true
            }
        }
    }
</script>