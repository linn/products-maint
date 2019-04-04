export default state => {
    const { fetchError } = state;
    if (!fetchError) {
        return null;
    }

    if (fetchError.errors.length > 1) {
        return fetchError.errors.map(error => error.errorMessage).join(', ');
    }

    if (fetchError.errors[0].errorMessage) {
        return fetchError.errors[0].errorMessage;
    }

    if (fetchError.errors) {
        return fetchError.errors[0];
    }

    if (fetchError.statusText) {
        return fetchError.statusText.message || fetchError.statusText;
    }

    return null;
};
