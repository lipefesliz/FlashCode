export class ProdutoRegisterCommand {
    public descricao: string;
    public valor: number;
    public codigoProduto: number;

    constructor(produto: any) {
        this.descricao = produto.descricao;
        this.valor = produto.valor;
        this.codigoProduto = produto.codigoProduto;
    }
}

export class ProdutoRemoveCommand {
    public produtosIds: number[];

    constructor(produtos: Produto[]) {
        this.produtosIds = produtos.map((p: Produto) => p.id);
    }
}

export class ProdutoEditCommand {

    public id: number;
    public descricao: string;
    public valor: number;
    public codigoProduto: number;

    constructor(produto: any) {
        this.id = produto.id;
        this.descricao = produto.descricao;
        this.valor = produto.valorUnitario;
        this.codigoProduto = produto.codigoProduto;
    }
}

export class ProdutoViewModel {
    public id: number;
    public descricao: string;
    public codigoProduto: number;
    public valorUnitario: number;
    public ICMS: number;
    public IPI: number;
    public valorTotal: number;
}

export class Produto {
    public id: number;
    public descricao: string;
    public codigoProduto: number;
    public valor: number;
    public quantidade: number;
}
