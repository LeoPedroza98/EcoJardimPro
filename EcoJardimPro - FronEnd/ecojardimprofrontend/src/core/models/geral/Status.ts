

export class Status implements Shared.IEntity {
    id: number = 0;
    nome: string = ''

    constructor(model?: Status) {
        if (!model)
            return;
        this.id = model.id;
        this.nome = model.nome
    }
}