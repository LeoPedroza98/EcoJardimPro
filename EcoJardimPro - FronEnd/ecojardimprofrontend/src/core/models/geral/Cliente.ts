import { Contato } from "../shared";
import { Endereco } from "../shared/Endereco";

export class Cliente implements Shared.IEntity {
    id: number = 0;
    nome: string = ''
    sobrenome: string = ''
    documento: string = ''
    endereco: Endereco = new Endereco();
    contato: Contato = new Contato();

    constructor(model?: Cliente) {
        if (!model)
            return;
        this.id = model.id;
        this.nome = model.nome
        this.sobrenome = model.sobrenome
        this.documento = model.documento
        this.endereco = model.endereco
        this.contato = model.contato
    }
}