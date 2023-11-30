import http from "./ApiConfig";


export class Service {
    public _nomeControle: string = '';

    constructor(nomeControle: string) {
        this._nomeControle = nomeControle;
    }

    protected GetHeader() {

        let header = {
            headers: {
                "Access-Control-Allow-Origin": "*",
            }
        };

        return header;
    }

    public GetNomeControle(): string {
        return this._nomeControle;
    }

    public Get(id: (number | string)): Promise<any> {
        return http.get(`${this._nomeControle}/${id}`, this.GetHeader())
    }

    public GetAll(): Promise<any>
    public GetAll(): Promise<any> {
        return http.get(this._nomeControle, this.GetHeader());
    }

    public Post(modelo: any): Promise<any> {
        return http.post(this._nomeControle, modelo, this.GetHeader());
    }

    public Patch(id: number, modelo: any): Promise<any> {
        return http.patch(`${this._nomeControle}/${id}`, modelo, this.GetHeader())
    }

    public Put(id: number, modelo: any): Promise<any> {
        return http.put(`${this._nomeControle}/${id}`, modelo, this.GetHeader())
    }

    public Delete(id: number) {
        return http.delete(`${this._nomeControle}/${id}`, this.GetHeader());
    }
}