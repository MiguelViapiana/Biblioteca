export interface Avaliacao {

    id?: string;
    estrelas: number;
    usuario: string;
}

export interface Comentario {
    id?: string;
    texto: string;
    usuario: string;

}

export interface Livro {
    titulo: string;
    autor: string;
    editora: string;
    categoria: string;
    livroId?: string;
    emprestado?: boolean;

    avaliacoes?: Avaliacao[];
    comentarios?: Comentario[];
}
