import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutusComponent } from './pages/aboutus/aboutus.component';
import { ContactusComponent } from './pages/contactus/contactus.component';
import { HomeComponent } from './pages/home/home.component';



@NgModule({
  declarations: [AboutusComponent, ContactusComponent, HomeComponent],
  imports: [
    CommonModule
  ]
})
export class HomeModule { }
