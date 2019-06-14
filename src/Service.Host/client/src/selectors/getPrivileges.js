export default state => {
    const { privilege } = state.oidc.user.profile;

    if (!privilege) {
        return [];
    }

    if (!Array.isArray(privilege)) {
        return [privilege];
    }

    return state.oidc.user.profile.privilege;
};
