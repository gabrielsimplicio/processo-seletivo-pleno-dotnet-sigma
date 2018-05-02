import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router'
import { Router, Route } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ToastrService } from 'ngx-toastr';
import { ModeloService } from '../../../component/service/ModeloService';
import { ModeloModels } from '../../../component/model/modelo/ModeloModels';

@Component({
  selector: 'app-modelo-atualizar',
  templateUrl: './modelo-atualizar.component.html',
  providers: [ModeloService]
})
export class ModeloAtualizarComponent implements OnInit {

  public modelo: ModeloModels

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private modeloService: ModeloService,
    private toastr: ToastrService
  ) {
    this.modelo = new ModeloModels();
    this.modelo.Id = parseInt(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit() {
    this.modeloService.getById(this.modelo.Id).subscribe(result => {
      this.modelo = result;
    }, error => {
      this.toastr.error(error);
    });
  }

  onSalvar(){
    this.modeloService.put(this.modelo.Id, this.modelo).subscribe(result => {
      this.toastr.success('Atualizado com Sucesso!');
      this.onRedirect();
    }, error => {
      this.toastr.error(error);
    });
  }

  onRedirect(): void {
    this.router.navigate(["/modelo"]);
  }
}
