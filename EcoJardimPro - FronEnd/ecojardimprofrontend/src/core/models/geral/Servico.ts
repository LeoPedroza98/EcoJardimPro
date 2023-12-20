import { Orcamento } from "./Orcamento";
import { Status } from "./Status";


export class Servico implements Shared.IEntity {
    id: number = 0;
    nome: string = ""
    descricao: string = ""
    valor: number = 0
    statusId:number
    status?: Status = new Status()
    orcamentoId: number = 0
    orcamento?: Orcamento = new Orcamento()
    dataInicio?:string = "0001-01-01T00:00:00"
    dataFinalizacao?:string = "0001-01-01T00:00:00"

    constructor(model?: Servico) {
        if (!model)
            return;
        this.id = model.id;
        this.nome = model.nome
        this.descricao = model.descricao
        this.valor = model.valor
        this.statusId = model.statusId
        this.status = model.status
        this.orcamentoId = model.orcamentoId
        this.orcamento = model.orcamento
        this.dataInicio = model.dataInicio
        this.dataFinalizacao = model.dataFinalizacao
    }
}