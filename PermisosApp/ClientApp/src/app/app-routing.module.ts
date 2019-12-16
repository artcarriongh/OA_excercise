import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PermisosListComponent} from './permisos-list/permisos-list.component';
import { PermisosAddComponent } from './permisos-add/permisos-add.component';
import { PermisosDeleteComponent} from './permisos-delete/permisos-delete.component';

const routes: Routes = [
  { path: '', component: PermisosListComponent, pathMatch: 'full'},
  { path: 'add', component: PermisosAddComponent },
  { path: 'delete/:id', component: PermisosDeleteComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
