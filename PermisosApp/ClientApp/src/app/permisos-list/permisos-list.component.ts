import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { PermisosService } from '../services/permisos.service';
import { Permiso } from '../models/permiso';

@Component({
  selector: 'app-permisos-list',
  templateUrl: './permisos-list.component.html',
  styleUrls: ['./permisos-list.component.css']
})
export class PermisosListComponent implements OnInit {
  permisosList$: Observable<Permiso[]>;

  constructor(private permisosService: PermisosService, private router: Router) { }

  ngOnInit() {
    this.loadPermisosList();
  }

  loadPermisosList() {
    this.permisosList$ = this.permisosService.getPermisos();
  }

  delete(id) {
    const ans = confirm('Usted va a eliminar el permiso on id: ' + id);
    if (ans) {
      this.permisosService.deletePermiso(id).subscribe((data) => {
        this.loadPermisosList();
      });
    }
  }
}
