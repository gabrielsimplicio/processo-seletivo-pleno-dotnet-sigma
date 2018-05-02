import { Component, OnInit } from '@angular/core';
import { MarcaModels } from '../../../component/model/marca/MarcaModels';
import { PatrimonioService } from '../../../component/service/PatrimonioService';
import { ModeloService } from '../../../component/service/ModeloService';
import { MarcaService } from '../../../component/service/MarcaService';
import { PatrimonioModels } from '../../../component/model/patrimonio/PatriomonioModels';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patrimonio-adicionar',
  templateUrl: './patrimonio-adicionar.component.html',
  providers: [PatrimonioService, ModeloService, MarcaService]
})
export class PatrimonioAdicionarComponent implements OnInit {

  public patrimonio: PatrimonioModels;

  public marcas = []

  public modelos = []

  constructor(
    private patrimonioService: PatrimonioService,
    private modeloService: ModeloService,
    private marcaService: MarcaService,
    private router: Router,
    private toastr: ToastrService
  ) {

    this.patrimonio = new PatrimonioModels();
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
  }

  onSalvar() {
    this.patrimonioService.post(this.patrimonio).subscribe(result =>{
      this.toastr.success('Criado com sucesso!');
      this.onRedirect();
    });
  }

  onRedirect(): void {
    this.router.navigate(["/patrimonio"]);
  }
}
