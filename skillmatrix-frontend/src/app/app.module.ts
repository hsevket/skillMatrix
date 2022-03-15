import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';



import { AppRoutingModule } from './app-routing.module';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ProfileInfoComponent } from './profile-info/profile-info.component';
import { SkillDisplayComponent } from './skill-display/skill-display.component';
import { SkillNavComponent } from './skill-nav/skill-nav.component';
import { SkillPageComponent } from './skill-page/skill-page.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LandingPageComponent,
    ProfileInfoComponent,
    SkillDisplayComponent,
    SkillNavComponent,
    SkillPageComponent,
 
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LandingPageComponent },
      { path: 'home', component: HomeComponent, pathMatch: 'full' }
    ]),
    AppRoutingModule
  ],
  providers: [
   
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
