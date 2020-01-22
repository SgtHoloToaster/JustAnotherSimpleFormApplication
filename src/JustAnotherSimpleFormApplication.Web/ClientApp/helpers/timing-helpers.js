export function throttle(action, delay) {
    let sync = null;
    return function () {
        let localSync = sync = setTimeout(() => {
            if (localSync === sync)
                action();
        }, delay);
    };
};