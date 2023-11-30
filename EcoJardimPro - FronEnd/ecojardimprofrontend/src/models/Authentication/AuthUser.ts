export interface IAuthUserModel {
    id: string;
    name: string;
    sobrenome: string
    userName: string;
    role: string;
  }
  
  
  export default class AuthUserModel {
    public id: string;
  
    public name: string;
  
    public sobrenome: string;
  
    public userName: string;
  
    public role: string;
  
    constructor() {
      this.id = '';
      this.name = '';
      this.sobrenome  ='';
      this.userName = '';
      this.role = '';
    }
  }
  