import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {NgIf} from '@angular/common';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatNativeDateModule} from '@angular/material/core';
import {MatCardModule} from '@angular/material/card';
import { Heroi } from 'src/app/models/heroi';
import { Superpoderes } from 'src/app/models/superpoderes';
import { HeroiService } from 'src/app/services/heroi.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SuperpoderesService } from 'src/app/services/superpoderes.service';
import { idade } from './validatorData';
import {MatSelectModule} from '@angular/material/select';

@Component({
  selector: 'app-formulario',
  standalone: true,
  imports: [CommonModule,MatDatepickerModule, MatNativeDateModule,MatFormFieldModule, MatSelectModule,MatCardModule,MatInputModule, FormsModule,ReactiveFormsModule, NgIf, MatButtonModule, MatIconModule],
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit {
  HeroiId: number;
  HeroiForm!: FormGroup;
  listaSuperpoderes?: Superpoderes[];
  startDate = new Date(1990, 0, 1);

  constructor(private superpoderesService: SuperpoderesService, private heroiService: HeroiService, private router: ActivatedRoute, private route: Router, private formBuilder: FormBuilder) {
    this.superpoderesService.ListarSuperpoderes().subscribe({
      next: (data) => {
        this.listaSuperpoderes = data;
      },
      error: (error: any) => {
        console.log(error);
      }
    }
    )
  }

  ngOnInit(): void {
    const _id = this.router.snapshot.paramMap.get('id');

    this.HeroiForm = this.formBuilder.group({
      nome: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(120)]],
      nomeHeroi: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(120)]],
      dataNascimento: ['', [Validators.required, idade]],
      altura: ['', [Validators.required, Validators.min(0) ]],
      peso: ['', [Validators.required, Validators.min(0)]],
      superpoderes: ['', [Validators.required]],
    })

    if (_id) {
      this.HeroiId = parseInt(_id);
      this.heroiService.GetHeroiById(this.HeroiId).subscribe({
        next: (data) => {
          let listSuperpoder: any[] = []

          for (let index = 0; index < data.superpoderes.length; index++) {
            const element = data.superpoderes[index];
            let id = element.superpoder.id.toString()
            listSuperpoder.push(id)
          }

          this.HeroiForm.get('nome')?.setValue(data.nome);
          this.HeroiForm.get('nomeHeroi')?.setValue(data.nomeHeroi);
          this.HeroiForm.get('dataNascimento')?.setValue(new Date(data.dataNascimento));
          this.HeroiForm.get('altura')?.setValue(data.altura);
          this.HeroiForm.get('peso')?.setValue(data.peso);
          this.HeroiForm.get('superpoderes')?.setValue(listSuperpoder);
        },
        error: (error: any) => {
        console.log(error)
        }
      });
    }
  }

  submitForm() {
    if (this.HeroiId) {
      this.editar()
    } else {
      this.cadastrar()
    }
  }

  cadastrar() {
    if (!this.HeroiForm.valid) {
      return
    }

    let listSuperpoder: { superpoderId: number; }[] = []
    let superpoderesForm = this.HeroiForm.get('superpoderes')?.value

    for (let index = 0; index < superpoderesForm.length; index++) {
      const element = superpoderesForm[index];
      listSuperpoder.push({superpoderId: element})
    }

    const novoHeroi: Heroi = {
      nome: this.HeroiForm.get('nome')?.value,
      nomeHeroi: this.HeroiForm.get('nomeHeroi')?.value,
      dataNascimento: this.HeroiForm.get('dataNascimento')?.value,
      altura: parseFloat(this.HeroiForm.get('altura')?.value),
      peso: parseFloat(this.HeroiForm.get('peso')?.value),
      superpoderes: listSuperpoder,
    };

    console.log(novoHeroi);
  this.heroiService.cadastrarNovoHeroi(novoHeroi).subscribe({
      complete: () => {
        this.route.navigate(['/'])

      },
      error: (error: any) => {
        console.log(error);

      }
    }
    )
  }

  editar() {
    if (!this.HeroiForm.valid) {
      return
    }

    let listSuperpoder: { superpoderId: number; }[] = []
    let superpoderesForm = this.HeroiForm.get('superpoderes')?.value

    for (let index = 0; index < superpoderesForm.length; index++) {
      const element = superpoderesForm[index];
      listSuperpoder.push({superpoderId: element})
    }

    const novoHeroi: Heroi = {
      nome: this.HeroiForm.get('nome')?.value,
      nomeHeroi: this.HeroiForm.get('nomeHeroi')?.value,
      dataNascimento: this.HeroiForm.get('dataNascimento')?.value,
      altura: parseFloat(this.HeroiForm.get('altura')?.value),
      peso: parseFloat(this.HeroiForm.get('peso')?.value),
      superpoderes: listSuperpoder,
    };

    console.log(novoHeroi);

    this.heroiService.AtualizarHeroi(this.HeroiId, novoHeroi).subscribe({
      complete: () => {
        this.route.navigate(['/'])

      },
      error: (error: any) => {

      }
    }
    )
  }

}
