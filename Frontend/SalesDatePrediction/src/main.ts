import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';
import { provideAnimations } from '@angular/platform-browser/animations';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { importProvidersFrom } from '@angular/core';

bootstrapApplication(AppComponent, {
  providers: [
    provideAnimations(),
    provideHttpClient(),
    provideRouter(routes),
    importProvidersFrom(MatNativeDateModule),
    { provide: MAT_DATE_LOCALE, useValue: 'en-US' }
  ]
}).catch((err) => console.error(err));




