import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { AppMenuComponent } from '../app/shared/nav/left-nav/app.menu.component';
import { AppTopBarComponent } from '../app/shared/header/app.topbar.component';
import { AppFooterComponent } from '../app/shared/footer/app.footer.component';
import { AppRightPanelComponent } from '../app/shared/nav/right-nav/app.rightpanel.component';
import { AppBreadcrumbComponent } from '../app/shared/breadcrumb/app.breadcrumb.component';
import { BreadcrumbService } from '../app/shared/breadcrumb/breadcrumb.service';
import { TabViewModule } from 'primeng/tabview';
import { MenuService } from '../app/shared/nav/left-nav/app.menu.service';

describe('AppComponent', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                RouterTestingModule,
                TabViewModule
            ],
            declarations: [
                AppComponent,
                AppMenuComponent,
                AppRightPanelComponent,
                AppTopBarComponent,
                AppFooterComponent,
                AppBreadcrumbComponent
            ],
            providers: [BreadcrumbService, MenuService]
        }).compileComponents();
    }));

    it('should create the app', async(() => {
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    }));
});
