import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { TransportadorRegisterCommand } from '../../shared/transportador.model';
import { TransportadorService } from '../../shared/transportador.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './transportador-create.component.html',
})

export class TransportadorCreateComponent {

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

    private transportador: TransportadorRegisterCommand;

    constructor(private service: TransportadorService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) {
        this.setFormModelControls();
    }

    public save(): void {
        this.transportador = new TransportadorRegisterCommand(this.formModel.value);

        this.isLoading = true;

        this.service.add(this.transportador)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((transportadorId: number) => {
                alert('Salvo com sucesso');
                this.redirect();
            });
    }
    public redirect(): void {
        this.router.navigate(['../'], {relativeTo: this.route});
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
