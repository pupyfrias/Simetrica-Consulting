import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { LayoutComponent } from './shared/components/layout/layout.component';
import { LoadingComponent } from './shared/components/loading/loading.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http'; // Importa HttpClientModule

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterModule.forRoot([]),
        LayoutComponent,
        LoadingComponent,
        AppComponent,
        NoopAnimationsModule,
        HttpClientModule 
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy(); // Verifica si el componente se ha creado correctamente
  });

  it(`should have as title 'Simetrica-Consulting'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('Simetrica-Consulting');
  });
});
