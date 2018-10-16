export const getSingleErrorMessage = (state) => {
    const fetchError = state.fetchError;
    if (!fetchError) {
        return null;
    }

    if (fetchError.errors) {
        return fetchError.errors[0];
    }

    if (fetchError.statusText) {
        return fetchError.statusText;
    }

    return null;
}
