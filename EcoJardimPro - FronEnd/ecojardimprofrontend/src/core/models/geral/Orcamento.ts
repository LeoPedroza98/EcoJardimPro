import { Contato } from "../shared";
import { Endereco } from "../shared/Endereco";
import { Projeto } from "./Projeto";
import { Servico } from "./Servico";

export class Orcamento implements Shared.IEntity {
    id: number = 0;
    dataCriacao: string = '0001-01-01T00:00:00'
    descricao: string = ''
    projetoId: number = 0
    projeto: Projeto = new Projeto();
    public servicos: Servico[] = [];

    constructor(model?: Orcamento) {
        if (!model)
            return;
        this.id = model.id;
        this.dataCriacao = model.dataCriacao
        this.descricao = model.descricao
        this.projetoId = model.projetoId
        this.projeto = model.projeto
        this.servicos = model.servicos
    }
}