export default {
    props: {
        value: {
            required: true
        },
        options: {
            type: Array,
            required: true
        },
        valueFunc: {
            default: () => option => option.id
        },
        nameFunc: {
            default: () => option => option.name
        },
        nullOptionName: {
            type: String,
            default: () => 'Please select'
        }
    },
    computed: {
        valueMutable: {
            get: function () {
                return this.value;
            },
            set: function (value) {
                this.$emit('input', value);
            }
        }
    }
};