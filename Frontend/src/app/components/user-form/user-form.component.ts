import { UsersService } from './../../services/users.service';
import { DepartmentsService } from './../../services/departments.service';
import { Component, OnInit } from '@angular/core';
import { IDepartment } from '../../models/IDepartment';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  departments: IDepartment[];

  form = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.maxLength(30)]),
    lastName: new FormControl('',  [Validators.required, Validators.maxLength(30)]),
    gender: new FormControl('', Validators.required),
    document: new FormControl('', [Validators.required, Validators.maxLength(11)]),
    dob: new FormControl('', Validators.required),
    position: new FormControl('',  [Validators.required, Validators.maxLength(40)]),
    supervisor: new FormControl('',  [Validators.required, Validators.maxLength(62)]),
    departmentId: new FormControl('', Validators.required)
  });

  constructor(private dataUsers: UsersService, private dataDepartments: DepartmentsService, public dialog: MatDialog) {
    this.departments = [];
  }

  ngOnInit(): void {
    this.dataDepartments.getAll().subscribe(dept => this.departments = dept);
  }

  onSave(): void {
    if (this.form.valid) {
      this.dataUsers.saveUser(this.form.value).subscribe(u => console.log(u));
      this.dialog.open(SavedDialogComponent);
    }
  }
}

@Component({
  selector: 'app-saved-dialog',
  templateUrl: './saved-dialog.html',
})
export class SavedDialogComponent {}
