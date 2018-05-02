import { Component, OnInit } from '@angular/core';
import { MarcaService } from '../../../component/service/MarcaService';
import { MarcaModels } from '../../../component/model/marca/MarcaModels';
import { Router } from '@angular/router';

@Component({
  selector: 'app-marca-inicial',
  templateUrl: './marca-inicial.component.html',
  providers: [MarcaService]
})
export class MarcaInicialComponent implements OnInit {
  
  public Marca: MarcaModels;
  public List: Array<MarcaModels>;

  constructor(
    private marcaService: MarcaService,
    private router: Router
  ) {
    this.List = new Array<MarcaModels>();
  }
  
  ngOnInit() {
    this.marcaService.getAll().subscribe(result => {
      this.List = result;
    }, error => {
      console.log(error);
    });
  }  
}
