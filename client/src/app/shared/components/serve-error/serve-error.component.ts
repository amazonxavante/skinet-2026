import { Component } from '@angular/core';
import {  Router } from '@angular/router';
import { MatCard } from '@angular/material/card';

@Component({
  selector: 'app-serve-error',
  standalone: true,
  imports: [
    MatCard
  ],
  templateUrl: './serve-error.component.html',
  styleUrl: './serve-error.component.scss',
})
export class ServeErrorComponent {
  error?:any;
  constructor(private readonly router: Router){
    const navigation = this.router.currentNavigation();
    this.error = navigation?.extras.state?.['error'];
  }

}
