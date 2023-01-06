import { Injectable } from "@angular/core";
import { CanActivate, CanDeactivate, Router } from "@angular/router";
import { LocalStorageUtils } from "../utils/localstorage";

@Injectable()
export class ContaGuard implements CanActivate {
    
    localStorageUtils = new LocalStorageUtils();

    constructor(private router: Router){}

    canActivate() {
        if(this.localStorageUtils.obterTokenUsuario() == null){
            this.router.navigate(['/home']);
        }

        return true;
    }
    
}