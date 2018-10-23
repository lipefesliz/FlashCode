import { Endereco, EnderecoRegisterCommand } from '../../../shared/endereco/endereco.model';

export class Transportador {
    public id: number;
    public nome: string;
    public razaoSocial: string;
    public cpf: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public cidade: string;
    public inscricaoMunicipal: string;
    public endereco: Endereco;
}

export class TransportadorRemoveCommand {

    public transportadoresIDs: number[];

    constructor(transportador: Transportador[]) {
        this.transportadoresIDs = transportador.map((p: Transportador) => p.id);
    }
}

export class TransportadorEditCommand {
    public id: number;
    public nome: string;
    public razaoSocial: string;
    public cpf: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;
    public endereco: Endereco;

    constructor(emitente: any) {

        if (emitente.isEmpresa) {
            this.razaoSocial = emitente.empresa.razaoSocial;
            this.cnpj = emitente.empresa.cnpj;
            this.inscricaoEstadual = emitente.empresa.inscricaoEstadual;
            this.inscricaoMunicipal = emitente.empresa.inscricaoMunicipal;
        } else {
            this.cpf = emitente.pessoa.cpf;
        }
        this.id = emitente.id;
        this.nome = emitente.nome;
        this.endereco = emitente.endereco;
        this.endereco.id = emitente.endereco.id;
    }
}

export class TransportadorRegisterCommand {

    public nome: string;
    public cpf: string;
    public endereco: EnderecoRegisterCommand;
    public razaoSocial: string;
    public cnpj: string;
    public inscricaoEstadual: string;
    public inscricaoMunicipal: string;

    constructor(emitente: any) {
        if (emitente.isEmpresa) {
            this.razaoSocial = emitente.empresa.razaoSocial;
            this.cnpj = emitente.empresa.cnpj;
            this.inscricaoEstadual = emitente.empresa.inscricaoEstadual;
            this.inscricaoMunicipal = emitente.empresa.inscricaoMunicipal;
        } else {
            this.cpf = emitente.pessoa.cpf;
        }
        this.nome = emitente.nome;
        this.endereco = emitente.endereco;
    }
}
