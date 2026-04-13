import { Routes } from '@angular/router';
import { DeviceList } from './components/device-list';
import { DeviceDetail } from './components/device-detail';
import { DeviceForm } from './components/device-form';
import { Login } from './components/login';
import { Register } from './components/register';
import { authGuard } from './auth/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'devices', pathMatch: 'full' },
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'devices', component: DeviceList },
  { path: 'devices/new', component: DeviceForm, canActivate: [authGuard] },
  { path: 'devices/:id', component: DeviceDetail },
  { path: 'devices/:id/edit', component: DeviceForm, canActivate: [authGuard] },
];
