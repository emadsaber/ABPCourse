import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { ListProductsComponent } from './list-products/list-products.component';

const routes: Routes = [
  {
    path: 'add',
    pathMatch: 'full',
    component: AddProductComponent
  },
  {
    path: '',
    pathMatch: 'full',
    component: ListProductsComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
