import { EnderecoRegisterCommand, Endereco } from '../../../shared/endereco/endereco.model';

export class DestinatarioRemoveCommand {
    public destinatariosIDs: number[];

    constructor(destinatarios: Destinatario[]) {
        this.destinatariosIDs = destinatarios.map((d: Destinatario) => d.id);
    }
}

export class DestinatarioRegisterCommand {
    public nome: string;
    public razaoSocial: string;
    public cpf: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;
    public endereco: EnderecoRegisterCommand;

    constructor(destinatario: any) {

        if (destinatario.isEmpresa) {
            this.razaoSocial = destinatario.empresa.razaoSocial;
            this.cnpj = destinatario.empresa.cnpj;
            this.inscricaoEstadual = destinatario.empresa.inscricaoEstadual;
            this.inscricaoMunicipal = destinatario.empresa.inscricaoMunicipal;
        } else {
            this.cpf = destinatario.pessoa.cpf;
        }
        this.nome = destinatario.nome;
        this.endereco = destinatario.endereco;
    }
}

export class DestinatarioEditCommand {

    public id: number;
    public nome: string;
    public razaoSocial: string;
    public cpf: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;
    public endereco: Endereco;

    constructor(destinatario: any) {

        if (destinatario.isEmpresa) {
            this.razaoSocial = destinatario.empresa.razaoSocial;
            this.cnpj = destinatario.empresa.cnpj;
            this.inscricaoEstadual = destinatario.empresa.inscricaoEstadual;
            this.inscricaoMunicipal = destinatario.empresa.inscricaoMunicipal;
        } else {
            this.cpf = destinatario.pessoa.cpf;
        }
        this.id = destinatario.id;
        this.nome = destinatario.nome;
        this.endereco = destinatario.endereco;
        this.endereco.id = destinatario.endereco.id;
    }
}

export class DestinatarioViewModel {

}

export class Destinatario {
    public id: number;
    public nome: string;
    public razaoSocial: string;
    public cpf: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;
    public endereco: Endereco;
}
