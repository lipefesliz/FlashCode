import { ProdutoViewModel } from './../../produto/shared/produto.model';

export class Nfe {

    public id: number;
    public naturezaOperacao: string;
    public dataEntrada: string;
    public totalNota: string;
    public nomeDestinatario: string;
    public nomeEmitente: string;
    public nomeTransportador: string;
    public valorFrete: string;
}

export class NfeViewModel {

    public id: number;
    public naturezaOperacao: string;
    public dataEntrada: string;
    public totalNota: string;
    public nomeDestinatario: string;
    public nomeEmitente: string;
    public nomeTransportador: string;
    public produtos: ProdutoViewModel[];

    constructor(nfe: any) {
        this.id = nfe.id;
        this.naturezaOperacao = nfe.naturezaOperacao;
        this.dataEntrada = nfe.dataEntrada;
        this.totalNota = nfe.totalNota;
        this.nomeEmitente = nfe.emitente.nome;
        this.nomeDestinatario = nfe.destinatario.nome;
        this.nomeTransportador = nfe.transportador.nome;
        this.produtos = nfe.produtos;
    }
}

export class NfeRemoveCommand {

    public notasIDs: number[];

    constructor(notas: Nfe[]) {
        this.notasIDs = notas.map((p: Nfe) => p.id);
    }
}

export class NfeEditCommand {
    public id: number;
    public naturezaOperacao: string;
    public produtosId: number[] = [];
    public frete: number;
    public destinatarioId: number;
    public emitenteId: number;
    public transportadorId: number;

    constructor(nfe: any) {
        this.id = nfe.id;
        this.naturezaOperacao = nfe.naturezaOperacao;
        this.frete = nfe.frete;
        this.destinatarioId = nfe.destinatario.Id;
        this.emitenteId = nfe.emitente.Id;
        this.transportadorId = nfe.transportador.Id;
        nfe.produtos.forEach((p: any) => {
            this.produtosId.push(p.id);
        });
    }
}

export class NfeRegisterCommand {
    public naturezaOperacao: string; public frete: number;
    public destinatarioId: number;
    public emitenteId: number;
    public transportadorId: number;
    public produtoNota: ProdutoNotaRegisterCommand[];

    constructor(nfe: any) {
        this.naturezaOperacao = nfe.naturezaOperacao;
        this.frete = nfe.frete;
        this.destinatarioId = nfe.destinatarioId;
        this.emitenteId = nfe.emitenteId;
        this.transportadorId = nfe.transportadorId;
        this.produtoNota = nfe.produtosNota;
    }
}

export class ProdutoNotaRegisterCommand {
    public produtoId: number;
    public quantidade: number;
}
