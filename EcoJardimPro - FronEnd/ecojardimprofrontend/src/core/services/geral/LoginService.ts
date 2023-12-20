import { Login } from "@/core/models/Authentication";
import { Service } from "../shared";

export class LoginService extends Service{    
    constructor(){
        super('login');
    }
}