export interface IAuthUserModel {
    id: string;
    name: string;
    sobrenome: string
    userName: string;
    role: string;
    permissions: Array<string>;
  }
  
  
  export default class AuthUserModel {
    public id: string;
  
    public name: string;
  
    public sobrenome: string;
  
    public userName: string;
  
    public role: string;

    permissions: Array<string>;

  
    constructor() {
      this.id = '';
      this.name = '';
      this.sobrenome  ='';
      this.userName = '';
      this.role = '';
      this.permissions = [];
    }
  }