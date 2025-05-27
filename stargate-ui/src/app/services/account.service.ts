import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface AccountBalance {
  balance: number;
}

export interface Transaction {
  date: string;
  type: string;
  amount: number;
  accountType: string;
  description?: string;
}

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl = 'https://localhost:7212/api/accounts';

  constructor(private http: HttpClient) {}

  getAccountBalance(accountType: string): Observable<AccountBalance> {
    return this.http.get<AccountBalance>(`${this.baseUrl}/${accountType}`);
  }

  getTransactions(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(`${this.baseUrl}/transactions`);
  }
}