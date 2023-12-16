import Orcamento from "../orcamento/Orcamento"
import Status from "../status/Status"

export default class Servico{
    public id: number
    public nome: string
    public descricao: string
    public valor: number
    public statusId:number
    public status?: Status
    public orcamentoId: number
    public orcamento?: Orcamento
    public dataInicio?:string
    public dataFinalizacao?:string
    constructor() {
        this.id = 0
        this.nome = ''
        this.descricao = ''
        this.valor = 0
        this.statusId = 0
        this.status = new Status()
        this.orcamentoId = 0
        this.orcamento = new Orcamento()
        this.dataInicio = '0001-01-01T00:00:00'
        this.dataFinalizacao = '0001-01-01T00:00:00'
    }
}