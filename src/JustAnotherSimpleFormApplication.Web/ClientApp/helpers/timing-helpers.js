export function debounce(action, delay) {
    let sync = null;
    return function () {
        clearTimeout(sync);
        sync = setTimeout(action, delay);
    };
};