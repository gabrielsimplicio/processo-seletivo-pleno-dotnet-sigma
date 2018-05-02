import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { MarcaInicialComponent } from './pages/marca/marca-inicial/marca-inicial.component';
import { MarcaAdicionarComponent } from './pages/marca/marca-adicionar/marca-adicionar.component';
import { ModeloAdicionarComponent } from './pages/modelo/modelo-adicionar/modelo-adicionar.component';
import { PatrimonioAtualizarComponent } from './pages/patrimonio/patrimonio-atualizar/patrimonio-atualizar.component';
import { ModeloInicialComponent } from './pages/modelo/modelo-inicial/modelo-inicial.component';
import { PatrimonioInicialComponent } from './pages/patrimonio/patrimonio-inicial/patrimonio-inicial.component';
import { PatrimonioAdicionarComponent } from './pages/patrimonio/patrimonio-adicionar/patrimonio-adicionar.component';
import { MarcaAtualizarComponent } from './pages/marca/marca-atualizar/marca-atualizar.component';
import { ModeloAtualizarComponent } from './pages/modelo/modelo-atualizar/modelo-atualizar.component';


const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'marca', component: MarcaInicialComponent },
    { path: 'adcionar-marca', component: MarcaAdicionarComponent },
    { path: 'atualizar-marca/:id', component: MarcaAtualizarComponent },

    { path: 'modelo', component: ModeloInicialComponent },
    { path: 'adcionar-modelo', component: ModeloAdicionarComponent },   
    { path: 'atualizar-modelo/:id', component: ModeloAtualizarComponent },   
    
    { path: 'patrimonio', component: PatrimonioInicialComponent },   
    { path: 'adcionar-patrimonio', component: PatrimonioAdicionarComponent },   
    { path: 'atualizar-patrimonio/:id', component: PatrimonioAtualizarComponent },   
    
    { path: 'home', component: HomeComponent }
]

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
