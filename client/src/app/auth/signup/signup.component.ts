import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';

import { AuthValidator } from '../auth.validator';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  form = new FormGroup({
    username: new FormControl('', {
      validators: [Validators.required]
    }),
    email: new FormControl('', {
      validators: [Validators.required, Validators.email]
    }),
    password: new FormControl('', {
      validators: [
        Validators.required,
        Validators.minLength(8),
        AuthValidator.hasLowerCase,
        AuthValidator.hasUpperCase,
        AuthValidator.hasNumber,
        AuthValidator.hasSpecial
      ]
    }),
    confirmPassword: new FormControl('', {
      validators: [Validators.required]
    })
  });

  onSubmit() {
    if (this.form.invalid) return;

    console.log('valid form');

    this.form.reset();
  }
}
