export class Contato {
    nome: string;
    telefone: string;
    celular: string;
    email: string;

    constructor(model?: Contato) {

        if (!model)
            return;
        this.nome = model.nome
        this.telefone = model.telefone
        this.celular = model.celular
        this.email = model.email
    }
}