import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
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
  
  submit(){
    console.log(this.form.value);
  }

  contactSubmit(){
    console.log(this.contactform.value)
  }

  ngOnInit(): void {
  

}}
