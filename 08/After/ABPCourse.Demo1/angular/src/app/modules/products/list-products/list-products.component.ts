import { ListService, PagedResultDto, PermissionService } from '@abp/ng.core';
import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService, CategoryDto } from '@proxy/categories';
import { GetProductListDto, ProductDto, ProductsService } from '@proxy/products';
import { DatatableComponent, NgxDatatableModule } from '@swimlane/ngx-datatable';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.scss',
})
export class ListProductsComponent {
  //products: ProductDto[] = [];
  searchForm: FormGroup;
  categories: CategoryDto[] = [];
  // count: number;
  products$: Observable<PagedResultDto<ProductDto>>;
  canCreate: boolean;

  constructor(private productsService: ProductsService,
    private router: Router,
    private formBuilder: FormBuilder,
    private categoriesService: CategoriesService,
    public readonly list: ListService<GetProductListDto>,
    private permissionService: PermissionService
  ) {
    this.buildForm();
  }
  ngOnInit(): void {
    this.categoriesService.getList({ maxResultCount: 100, skipCount: 0 }).subscribe(res => {
      this.categories = res.items;
    });
    this.searchProducts();

    this.canCreate = this.permissionService.getGrantedPolicy('Demo1.Products.CreateEdit');

  }

  buildForm() {
    this.searchForm = this.formBuilder.group({
      filter: new FormControl(''),
      categoryId: new FormControl(null),
      maxResultCount: new FormControl(50, Validators.required),
      // skipCount: new FormControl(0, Validators.required)
    });
  }


  addProduct() {
    this.router.navigateByUrl('/products/add');
  }

  searchProducts() {
    // A function that gets query and returns an observable
    const productStreamCreator = query => this.productsService.getList({...query, ...this.searchForm.value});

    this.products$ = this.list.hookToQuery(productStreamCreator); // Subscription is auto-cleared on destroy.
  }
}
