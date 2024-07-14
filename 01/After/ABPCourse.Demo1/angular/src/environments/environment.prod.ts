import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Demo1',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44388/',
    redirectUri: baseUrl,
    clientId: 'Demo1_App',
    responseType: 'code',
    scope: 'offline_access Demo1',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44388',
      rootNamespace: 'ABPCourse.Demo1',
    },
  },
} as Environment;
