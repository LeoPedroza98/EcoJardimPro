export class Usuario {

    nome: string = "";
    sobrenome: string = "";
    userName: string = "";
    email: string = "";
    password: string = "";
    role: string = "";

    constructor(model?: Usuario){

        if(!model)
            return;

        this.nome = model.nome;
        this.sobrenome = model.sobrenome;
        this.userName = model.userName;
        this.email = model.email;
        this.password = model.password;
        this.role = model.role;
    }

}
