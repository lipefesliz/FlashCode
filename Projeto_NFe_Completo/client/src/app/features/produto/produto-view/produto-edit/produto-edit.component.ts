import { ProdutoViewModel } from './../../shared/produto.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProdutoEditCommand } from '../../shared/produto.model';
import { ProdutoService, ProdutoResolveService } from '../../shared/produto.service';

@Component({
    templateUrl: './produto-edit.component.html',
})
export class ProdutoEditComponent implements OnInit {
    public isLoading: boolean;
    public produto: ProdutoEditCommand;
    public formModel: FormGroup = this.fb.group({
        id: [''],
        descricao: ['', Validators.required],
        codigoProduto: ['', Validators.required],
        valorUnitario: ['', Validators.required],
    });

    constructor(private service: ProdutoService,
        private serviceResolver: ProdutoResolveService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.serviceResolver.onChanges.take(1).subscribe((produto: ProdutoViewModel) => {
            this.isLoading = false;
            this.produto = Object.assign(new ProdutoEditCommand(produto), produto);
            this.formModel.patchValue(this.produto);
        });
    }

    public save(): void {
        this.produto = new ProdutoEditCommand(this.formModel.value);
        this.isLoading = true;
        this.service.edit(this.produto)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((response: boolean) => {
                alert('Salvo com sucesso');
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['/produtos'], { relativeTo: this.route });
    }
}
