export default class JwtHelper {
    private static urlBase64Decode(text: string){
        let decoded = text.replace(/-/g, '+').replace(/_/g,'/');
  
        switch (decoded.length % 4) {
            case 0:
              break;
      
            case 2:
              decoded += '==';
              break;
      
            case 3:
              decoded += '=';
              break;
      
            default:
              throw new Error('Invalid base64 url text!');
        }
  
        return decodeURIComponent((window as any).escape(window.atob(decoded)));
    }
  
    public static decodeToken(token: string){
        if (!token) return { upn: ''};
  
        const parts = token.split('.');
  
        if (parts.length !== 3) throw new Error('Token inválido!');
  
        const decoded = JwtHelper.urlBase64Decode(parts[1]);
  
        if (!decoded) throw new Error('Não foi possível decodificar o token!')
  
        return JSON.parse(decoded)
    }
  }