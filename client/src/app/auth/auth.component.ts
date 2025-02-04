import { Component, signal, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AuthView, isAuthView } from './auth.model';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [LoginComponent, SignupComponent],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent implements OnInit {
  view = signal<AuthView>(undefined);
  private route = inject(ActivatedRoute);

  ngOnInit() {
    const queryView = this.route.snapshot.queryParamMap.get('view');
    if (!queryView || !isAuthView(queryView)) {
      this.view.set(undefined);
      return
    }

    this.view.set(queryView);
  }

  toggleView() {
    this.view.update(prev => prev === 'login' ? 'register' : 'login');
  }
}
