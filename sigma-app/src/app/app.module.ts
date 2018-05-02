import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routing } from './app.routing';

import { NavBarComponent } from './component/shared/nav-bar/nav-bar.component';
import { ContentComponent } from './component/shared/content/content.component';

import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule, ToastContainerModule } from 'ngx-toastr';

import { HomeComponent } from './pages/home/home.component';
import { MarcaInicialComponent } from './pages/marca/marca-inicial/marca-inicial.component';
import { MarcaAdicionarComponent } from './pages/marca/marca-adicionar/marca-adicionar.component';
import { ModeloAdicionarComponent } from './pages/modelo/modelo-adicionar/modelo-adicionar.component';
import { ModeloInicialComponent } from './pages/modelo/modelo-inicial/modelo-inicial.component';
import { PatrimonioInicialComponent } from './pages/patrimonio/patrimonio-inicial/patrimonio-inicial.component';
import { PatrimonioAdicionarComponent } from './pages/patrimonio/patrimonio-adicionar/patrimonio-adicionar.component';
import { MarcaAtualizarComponent } from './pages/marca/marca-atualizar/marca-atualizar.component';
import { ModeloAtualizarComponent } from './pages/modelo/modelo-atualizar/modelo-atualizar.component';
import { PatrimonioAtualizarComponent } from './pages/patrimonio/patrimonio-atualizar/patrimonio-atualizar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ContentComponent,
    HomeComponent,
    MarcaInicialComponent,
    MarcaAdicionarComponent,    
    ModeloInicialComponent,
    ModeloAdicionarComponent,
    PatrimonioInicialComponent,
    PatrimonioAdicionarComponent,
    MarcaAtualizarComponent,
    ModeloAtualizarComponent,
    PatrimonioAtualizarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    Routing,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


