import { Component } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProdutoService } from '../shared/produto.service';
import { ProdutoRegisterCommand } from '../shared/produto.model';

@Component({
    templateUrl: './produto-create.component.html',
})
export class ProdutoCreateComponent {
    public isLoading: boolean;
    public formModel: FormGroup = this.fb.group({
        descricao: ['', Validators.required],
        valor: ['', Validators.required],
        codigoProduto: ['', Validators.required],
    });

    private produto: ProdutoRegisterCommand;

    constructor(private service: ProdutoService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public save(): void {
        this.produto = new ProdutoRegisterCommand(this.formModel.value);

        this.isLoading = true;

        this.service.add(this.produto)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((produtoId: number) => {
                alert('Salvo com sucesso');
                this.redirect();
            },
        );
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
}
