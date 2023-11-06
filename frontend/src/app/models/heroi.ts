import { Superpoderes } from "./superpoderes";

export class Heroi{
  id?: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento: Date;
  Altura: number;
  Peso: number;
  Superpoderes: Array<Superpoderes>
}
