<template>
    <label class="checkbox-container">
        <input type="checkbox" :value="value" @input="onChange"/>
        <span class="checkmark"></span>
    </label>
</template>

<script>
    export default {
        props: {
            value: Boolean
        },
        created: function () {
            if (this.value == null)
                this.$emit('input', false);
        },
        methods: {
            onChange: function (event) {
                const value = Boolean(event.target.value);
                this.$emit('input', value);
            }
        }
    }
</script>

<style scoped>
    .checkbox-container {
        position: relative;
        height: 25px;
        width: 25px;
        margin-bottom: 12px;
        cursor: pointer;
        font-size: 22px;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
    }

    .checkbox-container input {
        position: absolute;
        opacity: 0;
        cursor: pointer;
        height: 0;
        width: 0;
    }

    .checkmark {
        position: absolute;
        top: 0;
        left: 0;
        height: 25px;
        width: 25px;
        background-color: #eee;
    }

    .checkbox-container:hover input ~ .checkmark {
        background-color: #ccc;
    }

    .checkbox-container input:checked ~ .checkmark {
        background-color: #2196F3;
    }

    .checkmark:after {
        content: "";
        position: absolute;
        display: none;
    }

    .checkbox-container input:checked ~ .checkmark:after {
        display: block;
    }

    .checkbox-container .checkmark:after {
        left: 9px;
        top: 5px;
        width: 7px;
        height: 13px;
        border: solid white;
        border-width: 0 3px 3px 0;
        -webkit-transform: rotate(45deg);
        -ms-transform: rotate(45deg);
        transform: rotate(45deg);
    }
</style>