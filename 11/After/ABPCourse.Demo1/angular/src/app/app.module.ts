import { AccountConfigModule } from '@abp/ng.account/config';
import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { InternetConnectionStatusComponent, ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { FeatureManagementModule } from '@abp/ng.feature-management';
import { AbpOAuthModule } from '@abp/ng.oauth';
import { ThemeLeptonXModule } from '@abp/ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@abp/ng.theme.lepton-x/layouts';
import { AccountLayoutModule } from '@abp/ng.theme.lepton-x/account';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VALIDATION_BLUEPRINTS } from "@ngx-validate/core";
import { DEFAULT_VALIDATION_BLUEPRINTS } from "@abp/ng.theme.shared";

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    }),
    AbpOAuthModule.forRoot(),
    ThemeSharedModule.forRoot({
      validation: {
        blueprints: {
          uniqueUsername: "::AlreadyExists[{{ username }}]",
        },
      }
    }),

    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),


    FeatureManagementModule.forRoot(),
    InternetConnectionStatusComponent,
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    AccountLayoutModule.forRoot()
  ],
  declarations: [AppComponent],
  providers: [
    APP_ROUTE_PROVIDER,
    {
      provide: VALIDATION_BLUEPRINTS,
      useValue: {
        ...DEFAULT_VALIDATION_BLUEPRINTS,
        required: "::Required",
        maxlength: "::MaxLength[{{ requiredLength }}]",
      },
    },],
  bootstrap: [AppComponent],
})
export class AppModule { }
