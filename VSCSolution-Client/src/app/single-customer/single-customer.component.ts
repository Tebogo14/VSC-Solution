import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactPersonDto, CustomerServiceProxy, EntityDto } from 'src/services/vsc-service.service';
import * as L from 'leaflet';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EditCustomerModalComponent } from './edit-customer-modal/edit-customer-modal.component';
import { EditPersonModalComponent } from './edit-person-modal/edit-person-modal.component';
import Swal from 'sweetalert2'; 

@Component({
  selector: 'app-single-customer',
  templateUrl: './single-customer.component.html',
  styleUrls: ['./single-customer.component.css']
})
export class SingleCustomerComponent implements OnInit {

  private map;
  bsModalRef: BsModalRef;

  constructor(private route: ActivatedRoute,
    private customerService: CustomerServiceProxy,
    private modalService: BsModalService) { }


  customerParam: any;
  customer: EntityDto = new EntityDto();
  contactPeople: Array<ContactPersonDto> = new Array<ContactPersonDto>();
  ngOnInit(): void {
    this.customerParam = this.route.snapshot.paramMap.get('id');
    this.GetCustomer();
  }

  private initMap(lat: any, long: any): void {

    let tiles: any;

    this.map = L.map('map', {
      center: [lat, long],
      zoom: 15
    });

    tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 20,
      minZoom: 3,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    tiles.addTo(this.map);

    L.marker([lat, long]).addTo(this.map);

  }

  GetCustomer() {
    this.customerService.getClients(this.customerParam).subscribe((result) => {
      this.customer = result;

      let coord = this.customer.location.split(",");

      console.log(coord);

      this.initMap(coord[0], coord[1]);

      this.customerService.getContactPerson(this.customerParam).subscribe((response) => {
        this.contactPeople = response;
      })
    })
  }

  editCustomer() {

    const initialState = {
      customer: this.customer
    }

    this.bsModalRef = this.modalService.show(EditCustomerModalComponent, Object.assign({}, { initialState }));

    this.bsModalRef.content.outcome.subscribe(data => {
      this.GetCustomer();
      window.location.reload();
    })
  }

  editPerson(person:any) {

    const initialState = {
      contactPerson: person
    }

    this.bsModalRef = this.modalService.show(EditPersonModalComponent, Object.assign({},{initialState}));

    this.bsModalRef.content.outcome.subscribe(data => {
      this.GetCustomer();
      window.location.reload();
    })
  }

  delete(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {

        this.customerService.deletePerson(id).subscribe(() => {
          Swal.fire(
            'Deleted!',
            'Your person has been deleted.',
            'success'
          ).then(() => {
            this.GetCustomer();
            window.location.reload();
          })

        })
      }
    })
  }

}
