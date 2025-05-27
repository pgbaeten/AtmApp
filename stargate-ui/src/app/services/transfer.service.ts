import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransferService {
  private baseUrl = 'https://localhost:7212/api/accounts';

  constructor(private http: HttpClient) {}

  /**
   * Transfers funds between accounts.
   */
  transfer(from: string, to: string, amount: number): Observable<any> {
    const url = `${this.baseUrl}/transfer`;
    const payload = {
      from,
      to,
      amount
    };
    return this.http.post(url, payload);
  }
}