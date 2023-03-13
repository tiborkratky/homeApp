import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LoginComponent } from './login/login.component';
import { RouterLink, RouterLinkActive } from '@angular/router';
import {
  FontAwesomeModule,
  FaIconLibrary,
} from '@fortawesome/angular-fontawesome';
import { faFacebook, faInstagram } from '@fortawesome/free-brands-svg-icons';
import { AppComponent } from 'src/app/app.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, LoginComponent, RegisterComponent],
  imports: [CommonModule, RouterLink, RouterLinkActive, FontAwesomeModule],
  exports: [HeaderComponent, FooterComponent, LoginComponent],
  bootstrap: [AppComponent],
})
export class CoreModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(faFacebook, faInstagram);
  }
}
