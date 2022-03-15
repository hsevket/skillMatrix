import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/services/data.service';

@Component({
  selector: 'app-skill-nav',
  templateUrl: './skill-nav.component.html',
  styleUrls: ['./skill-nav.component.scss']
})
export class SkillNavComponent implements OnInit {
  
  categories: Array<{label: string}> = [
    {
      label: 'Information'
    },
    {
      label: 'Tech Skills'
    },
    {
      label: 'Soft Skills'
    },
    {
      label: 'Language Skills'
    },
    {
      label: 'Education'
    },
   
  ]
  constructor(private dataService: DataService) { }
  CurrentCategory:string = "Information";
  
  ChangeCategory(button:string) {
    this.CurrentCategory = button;
    this.dataService.CurrentCategory.emit(this.CurrentCategory);
   
  }
  ngOnInit(): void {
    
    
  }

}
