import { Component } from '@angular/core';
import { ContentLayoutComponent } from '../../layout/content-layout/content-layout.component';

@Component({
  selector: 'app-rightpanel',
  templateUrl: './app.rightpanel.html',
})
export class AppRightPanelComponent {
  constructor(public app: ContentLayoutComponent) { }
}
