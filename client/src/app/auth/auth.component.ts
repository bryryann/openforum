import { Component, signal, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { LoginFormComponent } from './login-form/login-form.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { AuthView, isAuthView } from './auth.model';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [LoginFormComponent, RegisterFormComponent],
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
    //
  }
}
