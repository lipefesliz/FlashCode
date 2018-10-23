import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { TransportadorEditCommand, Transportador } from '../../shared/transportador.model';
import { TransportadorResolveService, TransportadorService } from '../../shared/transportador.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './transportador-edit.component.html',
})

export class TransportadorEditComponent  implements OnInit {
    public isLoading: boolean;
    public transportador: TransportadorEditCommand;
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

    constructor(private service: TransportadorService,
        private serviceResolver: TransportadorResolveService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) {
    }
    public ngOnInit(): void {
        this.isLoading = true;
        this.formModel.addControl('empresa', this.formModelEmpresa);
        this.serviceResolver.onChanges.take(1).subscribe((transportador: Transportador) => {
            this.isLoading = false;
            this.transportador = transportador;
            this.setFormModelControls();
        });
    }

    public save(): void {
        this.isLoading = true;
        this.transportador = new TransportadorEditCommand(this.formModel.value);
        this.service.edit(this.transportador)
            .take(1).subscribe((response: boolean) => {
                this.isLoading = false;
                alert('Salvo com sucesso');
                this.redirect();
            });
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public setFormModelControls(): void {
        if (this.transportador.cpf !== '') {
            this.formModel.addControl('pessoa', this.formModelPessoa);
            this.formModel.removeControl('empresa');
            this.formModel.patchValue(this.getFormModel(false));

        } else {
            this.formModel.addControl('empresa', this.formModelEmpresa);
            this.formModel.removeControl('pessoa');
            this.formModel.patchValue(this.getFormModel(true));
        }
        this.formModel.updateValueAndValidity();
    }

    public getFormModel(ehEmpresa: boolean): any {
        return {
            id: this.transportador.id,
            nome: this.transportador.nome,
            isEmpresa: ehEmpresa,
            endereco: this.transportador.endereco,
            empresa: {
                cnpj: this.transportador.cnpj,
                razaoSocial: this.transportador.razaoSocial,
                inscricaoMunicipal: this.transportador.inscricaoMunicipal,
                inscricaoEstadual: this.transportador.inscricaoEstadual,
            },
            pessoa: {
                cpf: this.transportador.cpf,
            },
        };
    }
}
