import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  public applyform :any
  name = new FormControl('');
  vorname = new FormControl('');
  email = new FormControl('');
  phoneNo = new FormControl('');
  address = new FormControl('');
  customfile = new FormControl('');


  constructor() { }
  public onSubmit() {
    console.log("dd",this.applyform.value);
  }

  ngOnInit(): void {
  }
  // scrollToServices(services: string): void {    
  //   console.log(`scrolling to ${services}`);
  //   let el = document.getElementById(services);
  //   el?.scrollIntoView({behavior: 'smooth'});

  // }

}
