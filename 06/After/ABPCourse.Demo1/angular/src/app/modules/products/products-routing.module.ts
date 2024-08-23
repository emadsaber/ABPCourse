import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { ListProductsComponent } from './list-products/list-products.component';
import { permissionGuard } from '@abp/ng.core';

const routes: Routes = [
  {
    path: 'add',
    pathMatch: 'full',
    component: AddProductComponent,
    canActivate: [permissionGuard],
    data: {
        requiredPolicy: 'Demo1.Products.CreateEdit', // policy key for your component
    },
  },
  {
    path: '',
    pathMatch: 'full',
    component: ListProductsComponent,
    canActivate: [permissionGuard],
    data: {
        requiredPolicy: 'Demo1.Products.List', // policy key for your component
    },
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
