import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepositService {
  private baseUrl = 'https://localhost:7212/api/accounts';

  constructor(private http: HttpClient) {}

  /**
   * Sends a raw decimal value to the API for deposit.
   * Must match the C# signature: [FromBody] decimal amount
   */
  deposit(accountType: string, amount: number): Observable<any> {
    const url = `${this.baseUrl}/${accountType}/deposit`;
    return this.http.post(url, amount);
  }
}