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

export default userManager;
