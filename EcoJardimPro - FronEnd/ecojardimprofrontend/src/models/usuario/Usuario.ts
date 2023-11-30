export default class Usuario{
    public nome: string;
    public sobrenome: string;
    public userName: string;
    public email: string;
    public password: string;
    public role: string;

    constructor() {
        this.nome = '';
        this.sobrenome = '';
        this.userName = '';
        this.email = '';
        this.password = '';
        this.role = '';
    }
}