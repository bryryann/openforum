import { Routes } from '@angular/router';

import { LandingComponent } from './landing/landing.component';
import { AuthComponent } from './auth/auth.component';

export const routes: Routes = [
  {
    path: 'auth',
    component: AuthComponent
  },
  {
    path: 'welcome',
    component: LandingComponent
  },
];
