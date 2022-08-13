import { Environment } from '@abp/ng.core';

const baseUrl = 'http://getsoft.vn';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Player',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://getsoft.vn',
    redirectUri: baseUrl,
    clientId: 'Player_App',
    responseType: 'code',
    scope: 'offline_access Player',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'http://getsoft.vn',
      rootNamespace: 'Player',
    },
  },
} as Environment;
