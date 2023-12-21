import http, { httpHeader } from "@/core/ApiConfig";
import { Service } from "../shared";

export class OrcamentoService extends Service{
    
    constructor(){
        super('orcamento');
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