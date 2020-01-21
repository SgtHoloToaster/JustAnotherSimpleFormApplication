function replacer(key, value) {
    if (value === undefined) 
        return null;

    return value;
};

export function serialize(object) {
    return JSON.stringify(object, replacer);
}