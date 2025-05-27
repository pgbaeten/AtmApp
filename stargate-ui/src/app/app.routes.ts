import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { 
    path: 'withdraw', 
    loadComponent: () => import('./components/create-withdrawal/create-withdrawal.component')
      .then(m => m.CreateWithdrawalComponent) 
  },
  {
  path: 'deposit',
  loadComponent: () => import('./components/create-deposit/create-deposit.component')
    .then(m => m.CreateDepositComponent)
  },
  {
    path: 'transfer',
    loadComponent: () => import('./components/create-transfer/create-transfer.component')
      .then(m => m.CreateTransferComponent)
  },
  {
  path: 'balance',
  loadComponent: () => import('./components/account-balance/account-balance.component')
    .then(m => m.AccountBalanceComponent)
  }
];