import { Component } from '@angular/core';
import {UserService} from "./user.service";
import Swal from'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'frontend';

  router: string;

  constructor(private userService: UserService, private _router: Router) {
    this.router = _router.url;
    console.log(this.router);
  }

  onClickSubmit(data :any) {     

    this.userService.store(data)
      .subscribe(
        (next: any) => {
           console.log('ads');
           this._router.navigate(['/admin']);
           this.router = '/admin';
        },
        error => {
          Swal.fire(error.statusText);
        });
  }
}
