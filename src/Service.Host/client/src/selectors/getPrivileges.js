export default state => {
    const priv = state.oidc.user.profile.privilege;

    if (!priv) {
        return [];
    }
    if (priv.length === 1) {
        return [priv];
    }
    return state.oidc.user.profile.privilege;
};
