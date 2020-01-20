import EnumHelper from '../../../helpers/enum-helper';

export default {
    props: {
        options: {
            type: Object,
            required: true
        }
    },
    computed: {
        optionsList: function () {
            return EnumHelper.toList(this.options)
                .map((id) => {
                    return {
                        id: id,
                        name: EnumHelper.getName(id, this.options)
                    };
                });
        }
    }
};