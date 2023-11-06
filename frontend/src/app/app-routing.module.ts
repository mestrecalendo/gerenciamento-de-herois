import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { CadastroComponent } from './modules/cadastro/cadastro.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'cadastrar-heroi',
    component: CadastroComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes),HttpClientModule,FormsModule,
    ReactiveFormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
