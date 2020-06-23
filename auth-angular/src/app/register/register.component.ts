import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: boolean;
  @Output() cancelRegistration = new EventEmitter();

  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  Register() {
    this.authService.register(this.model).subscribe(() => {
      console.log('Successfuly register');
      this.model.username = '';
      this.model.password = '';
    }, error => {
      console.log(error);
    });
  }

  Cancel() {
    this.cancelRegistration.emit(false);
  }

}
