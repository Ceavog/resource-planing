const eventBus = {
    on(event, cb) {
        document.addEventListener(event, (e) => cb(e.detail));
    },
    dispatch(event, data) {
        document.dispatchEvent(new CustomEvent(event, {detail: data}));
    },
    remove(event, cb) {
        document.removeEventListener(event, cb);
    }
};

export default eventBus