import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatrimonioService } from '../../../component/service/PatrimonioService';
import { PatrimonioModels } from '../../../component/model/patrimonio/PatriomonioModels';

@Component({
  selector: 'app-patrimonio-inicial',
  templateUrl: './patrimonio-inicial.component.html',
  providers: [PatrimonioService]
})
export class PatrimonioInicialComponent implements OnInit {

  public list: Array<PatrimonioModels>

  constructor(private router: Router, private patrimonioService: PatrimonioService) 
  { 
    this.list = new Array<PatrimonioModels>();
  }

  ngOnInit() {
    this.patrimonioService.getAll().subscribe(result => {
      this.list = result;
    }, error => {
      console.log(error);
    });
  }
}

