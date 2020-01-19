export default class EnumHelper {
    static toList(enums) {
        const result = [];
        for (let key in enums) {
            if (key[0] !== '_') // not a private member
                result.push(enums[key]);
        }

        return result;
    }

    static getName(value, enums) {
        return enums._properties[value].name;
    }
}