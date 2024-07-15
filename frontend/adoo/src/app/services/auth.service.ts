import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegistrationModel } from '../register/register.model';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  register(model: RegistrationModel): Promise<void> {
    return lastValueFrom(
      this.httpClient.post<void>(`/api/Authentication/registeration`, model)
    );
  }

  login(){
    
  }
}
