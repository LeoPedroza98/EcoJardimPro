export default class Endereco {
    public cep: string;
    public logradouro: string;
    public numero: string;
    public complemento: string;
    public bairro: string;
    public cidade: string;

    constructor() {
        this.cep = '';
        this.logradouro = '';
        this.numero = '';
        this.complemento = '';
        this.bairro = '';
        this.cidade = '';
    }
}
