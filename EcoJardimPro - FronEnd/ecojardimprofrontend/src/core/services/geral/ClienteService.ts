import http, { httpHeader } from "@/core/ApiConfig";
import { Service } from "../shared";

export class ClienteService extends Service{
    
    constructor(){
        super('cliente');
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