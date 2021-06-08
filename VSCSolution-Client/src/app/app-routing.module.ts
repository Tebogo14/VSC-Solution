import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppMainComponent } from './app-main/app-main.component';
import { CustomerComponent } from './customer/customer.component';
import { SingleCustomerComponent } from './single-customer/single-customer.component';


const routes: Routes = [{
    path: '',component: AppMainComponent,
    children: [
      { path: '', redirectTo: 'customer', pathMatch: 'full' },
      { path: 'customer', component: CustomerComponent },
      { path: 'customer/:id', component: SingleCustomerComponent },
    ]
  }];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }