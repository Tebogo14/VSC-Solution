import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BsModalRef, BsModalService, ModalModule} from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { AppMainComponent } from './app-main/app-main.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { CustomerComponent } from './customer/customer.component';
import { API_BASE_URL, CustomerServiceProxy } from 'src/services/vsc-service.service';
import { AppConsts } from 'src/AppConsts';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MyInterceptor } from './my.interceptor';
import { SingleCustomerComponent } from './single-customer/single-customer.component';
import { FormsModule } from '@angular/forms';
import { EditCustomerModalComponent } from './single-customer/edit-customer-modal/edit-customer-modal.component';
import { EditPersonModalComponent } from './single-customer/edit-person-modal/edit-person-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AppMainComponent,
    CustomerComponent,
    SingleCustomerComponent,
    EditCustomerModalComponent,
    EditPersonModalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ModalModule.forRoot(),
  ],

  entryComponents: [
    EditCustomerModalComponent,
    EditPersonModalComponent
  ],
  providers: [
    BsModalRef,
    CustomerServiceProxy,
    { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl },
    { provide: HTTP_INTERCEPTORS, useClass: MyInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getRemoteServiceBaseUrl(): string {

  return AppConsts.remoteServiceBaseUrl;

}
