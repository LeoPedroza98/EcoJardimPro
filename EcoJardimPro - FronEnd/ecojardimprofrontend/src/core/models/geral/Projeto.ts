import { Cliente } from "./Cliente";
import { Status } from "./Status";


export class Projeto implements Shared.IEntity {
    id: number = 0;
    nome: string = "";
    descricao: string = "";
    statusId: number = 0;
    status: Status = new Status()
    prazoInicial:string = '';
    prazoFinal!: string;
    valor: number = 0;
    clienteId: number = 0;
    cliente!: Cliente;


    constructor(model?: Projeto ) {
        if (!model)
            return;
        this.id = model.id
        this.nome = model.nome
        this.descricao = model.descricao
        this.statusId = model.statusId
        this.status = model.status
        this.prazoInicial = model.prazoInicial
        this.prazoFinal = model.prazoFinal
        this.valor = model.valor
        this.clienteId = model.clienteId
        this.cliente = model.cliente
    }
}