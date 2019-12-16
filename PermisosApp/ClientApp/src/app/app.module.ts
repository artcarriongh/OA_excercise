import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PermisosListComponent } from './permisos-list/permisos-list.component';
import { PermisosAddComponent } from './permisos-add/permisos-add.component';
import { PermisosDeleteComponent } from './permisos-delete/permisos-delete.component';
import { PermisosService} from './services/permisos.service'

@NgModule({
  declarations: [
    AppComponent,
    PermisosListComponent,
    PermisosAddComponent,
    PermisosDeleteComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    PermisosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
