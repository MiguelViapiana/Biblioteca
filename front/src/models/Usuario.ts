import { Permissao } from "./Permissao";

export interface Usuario{
     id?: string;
     nome: string;
     email: string;
     senha: string;
     permissao?: Permissao;
}