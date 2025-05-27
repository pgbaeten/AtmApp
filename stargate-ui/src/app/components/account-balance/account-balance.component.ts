import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AccountService, AccountBalance, Transaction } from '../../services/account.service';

@Component({
  selector: 'app-account-balance',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './account-balance.component.html',
  styleUrl: './account-balance.component.css'
})
export class AccountBalanceComponent implements OnInit {
  checkingBalance: number | null = null;
  savingsBalance: number | null = null;
  transactions: Transaction[] = [];
  loading = false;
  error = '';

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.loading = true;
    this.error = '';

    this.accountService.getAccountBalance('checking').subscribe({
      next: (data) => this.checkingBalance = data.balance,
      error: () => this.error = 'Could not load checking balance.'
    });

    this.accountService.getAccountBalance('savings').subscribe({
      next: (data) => this.savingsBalance = data.balance,
      error: () => this.error = 'Could not load savings balance.'
    });

    this.accountService.getTransactions().subscribe({
      next: (data) => {
        this.transactions = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Could not load transactions.';
        this.loading = false;
      }
    });
  }
}