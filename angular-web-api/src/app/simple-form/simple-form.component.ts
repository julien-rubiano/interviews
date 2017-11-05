import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { SimpleFormService } from './simple-form.service';
import { SimpleFormModel } from './simple-form.models';

@Component({
  selector: 'app-simple-form',
  templateUrl: './simple-form.component.html',
  styleUrls: ['./simple-form.component.css']
})
export class SimpleFormComponent implements OnInit {
  constructor(
    private simpleFormService: SimpleFormService,
    private formBuilder: FormBuilder
  ) {}

  myForm: FormGroup;

  ngOnInit() {
    this.myForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', [Validators.required]],
      subscribe: [false, [Validators.required]]
    });
  }

  onSubmit({ value, valid }: { value: SimpleFormModel; valid: boolean }) {
    console.log(value, valid);
  }
}
