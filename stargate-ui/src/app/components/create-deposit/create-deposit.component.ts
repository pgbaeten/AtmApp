import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DepositService } from '../../services/deposit.service';


@Component({
  selector: 'app-create-deposit',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './create-deposit.component.html',
  styleUrl: './create-deposit.component.css'
})
export class CreateDepositComponent {
  amount: number | null = null;
  accountType: string = '';
  loading = false;
  message = '';

  constructor(private depositService: DepositService) {}

  submitDeposit() {
    if (!this.accountType || !this.amount || this.amount <= 0) {
      this.message = 'Please enter a valid account type and amount.';
      return;
    }
    this.loading = true;
       this.depositService.deposit(this.accountType, this.amount).subscribe({
      next: () => {
        this.message = 'Deposit successful!';
        this.loading = false;
      },
      error: (err) => {
        this.message = err?.error?.message || 'Deposit failed.';
        this.loading = false;
      }
    });
  }
}