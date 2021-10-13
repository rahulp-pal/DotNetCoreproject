import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { AuthDirective } from './directives/auth.directive';
import { CapitalizePipe } from './pipes/capitalize.pipe';
import { SafePipe } from './pipes/safe.pipe';


@NgModule({
  declarations: [AuthDirective, CapitalizePipe, SafePipe],
  imports: [
    CommonModule,
    LayoutModule
  ]
})
export class SharedModule { }
