export default class TokenModel{
    public autenticado: boolean;
    public dataCriacao: string;
    public dataExpiracao: string;
    public mensagem: string;
    public tokenDeAcesso: string;
    constructor() {
        this.autenticado = false;
        this.dataCriacao = '';
        this.dataExpiracao = '';
        this.mensagem = '';
        this.tokenDeAcesso = '';
    }

}