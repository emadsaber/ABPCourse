import { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductDto, ProductsService } from '@proxy/products';

@Component({
  selector: 'app-list-products',
  standalone: true,
  imports: [],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.scss'
})
export class ListProductsComponent {
  products: ProductDto[] = [];
  input: PagedAndSortedResultRequestDto = { maxResultCount: 10, skipCount: 0 };

  constructor(private productsService: ProductsService, private router: Router) {
  }
  ngOnInit(): void {
    this.productsService.getList(this.input).subscribe(result => this.products = result.items);
  }

  addProduct() {
    this.router.navigateByUrl('/products/add');
  }
}
