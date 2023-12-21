import { Contato } from "../shared";
import { Endereco } from "../shared/Endereco";
import { Projeto } from "./Projeto";
import { Servico } from "./Servico";

export class Orcamento implements Shared.IEntity {
    id: number = 0;
    nome: string = ""
    dataCriacao: string = ""
    descricao: string = ""
    projetoId: number = 0
    projeto!: Projeto;
    servicos: Servico[] = [];

    constructor(model?: Orcamento) {
        if (!model)
            return;
        this.id = model.id;
        this.nome = model.nome
        this.dataCriacao = model.dataCriacao
        this.descricao = model.descricao
        this.projetoId = model.projetoId
        this.projeto = model.projeto
        this.servicos = model.servicos
    }
}