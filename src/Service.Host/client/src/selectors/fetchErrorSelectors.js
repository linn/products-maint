export default state => {
    const { fetchError } = state;
    if (!fetchError) {
        return null;
    }

    if (fetchError.errors) {
        return fetchError.errors[0].errorMessage;
    }

    if (fetchError.statusText) {
        return fetchError.statusText.message || fetchError.statusText;
    }

    return null;
};
