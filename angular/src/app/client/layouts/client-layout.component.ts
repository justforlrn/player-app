import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-layout',
  templateUrl: './client-layout.component.html',
})
export class ClientLayoutComponent {
  constructor(private router: Router) {}
}
