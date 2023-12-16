import Contato from "../objetosValor/Contato";
import Endereco from "../objetosValor/Endereco";
import Projeto from "../projeto/Projeto";

export default class Cliente{
    public id: number;
    public nome: string;
    public sobrenome: string;
    public documento: string;
    public endereco!: Endereco;
    public contato!: Contato;
    public projetos: Projeto[] = [];

    constructor() {
        this.id = 0
        this.nome = ''
        this.sobrenome = ''
        this.documento = ''
        this.endereco = new Endereco();
        this.contato = new Contato();
        this.projetos = []
    }
}