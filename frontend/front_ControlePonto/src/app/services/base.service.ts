import { environment } from "src/environments/environment";
import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { LocalStorageUtils } from "../utils/localstorage";
import { throwError } from "rxjs";

export abstract class BaseService {

    protected urlAutenticacao: string = environment.apiControlePonto;
    public LocalStorage = new LocalStorageUtils();

    constructor() {
    }

    protected ObterHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
    }

    protected async ObterAuthHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.LocalStorage.obterTokenUsuario()}`
            })
        };
    }
    protected extractData(response: any) {
        return response.data || {};
    }
    protected serviceError(response: Response | any) {
        let customError: string[] = [];

        if (response instanceof HttpErrorResponse) {

            if (response.statusText === "Unknown Error") {
                customError.push("Ocorreu um erro desconhecido");
                response.error.errors = customError;
            }
        }

        console.error(response);
        return throwError(response);
    }
}