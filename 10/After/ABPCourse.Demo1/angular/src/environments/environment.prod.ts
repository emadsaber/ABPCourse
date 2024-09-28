import { Environment } from '@abp/ng.core';

const baseUrl = 'https://localhost:44360';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Demo1',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44361/',
    redirectUri: baseUrl,
    clientId: 'Demo1_App',
    responseType: 'code',
    scope: 'offline_access Demo1',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44361',
      rootNamespace: 'ABPCourse.Demo1',
    },
  },
} as Environment;
