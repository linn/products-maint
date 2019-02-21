export default state => {
    const { fetchError } = state;
    if (!fetchError) {
        return null;
    }

    if (fetchError.errors) {
        return fetchError.errors[0];
    }

    if (fetchError.statusText) {
        return fetchError.statusText.message || fetchError.statusText;
    }

    return null;
};
