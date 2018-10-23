import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { DestinatarioService, DestinatarioResolveService } from '../../shared/destinatario.service';
import { DestinatarioEditCommand, Destinatario } from '../../shared/destinatario.model';

@Component({
    templateUrl: './destinatario-edit.component.html',
})
export class DestinatarioEditComponent implements OnInit {
    public isLoading: boolean;
    public formModel: FormGroup = this.fb.group({
        id: [''],
        nome: ['', Validators.required],
        isEmpresa: [true],
        endereco: this.fb.group(
            {
                id: ['', [Validators.required]],
                cep: ['', [Validators.required]],
                logradouro: ['', [Validators.required]],
                bairro: ['', [Validators.required]],
                municipio: ['', [Validators.required]],
                estado: ['', [Validators.required]],
                numero: ['', [Validators.required]],
                pais: ['', [Validators.required]],
            },
        ),
    });

    public formModelEmpresa: FormGroup = this.fb.group({
        cnpj: ['', Validators.required],
        razaoSocial: ['', Validators.required],
        inscricaoMunicipal: [''],
        inscricaoEstadual: [''],
    });

    public formModelPessoa: FormGroup = this.fb.group({
        cpf: ['', [Validators.required]],
    });

    private destinatario: DestinatarioEditCommand;

    constructor(private service: DestinatarioService,

        private resolveService: DestinatarioResolveService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.formModel.addControl('empresa', this.formModelEmpresa);
        this.resolveService.onChanges.take(1).subscribe((destinatario: Destinatario) => {
            this.isLoading = false;
            this.destinatario = destinatario;
            this.setFormModelControls();
        });
    }

    public save(): void {
        this.destinatario = new DestinatarioEditCommand(this.formModel.value);
        this.isLoading = true;
        this.service.edit(this.destinatario)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((response: boolean) => {
                alert('Salvo com sucesso');
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public setFormModelControls(): void {

        if (this.destinatario.cnpj !== '') {
            this.formModel.addControl('empresa', this.formModelEmpresa);
            this.formModel.removeControl('pessoa');
            this.formModel.patchValue(this.getFormModel(true));
        } else {
            this.formModel.addControl('pessoa', this.formModelPessoa);
            this.formModel.removeControl('empresa');
            this.formModel.patchValue(this.getFormModel(false));
        }
        this.formModel.updateValueAndValidity();
    }

    public getFormModel(ehEmpresa: boolean): any {
        return {
            id: this.destinatario.id,
            nome: this.destinatario.nome,
            isEmpresa: ehEmpresa,
            endereco: this.destinatario.endereco,
            empresa: {
                cnpj: this.destinatario.cnpj,
                razaoSocial: this.destinatario.razaoSocial,
                inscricaoMunicipal: this.destinatario.inscricaoMunicipal,
                inscricaoEstadual: this.destinatario.inscricaoEstadual,
            },
            pessoa: {
                cpf: this.destinatario.cpf,
            },
        };
    }
}
