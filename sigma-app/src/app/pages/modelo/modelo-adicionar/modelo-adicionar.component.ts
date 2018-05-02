import { Component, OnInit } from '@angular/core';
import { ModeloService } from '../../../component/service/ModeloService';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ModeloModels } from '../../../component/model/modelo/ModeloModels';

@Component({
  selector: 'app-modelo-adicionar',
  templateUrl: './modelo-adicionar.component.html',
  providers: [ModeloService]
})
export class ModeloAdicionarComponent implements OnInit {

  public modelo: ModeloModels

  constructor(
    private modeloService: ModeloService,
    private router: Router,
    private toastr: ToastrService
  ) { 
    this.modelo = new  ModeloModels();
  }

  ngOnInit() {
  }

  onSalvar() {
    this.modeloService.post(this.modelo).subscribe(result => {
      this.toastr.success('Criado com sucesso!');
      this.onRedirect();
    }, error => {
      this.toastr.error(error);
    });
  }

  onRedirect(): void {
    this.router.navigate(["/modelo"]);
  }
}