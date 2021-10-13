import { Component } from '@angular/core';
import { ContentLayoutComponent } from '../layout/content-layout/content-layout.component';

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html'
})
export class AppTopBarComponent {

    constructor(public app: ContentLayoutComponent) { }
}
