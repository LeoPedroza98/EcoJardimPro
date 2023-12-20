import http, { httpHeader } from "@/core/ApiConfig";
import { Service } from "../shared";

export class ProjetoService extends Service{
    
    constructor(){
        super('projeto');
    }

    public AutoComplete(q: string) {
        return http.get(`${this.GetNomeControle()}/AutoComplete`, {
            params: {
                q: q
            },
            headers: httpHeader.headers
        })
    }
}