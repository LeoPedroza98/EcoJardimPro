import JwtHelper from '@/helpers/JwtHelper';
import AuthUser,{IAuthUserModel} from '../models/Authentication/AuthUser'
import Cookies from 'js-cookie';
import { parsePermissions } from './Permission';

export function setToken(token: string){
    Cookies.set('@medSystemCloud:token', token);
}

export function getToken() : string{
    return Cookies.get('@medSystemCloud:token') || '';
}

export function removeToken(){
    Cookies.remove('@medSystemCloud:token');
}

export function setModoNoturno(modoNoturno: string){
    Cookies.set('@medSystemCloud:modoNoturno', modoNoturno);
}

export function getModoNoturno() : boolean{
    return Cookies.get('@medSystemCloud:modoNoturno') == 'true' || false;
}

export function removeModoNoturno(){
    Cookies.remove('@medSystemCloud:modoNoturno');
}

export function decode(token: string): IAuthUserModel  {
    if (token.length) {
      const decoded = JwtHelper.decodeToken(token);
  
      const permissions: Array<string> = parsePermissions(decoded.permissions);
  
      const data: IAuthUserModel = {
        id: decoded.userid,
        name: decoded.name,
        sobrenome: decoded.sobrenome,
        userName: decoded.username,
        role: decoded.role,
        permissions,
      };
      return data;
    }
  
    return new AuthUser();
}

export function getUserPermissions(token: string): string[] {
    const decodedToken: any = JwtHelper.decodeToken(token);
    const permissions: Array<string> = parsePermissions(decodedToken.permissions); 
  
    return permissions;
}