export class LocalStorageUtils {
    
    public obterUsuario() {
        let usuario = localStorage.getItem('usuario');
        if(usuario != null)
            return JSON.parse(usuario);
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.token);
        this.salvarUsuario(response.nmUsuario);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('token');
        localStorage.removeItem('usuario');
    }

    public obterTokenUsuario(): string | null {
        return localStorage.getItem('token');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('token', token);
    }

    public salvarUsuario(user: string) {
        localStorage.setItem('usuario', JSON.stringify(user));
    }

}