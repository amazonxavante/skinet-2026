import { Component, inject, OnInit,  } from '@angular/core';
import { HeaderComponent } from "./layout/header/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/pagination';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  baseUrl = 'https://localhost:5001/api/'
  private readonly http = inject(HttpClient);
  title = 'Atomic Coffee';

  products: Product[] = [];

    ngOnInit(): void {
    this.http.get<Pagination<Product>>(this.baseUrl + 'products').subscribe({
      next: response => this.products = response.data,
      error: (error) => console.log(error),
      complete: () => console.log('complete')
    })
  }
  



  

}

