import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { MatBadgeModule } from '@angular/material/badge';
import{MatFormFieldModule} from '@angular/material/form-field';
import { Router, RouterLink, RouterLinkActive, RouterModule } from '@angular/router';
import { BusyService } from '../../../core/services/busy.service';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { CartService } from '../../../core/services/cart.service';
import { AccountService } from '../../../core/services/account.service';
import {  MatMenu, MatMenuItem, MatMenuTrigger } from '@angular/material/menu';
import { MatDivider } from '@angular/material/divider';



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
    MatProgressBarModule,
    MatMenuTrigger,
    MatMenu,
    MatDivider,
    MatMenuItem 
    
    
],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  busyService = inject(BusyService);
  cartService = inject(CartService);
  accountService = inject (AccountService);
  private readonly router = inject(Router);

  logout(){
    this.accountService.logout().subscribe({
      next: () => {
        this.accountService.currentyUser.set(null);
        this.router.navigateByUrl('/');
      }
    })
  }



}
