import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { HeroiService } from 'src/app/services/heroi.service';
import { Router } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import { SearchInputComponent } from '../search-input/search-input.component';

@Component({
  selector: 'app-lista-herois',
  standalone: true,
  imports: [CommonModule,SearchInputComponent,MatCardModule,MatFormFieldModule,MatButtonModule,MatDividerModule],
  templateUrl: './lista-herois.component.html',
  styleUrls: ['./lista-herois.component.scss']
})
export class ListaHeroisComponent {
  private listaHerois?: any;
  public getAllHerois: any;

  constructor(private heroiService: HeroiService,private router: Router) { }

  ngOnInit(): void {
    this.heroiService.ListarHerois().subscribe({
      next: (data) => {
        this.listaHerois = data;
        this.getAllHerois = this.listaHerois
      },
      error: (error: any) => {
        console.log(error);
      }
    });
  }


  removeHeroi(id: number) {
    this.heroiService.ExcluirHeroi(id).subscribe({
      next: () => {
        this.ngOnInit();

      },
      error: (error: any) => {

      }
    })
  }

  editarHeroi(idHeroi: number){
    this.router.navigate(['/cadastrar-heroi',{id: idHeroi} ])
  }

  public getSearch(value: string){
    const filter = this.listaHerois?.filter( (res: any ) => {
      return !res.nome.toLowerCase().indexOf(value.toLowerCase());
    });

    this.getAllHerois = filter;
  }
}
