import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WithdrawalService } from '../../services/withdrawal.service';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-create-withdrawal',
  imports: [CommonModule, FormsModule, RouterModule],
  standalone: true,
  templateUrl: './create-withdrawal.component.html',
  styleUrls: ['./create-withdrawal.component.css']
})
export class CreateWithdrawalComponent {
  amount: number | null = null;
  accountType: string = '';
  message: string = '';
  loading = false;

  constructor(private withdrawalService: WithdrawalService) {}

  submitWithdrawal() {
    if (!this.accountType || !this.amount || this.amount <= 0) {
      this.message = 'Please enter a valid account type and amount.';
      return;
    }
    this.loading = true;
    this.withdrawalService.withdraw(this.accountType, this.amount).subscribe({
      next: () => {
        this.message = 'Withdrawal successful!';
        this.loading = false;
      },
      error: (err) => {
        this.message = err?.error?.message || 'Withdrawal failed.';
        this.loading = false;
      }
    });
  }
}