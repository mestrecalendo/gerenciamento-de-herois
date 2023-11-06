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

  public lista:any = [
    {
      "superpoderes": [
        {
          "superpoder": {
            "id": 3,
            "superpoder": "Poderes de gelo",
            "descricao": "congelar coisas, raio congelante"
          },
          "heroiId": 44,
          "superpoderId": 3
        },
        {
          "superpoder": {
            "id": 4,
            "superpoder": "Psiquismo",
            "descricao": "Controlar seres com vida através da mente"
          },
          "heroiId": 44,
          "superpoderId": 4
        }
      ],
      "id": 44,
      "nome": "testeee",
      "nomeHeroi": "string",
      "dataNascimento": "2023-11-05T22:10:27",
      "altura": 0.0,
      "peso": 0.0
    },
    {
      "superpoderes": [
        {
          "superpoder": {
            "id": 2,
            "superpoder": "Magnetismo",
            "descricao": "Controle de Metais"
          },
          "heroiId": 45,
          "superpoderId": 2
        },
        {
          "superpoder": {
            "id": 4,
            "superpoder": "Psiquismo",
            "descricao": "Controlar seres com vida através da mente"
          },
          "heroiId": 45,
          "superpoderId": 4
        },
        {
          "superpoder": {
            "id": 5,
            "superpoder": "Tecnopata",
            "descricao": "Controlar aparelhos eletrônicos com a mente"
          },
          "heroiId": 45,
          "superpoderId": 5
        }
      ],
      "id": 45,
      "nome": "afs",
      "nomeHeroi": "string",
      "dataNascimento": "2023-11-05T22:10:27",
      "altura": 0.0,
      "peso": 0.0
    }
  ]


  constructor(private heroiService: HeroiService,private router: Router) { }

  ngOnInit(): void {
    this.heroiService.ListarHerois().subscribe({
      next: (data) => {
        this.listaHerois = data;
        this.getAllHerois = this.listaHerois
      },
      error: (error: any) => {
        console.log(error);
        console.log(this.lista);
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
