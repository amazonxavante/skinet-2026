import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { MatBadgeModule } from '@angular/material/badge';
import{MatFormFieldModule} from '@angular/material/form-field';
import { RouterLink, RouterLinkActive, RouterModule } from '@angular/router';
import { BusyService } from '../../../core/services/busy.service';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { CartService } from '../../../core/services/cart.service';



@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatIconModule,
    MatButtonModule,
    MatBadgeModule,
    MatCardModule,
    MatIconModule,
    MatIconModule,
    MatFormFieldModule,
    RouterModule,
    RouterLink,
    RouterLinkActive,
    MatProgressBarModule 
    
    
],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  busyService = inject(BusyService);
  cartService = inject(CartService);



}
