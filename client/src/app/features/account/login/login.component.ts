import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatInput } from '@angular/material/input';
import { MatFormField, MatLabel } from '@angular/material/select';
import { AccountService } from '../../../core/services/account.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatFormField,
    MatInput,
    MatLabel,
    MatButtonModule,
    
],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {

 private readonly fb = inject (FormBuilder);
 private readonly accountService = inject(AccountService);
 private readonly router = inject(Router);
 private readonly ActivatedRoute = inject(ActivatedRoute);
 returnUrl = '/shop';

 constructor(){
  const url = this.ActivatedRoute.snapshot.queryParams['returnUrl'];
  if (url) this.returnUrl = url;
 }


  loginForm = this.fb.group({
    email: [''],
    password: ['']
  });


onSubmit() {
  this.accountService.login(this.loginForm.value).subscribe({
    next: () => {
      this.accountService.getUserInfo().subscribe();
      this.router.navigateByUrl(this.returnUrl);
    }
  })
}



}
