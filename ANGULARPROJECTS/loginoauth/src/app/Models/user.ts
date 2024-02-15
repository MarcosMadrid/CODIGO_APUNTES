export default class User{
    private userName : string;
    private password : string;
    
    constructor(userName ?: string  , password ?: string ){
        this.userName = userName ?? '';
        this.password = password ?? '';
    }

    Get_userName():string{
        return(this.userName);
    }    
    Get_paassword():string{
        return(this.password);
    }

    Set_userName(userName : string){
        this.userName = userName;
    }    
    Set_paassword(password : string){
        this.password = password;
    }
}