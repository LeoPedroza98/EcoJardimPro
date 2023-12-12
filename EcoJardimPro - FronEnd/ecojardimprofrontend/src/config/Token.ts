import JwtHelper from '@/helpers/JwtHelper';
import AuthUser,{IAuthUserModel} from '../models/Authentication/AuthUser'
import Cookies from 'js-cookie';
import { parsePermissions } from './Permission';

export function setToken(token: string){
    Cookies.set('@ecojardimPro:token', token);
}

export function getToken() : string{
    return Cookies.get('@ecoJardimPro:token') || '';
}

export function removeToken(){
    Cookies.remove('@ecoJardimPro:token');
}

export function setModoNoturno(modoNoturno: string){
    Cookies.set('@ecoJardimPro:modoNoturno', modoNoturno);
}

export function getModoNoturno() : boolean{
    return Cookies.get('@ecoJardimPro:modoNoturno') == 'true' || false;
}

export function removeModoNoturno(){
    Cookies.remove('@ecoJardimPro:modoNoturno');
}

export function decode(token: string): IAuthUserModel  {
    if (token.length) {
      const decoded = JwtHelper.decodeToken(token);
  
      const data: IAuthUserModel = {
        id: decoded.userid,
        name: decoded.name,
        sobrenome: decoded.sobrenome,
        userName: decoded.username,
        role: decoded.role,
        permissions: decoded.permissions,
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