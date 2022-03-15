import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/services/data.service';

@Component({
  selector: 'app-skill-page',
  templateUrl: './skill-page.component.html',
  styleUrls: ['./skill-page.component.scss']
})
export class SkillPageComponent implements OnInit {

  constructor(private dataService: DataService) { }
  CurrentCategory: string = "Information";
  
  ngOnInit(): void {
    this.dataService.CurrentCategory
      .subscribe(
        (currentCategory: string) => {
          this.CurrentCategory = currentCategory;
        }
      );
   }

}
