import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
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
