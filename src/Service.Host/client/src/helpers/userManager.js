import { createUserManager } from 'redux-oidc';
import { WebStorageStateStore } from 'oidc-client';
import config from '../config';

const authority = config.cognitoHost;
const clientId = config.cognitoClientId;
const domainPrefix = config.cognitoDomainPrefix;
const { origin } = window.location;

const redirectUri = `${origin}/products/maint/auth/`;
const logoutUri = `${origin}/products/maint/auth/logged-out`;

function getCognitoDomain(prefix, authorityUri) {
    if (prefix && authorityUri) {
        const regionMatch = authorityUri.match(/cognito-idp\.(.+)\.amazonaws\.com/);
        const region = regionMatch ? regionMatch[1] : '';
        return `https://${prefix}.auth.${region}.amazoncognito.com`;
    }
    return '';
}

// eslint-disable-next-line no-unused-vars
const cognitoDomain = getCognitoDomain(domainPrefix, authority);

export const oidcConfig = {
    authority,
    client_id: clientId,
    redirect_uri: redirectUri,
    response_type: 'code',
    scope: 'email openid profile',
    post_logout_redirect_uri: logoutUri,
    userStore: new WebStorageStateStore({ store: window.localStorage }),
    automaticSilentRenew: false
};

const userManager = createUserManager(oidcConfig);

export const signOut = () => {
    if (!cognitoDomain) return;

    window.location.href = `${cognitoDomain}/logout?client_id=${clientId}&logout_uri=${encodeURIComponent(
        logoutUri
    )}`;
};

export const signOutEntra = () => {
    const { entraLogoutUri } = config;
    window.location.href = `${entraLogoutUri}?post_logout_redirect_uri=${encodeURIComponent(
        logoutUri
    )}`;
};

const originalRemoveUser = userManager.removeUser.bind(userManager);

userManager.signoutRedirect = async () => {
    await originalRemoveUser();
    signOut();
};

userManager.signoutPopup = async () => {
    await originalRemoveUser();
    signOut();
};

userManager.removeUser = originalRemoveUser;

// horrible hack to hijack sign out clicks from the Navigation component
// would be nicer just to be able to change the code, but we are so
// out of date the with the components library now that it's near impossible
const hijackSignOutClick = () => {
    document.addEventListener(
        'click',
        event => {
            const { target } = event;

            const isSignOutClick =
                (target && target.tagName === 'LI' && target.textContent.includes('Sign Out')) ||
                (target && target.textContent.includes('Sign Out')) ||
                (target &&
                    target.closest &&
                    target.closest('[role="menuitem"]') &&
                    target.closest('[role="menuitem"]').textContent.includes('Sign Out'));

            if (isSignOutClick) {
                event.preventDefault();
                event.stopPropagation();
                signOut();
            }
        },
        true
    );
};

if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', hijackSignOutClick);
} else {
    hijackSignOutClick();
}

export default userManager;
