<template>
    <div>
        <label v-for="option in options" class="radio-container">
            {{nameFunc(option)}}
            <input v-model="valueMutable" type="radio" checked="checked" :name="id" :value="valueFunc(option)">
            <span class="checkmark"></span>
        </label>
    </div>
</template>

<script>
    import MultioptionsControl from './mixins/multiple-options-control';

    export default {
        mixins: [MultioptionsControl],
        created: function () {
            this.id = `radio-${this._uid}`;
        }
    }
</script>

<style scoped>
    .radio-container {
        display: block;
        position: relative;
        padding-left: 35px;
        margin-bottom: 12px;
        cursor: pointer;
        font-size: 22px;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
    }

    .radio-container input {
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
        border-radius: 50%;
    }

    .radio-container:hover input ~ .checkmark {
        background-color: #ccc;
    }

    .radio-container input:checked ~ .checkmark {
        background-color: #2196F3;
    }

    .checkmark:after {
        content: "";
        position: absolute;
        display: none;
    }

    .radio-container input:checked ~ .checkmark:after {
        display: block;
    }

    .radio-container .checkmark:after {
        top: 9px;
        left: 9px;
        width: 8px;
        height: 8px;
        border-radius: 50%;
        background: white;
    }

    .flex .radio-container {
        flex: 1;
    }
</style>