import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { MarcaService } from '../../../component/service/MarcaService';
import { MarcaModels } from '../../../component/model/marca/MarcaModels';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-marca-adicionar',
  templateUrl: './marca-adicionar.component.html',
  providers: [MarcaService]
})
export class MarcaAdicionarComponent implements OnInit {

  public marca: MarcaModels

  constructor(
    private marcaService: MarcaService,
    private router: Router,
    private toastr: ToastrService
  ) {

    this.marca = new MarcaModels();

  }

  ngOnInit() {
  }

  onSalvar() {
    this.marcaService.post(this.marca).subscribe(result => {     
      this.toastr.success('Criado com sucesso!');
      this.onRedirect();
    }, error => {
      this.toastr.error(error);
    });

  }

  onRedirect(): void {
    this.router.navigate(["/marca"]);
  }
}