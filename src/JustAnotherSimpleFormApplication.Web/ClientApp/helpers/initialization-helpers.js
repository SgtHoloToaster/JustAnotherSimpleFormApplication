export function ifNotNull(value, func) {
    return value == null ? value : func(value);
}