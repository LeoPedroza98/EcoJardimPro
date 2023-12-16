import Projeto from "../projeto/Projeto";
import Servico from "../servico/Servico";

export default class Orcamento {
    public id : number;
    public dataCriacao: string
    public descricao: string
    public projetoId: number
    public projeto:Projeto
    public servicos: Servico[] = [];
    constructor() {
        this.id = 0
        this.dataCriacao = '0001-01-01T00:00:00'
        this.descricao = ''
        this.projetoId = 0
        this.projeto = new Projeto()
        this.servicos = []
    }

}