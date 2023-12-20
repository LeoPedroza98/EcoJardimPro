export class Endereco {

    cep: string = "";
    logradouro: string = "";
    numero: string = "";
    complemento: string = "";
    bairro: string = "";
    municipio: string = ""

    constructor(model?: Endereco) {

        if (!model)
            return;

        this.logradouro = model.logradouro;
        this.numero = model.numero;
        this.complemento = model.complemento;
        this.cep = model.cep;
        this.bairro = model.bairro;
        this.municipio = model.municipio
    }
}