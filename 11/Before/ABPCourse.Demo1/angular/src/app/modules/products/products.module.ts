import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { AddProductComponent } from './add-product/add-product.component';
import { ListProductsComponent } from './list-products/list-products.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ListService } from '@abp/ng.core';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AddProductComponent, ListProductsComponent],
  imports: [
    SharedModule,
    CommonModule,
    ProductsRoutingModule
  ],
  providers: [ListService]
})
export class ProductsModule { }
