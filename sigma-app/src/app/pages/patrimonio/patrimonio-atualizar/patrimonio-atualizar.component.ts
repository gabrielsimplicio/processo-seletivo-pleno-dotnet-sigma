import { Component, OnInit } from '@angular/core';
import { MarcaModels } from '../../../component/model/marca/MarcaModels';
import { PatrimonioService } from '../../../component/service/PatrimonioService';
import { ModeloService } from '../../../component/service/ModeloService';
import { MarcaService } from '../../../component/service/MarcaService';
import { PatrimonioModels } from '../../../component/model/patrimonio/PatriomonioModels';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Params } from '@angular/router'
import { Router, Route } from '@angular/router';

@Component({
  selector: 'app-patrimonio-atualizar',
  templateUrl: './patrimonio-atualizar.component.html',
  providers: [PatrimonioService, ModeloService, MarcaService]
})
export class PatrimonioAtualizarComponent implements OnInit {

  public patrimonio: PatrimonioModels;

  public marcas = [];

  public modelos = [];

  constructor(
    private patrimonioService: PatrimonioService,
    private modeloService: ModeloService,
    private marcaService: MarcaService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.patrimonio = new PatrimonioModels();
    this.patrimonio.Id = parseInt(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit() {

    this.marcaService.getAll().subscribe(result => {
      this.marcas = result;
    }, error => {
      console.log(error);
    });

    this.modeloService.getAll().subscribe(result => {
      this.modelos = result;
    }, error => {
      console.log(error);
    });

    this.patrimonioService.getById(this.patrimonio.Id).subscribe(result => {
      this.patrimonio = result
      this.patrimonio.Marca = null;
      this.patrimonio.Modelo = null;
    }, error => {
      this.toastr.error(error);
    });
  }

  onSalvar() {
    this.patrimonioService.put(this.patrimonio.Id, this.patrimonio).subscribe(result => {
      this.toastr.success('Atualizado com Sucesso!');
      this.onRedirect();
    }, error => {
      this.toastr.error(error);
    });
  }

  onRedirect(): void {
    this.router.navigate(["/patrimonio"]);
  }
}