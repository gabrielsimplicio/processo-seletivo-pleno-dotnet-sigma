import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router'
import { Router, Route } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { MarcaService } from '../../../component/service/MarcaService';
import { MarcaModels } from '../../../component/model/marca/MarcaModels';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-marca-atualizar',
  templateUrl: './marca-atualizar.component.html',
  providers: [MarcaService]
})
export class MarcaAtualizarComponent implements OnInit {

  public marca: MarcaModels;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private marcaService: MarcaService,
    private toastr: ToastrService

  ) {

    this.marca = new MarcaModels();
    this.marca.Id = parseInt(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit() {
    this.marcaService.getById(this.marca.Id).subscribe(result => {
      this.marca = result;
    }, error => {
      this.toastr.error(error);
    });
  }

  onSalvar(){
    this.marcaService.put(this.marca.Id, this.marca).subscribe(result => {
      this.toastr.success('Atualizado com Sucesso!');
      this.onRedirect();
    }, error => {
      this.toastr.error(error);
    });
  }

  onRedirect(): void {
    this.router.navigate(["/marca"]);
  }
}
