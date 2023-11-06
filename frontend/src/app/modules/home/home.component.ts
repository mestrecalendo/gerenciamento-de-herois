import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaHeroisComponent } from 'src/app/shared/lista-herois/lista-herois.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,ListaHeroisComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

}
