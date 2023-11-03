import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MainService } from 'src/app/services/main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  

  ngOnInit(): void { 

  }

  constructor(private mainService: MainService){}


  form = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    vorname: new FormControl('', [Validators.required, Validators.minLength(3)]),
    filename: new FormControl('', [Validators.required]),
    telephone: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
  });
  

  contactform = new FormGroup({
    contactname: new FormControl('', [Validators.required, Validators.minLength(3)]),
    textAreaDetail: new FormControl('', [Validators.required, Validators.minLength(3)]),
    contactemail: new FormControl('', [Validators.required, Validators.email]),
  });
  


  get f(){
    return this.form.controls;
  }

  get ff(){
    return this.contactform.controls;
  }
  
  applySubmit(){
    console.log(this.form.value);

    let request = {
      "message": `Name: ${this.form.value.name}
                Email: ${this.form.value.email},
                Telephone: ${this.form.value.telephone}
                Address: ${this.form.value.address}`,
      "title": "Qlick and Test Job Application",
      "emailAddress": this.form.value.email,
      "CVPath": this.form.value.filename
    }

    console.log(request);

    this.mainService.contactAdmin(request).subscribe(resp => {
      alert("Success")
    }, err => {
      alert("failed")
    })
  }

  contactSubmit(){
    console.log(this.contactform.value)

    let request = {
      "message": `Email: ${this.contactform.value.contactemail}
                    Name: ${this.contactform.value.contactname},
                    Message: ${this.contactform.value.textAreaDetail}`,
      "title": "Qlick and Test Contact",
      "emailAddress": this.contactform.value.contactemail
    }

    this.mainService.contactAdmin(request).subscribe(resp => {
      alert("Success")
    }, err => {
      alert("failed")
    })

  }

}
