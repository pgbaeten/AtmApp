import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TransferService } from '../../services/transfer.service'; // <-- Add this import

@Component({
  selector: 'app-create-transfer',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './create-transfer.component.html',
  styleUrl: './create-transfer.component.css'
})
export class CreateTransferComponent {
  fromAccount: string = '';
  toAccount: string = '';
  amount: number | null = null;
  loading = false;
  message = '';

  constructor(private transferService: TransferService) {} // <-- Inject the service

  submitTransfer() {
    if (!this.fromAccount || !this.toAccount || !this.amount || this.amount <= 0) {
      this.message = 'Please enter valid accounts and amount.';
      return;
    }
    if (this.fromAccount === this.toAccount) {
      this.message = 'From and To accounts must be different.';
      return;
    }
    this.loading = true;
    this.transferService.transfer(this.fromAccount, this.toAccount, this.amount).subscribe({
      next: () => {
        this.message = 'Transfer successful!';
        this.loading = false;
      },
      error: (err) => {
        this.message = err?.error?.message || 'Transfer failed.';
        this.loading = false;
      }
    });
  }
}