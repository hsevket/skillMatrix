import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  isExpanded = false;
  show = false;
  collapse() {
    this.isExpanded = false;
  }
  
  hamburgerToggle(){
    this.show = !this.show;
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
