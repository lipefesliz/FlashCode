import { Component } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { EmitenteService } from '../../shared/emitente.service';
import { EmitenteRegisterCommand } from '../../shared/emitente.model';

@Component({
    templateUrl: './emitente-create.component.html',
})
export class EmitenteCreateComponent {
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

    private emitente: EmitenteRegisterCommand;

    constructor(private service: EmitenteService, private fb: FormBuilder, private router: Router) {
        this.setFormModelControls();
    }

    public save(): void {
        this.emitente = new EmitenteRegisterCommand(this.formModel.value);

        this.isLoading = true;

        this.service.add(this.emitente)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((emitenteId: number) => {
                alert('Salvo com sucesso');
                this.redirect();
            });
    }
    public redirect(): void {
        this.router.navigate(['../']);
    }

    public onDocumento(): void {
        this.isEmpresa = !this.isEmpresa;
        this.setFormModelControls();
    }

    public setFormModelControls(): void {
        if (this.isEmpresa) {
            this.formModel.patchValue({ isEmpresa: true });
            this.formModel.addControl('empresa', this.formModelEmpresa);
            this.formModel.removeControl('pessoa');
        } else {
            this.formModel.patchValue({ isEmpresa: false });
            this.formModel.addControl('pessoa', this.formModelPessoa);
            this.formModel.removeControl('empresa');
        }
        this.formModel.updateValueAndValidity();
    }
}
