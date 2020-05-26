import { AgeValidator } from '../validators/age';
import { UsernameValidator } from '../validators/username';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-details',
  templateUrl: 'details.page.html',
  styleUrls: ['details.page.scss']
})
export class DetailsPage {

  //@ViewChild('signupSlider') signupSlider: { slideNext: () => void; slidePrev: () => void; slideTo: (arg0: number) => void; };

  public slideOneForm: FormGroup;
  public slideTwoForm: FormGroup;

  public submitAttempt: boolean = false;
  constructor(public formBuilder: FormBuilder) {
    this.slideOneForm = formBuilder.group({
      firstName: ['', Validators.compose([Validators.maxLength(30), Validators.pattern('[a-zA-Z ]*'), Validators.required])],
      lastName: ['', Validators.compose([Validators.maxLength(30), Validators.pattern('[a-zA-Z ]*'), Validators.required])],
      email: ['', Validators.compose([Validators.maxLength(30), Validators.email, Validators.required])],
      cellNumber: ['', Validators.compose([Validators.maxLength(10), Validators.pattern('[0-9]*'), Validators.required])],
      dateOfBirth: ['', AgeValidator.isValid]     
    });

    this.slideTwoForm = formBuilder.group({
      username: ['', Validators.compose([Validators.required, Validators.pattern('[a-zA-Z]*')]), UsernameValidator.checkUsername],
      privacy: ['', Validators.required],
      department: ['',Validators.compose([Validators.maxLength(30), Validators.pattern('[a-zA-Z ]*'), Validators.required])],
      employmentTerm: ['', Validators.required],
      bio: ['']
    });
  }

  next() {
    // this.signupSlider.slideNext();
  }

  prev() {
    //this.signupSlider.slidePrev();
  }

  save() {

    this.submitAttempt = true;

    if (!this.slideOneForm.valid) {
      //this.signupSlider.slideTo(0);
    }
    else if (!this.slideTwoForm.valid) {
      // this.signupSlider.slideTo(1);
    }
    else {
      console.log("success!")
      console.log(this.slideOneForm.value);
      console.log(this.slideTwoForm.value);
    }

  }

}
