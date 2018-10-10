import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { DestinatarioRegisterCommand } from '../../shared/destinatario.model';

import { DestinatarioService } from '../../shared/destinatario.service';

@Component({
    templateUrl: './destinatario-create.component.html',
})
export class DestinatarioCreateComponent {
    public isLoading: boolean;
    public isEmpresa: boolean = true;
    public formModel: FormGroup = this.fb.group({
        nome: ['', Validators.required],
        isEmpresa: [true],
        endereco: this.fb.group(
            {
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

    private destinatario: DestinatarioRegisterCommand;

    constructor(private service: DestinatarioService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) {

        this.setFormModelControls();
    }

    public save(): void {
        this.destinatario = new DestinatarioRegisterCommand(this.formModel.value);
        this.isLoading = true;
        this.service.add(this.destinatario)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((destinatarioId: number) => {
                alert('Salvo com sucesso');
                this.redirect();
            });
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onJuridica(): void {
        this.isEmpresa = !this.isEmpresa;
        this.setFormModelControls();
    }

    public setFormModelControls(): void {

        if (this.isEmpresa) {
            this.formModel.addControl('empresa', this.formModelEmpresa);
            this.formModel.removeControl('pessoa');
            this.formModel.patchValue({ isEmpresa: true });
        } else {
            this.formModel.addControl('pessoa', this.formModelPessoa);
            this.formModel.removeControl('empresa');
            this.formModel.patchValue({ isEmpresa: false });
        }
        this.formModel.updateValueAndValidity();
    }
}
