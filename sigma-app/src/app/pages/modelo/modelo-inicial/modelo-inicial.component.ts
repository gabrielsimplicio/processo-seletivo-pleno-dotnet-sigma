import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModeloService } from '../../../component/service/ModeloService';
import { ModeloModels } from '../../../component/model/modelo/ModeloModels';

@Component({
  selector: 'app-modelo-inicial',
  templateUrl: './modelo-inicial.component.html',
  providers: [ModeloService]
})
export class ModeloInicialComponent implements OnInit {

  public Modelo: ModeloModels;
  public List: Array<ModeloModels>;

  constructor(
    private modeloService: ModeloService,
    private router: Router
  ) {
    this.List = new Array<ModeloModels>();
  }
  ngOnInit() {
    this.modeloService.getAll().subscribe(result => {
      this.List = result;
    }, error => {
      console.log(error);
    });
  }
}