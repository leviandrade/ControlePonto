import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { catchError, map } from "rxjs/operators";
import { BaseService } from "src/app/services/base.service";
import { environment } from "src/environments/environment";
import { Login } from "../models/login";

@Injectable()
export class LoginService extends BaseService {
    protected urlControlePonto: string = environment.apiControlePonto;

    constructor(private http: HttpClient) { super(); }

    login(login: Login): Observable<Login> {
        let response = this.http
            .post(this.urlControlePonto + 'api/Autenticacao/Login', login)
            .pipe(
                map(this.extractData),
                catchError(this.serviceError));

        return response;
    }
}