import { Component, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth';

@Component({
  selector: 'app-register',
  imports: [FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  name = '';
  email = '';
  password = '';
  errorMessage = signal('');

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  onSubmit(): void {
    this.errorMessage.set('');
    this.authService
      .register({ email: this.email, password: this.password, name: this.name })
      .subscribe({
        next: () => this.router.navigate(['/devices']),
        error: (err) => {
          const msg =
            err.error?.message || err.error?.errors?.[0]?.description || 'Registration failed.';
          this.errorMessage.set(msg);
        },
      });
  }
}
