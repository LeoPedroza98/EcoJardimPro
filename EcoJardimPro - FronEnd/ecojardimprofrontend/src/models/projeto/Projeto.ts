
import Cliente from "../cliente/Cliente";
import Status from "../status/Status";


export default class Projeto{
    public id: number;
    public nome: string;
    public descricao: string;
    public statusId!: number;
    public status: Status
    public prazoInicial:string;
    public prazoFinal: string;
    public valor: number;
    public clienteId: number;
    public cliente: Cliente;

    constructor() {
        this.id = 0
        this.nome = ''
        this.descricao = ''
        this.statusId = 0
        this.prazoInicial = '0001-01-01T00:00:00'
        this.prazoFinal = '0001-01-01T00:00:00'
        this.valor = 0
        this.clienteId = 0
        this.cliente = new Cliente()
    }
}