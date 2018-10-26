import { ProdutoViewModel, Produto } from './../../produto/shared/produto.model';
import { Destinatario } from '../../destinatario/shared/destinatario.model';
import { Emitente } from '../../emitente/shared/emitente.model';
import { Transportador } from '../../transportador/shared/transportador.model';

export class Nfe {

    public id: number;
    public naturezaOperacao: string;
    public dataEntrada: string;
    public totalNota: string;
    public destinatario: Destinatario;
    public emitente: Emitente;
    public transportador: Transportador;
    public valorFrete: string;
    public produtos: Produto[];

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

        if (nfe.valor) {
            this.frete = nfe.valor.frete;
            this.destinatarioId = nfe.destinatario.id;
            this.emitenteId = nfe.emitente.id;
            this.transportadorId = nfe.transportador.id;
            nfe.produtos.forEach((p: any) => {
                this.produtosId.push(p.id);
            });
        } else {
            this.frete = nfe.frete;
            this.destinatarioId = nfe.destinatarioId;
            this.emitenteId = nfe.emitenteId;
            this.transportadorId = nfe.transportadorId;
        }
    }
}

export class NfeRegisterCommand {
    public naturezaOperacao: string; public frete: number;
    public destinatarioId: number;
    public emitenteId: number;
    public transportadorId: number;
    public produtoNota: ProdutoNotaCommand[];

    constructor(nfe: any) {
        this.naturezaOperacao = nfe.naturezaOperacao;
        this.frete = nfe.frete;
        this.destinatarioId = nfe.destinatarioId;
        this.emitenteId = nfe.emitenteId;
        this.transportadorId = nfe.transportadorId;
        this.produtoNota = nfe.produtosNota;
    }
}

export class ProdutoNotaCommand {
    public notaFiscalId: number;
    public produtoId: number;
    public quantidade: number;
}

export class ProdutoNotaRemoveCommand {
    public notaId: number;
    public produtosIds: number[];

    constructor(notaFiscalId: number, produtosNota: any[]) {
        this.notaId = notaFiscalId;
        this.produtosIds = produtosNota.map((p: any) => p.id);
    }
}
