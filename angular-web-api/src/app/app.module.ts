import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SimpleFormComponent } from './simple-form/simple-form.component';
import { SimpleFormService } from './simple-form//simple-form.service';
import { HomeComponent } from './home/home.component';

const appRoutes: Routes = [
  { path: 'simple-form', component: SimpleFormComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  declarations: [AppComponent, SimpleFormComponent, HomeComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule
  ],
  providers: [SimpleFormService],
  bootstrap: [AppComponent]
})
export class AppModule {}
