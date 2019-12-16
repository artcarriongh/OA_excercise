import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PermisosService } from '../services/permisos.service';
import { Permiso } from '../models/permiso';

@Component({
  selector: 'app-permisos-add',
  templateUrl: './permisos-add.component.html',
  styleUrls: ['./permisos-add.component.css']
})
export class PermisosAddComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formApellidosEmpleado: string;
  formNombreEmpleado: string;
  formTipoPermisoId: number;
  id: number;
  errorMessage: any;
  error: boolean;
  success: boolean;
  existingPermiso: Permiso;

  // tslint:disable-next-line: max-line-length
  constructor(private permisosService: PermisosService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formApellidosEmpleado = '';
    this.formNombreEmpleado = '';
    this.formTipoPermisoId = 1;
    this.error = false;
    this.success = false;
    if (this.avRoute.snapshot.params[idParam]) {
      this.id = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        id: 0,
        apellidosEmpleado: ['', [Validators.required]],
        nombreEmpleado: ['', [Validators.required]],
        tipoPermisoId: ['1', [Validators.required]]
      }
    );
  }

  ngOnInit() {
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    const permiso: Permiso = {
      id: 0,
      apellidosEmpleado: this.form.controls.apellidosEmpleado.value,
      nombreEmpleado: this.form.controls.nombreEmpleado.value,
      tipoPermisoId: this.form.controls.tipoPermisoId.value,
      fechaPermiso: new Date(),
      tipoPermiso: ''
    };

    this.permisosService.savePermiso(permiso)
      .subscribe((data) => {
        this.success = true;
        this.router.navigate(['/']);
      }, error => {
        this.error = true;
        this.errorMessage = error;
      });
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get apellidosEmpleado() { return this.form.get('apellidosEmpleado'); }
  get nombreEmpleado() { return this.form.get('nombreEmpleado'); }
  get tipoPermisoId()  { return this.form.get('tipoPermisoId'); }
}

