import { Component, inject, OnInit  } from '@angular/core';
import { HeaderComponent } from "./layout/header/header/header.component";
import { ShopComponent } from "./features/shop/shop.component";
import {  RouterOutlet } from '@angular/router';




@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    HeaderComponent,
     ShopComponent,
     RouterOutlet
    ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

title = 'Atomic Coffee';
  

}

