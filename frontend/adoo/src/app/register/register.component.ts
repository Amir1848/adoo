import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  form!: FormGroup;
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) {}

  register() {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      username: [null],
    });

    this.httpClient.get('/api/Authentication/getAge').subscribe((p) => {
      console.log(p);
    });
  }
}
