import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { EmitenteEditCommand, Emitente } from '../../shared/emitente.model';
import { EmitenteService, EmitenteResolveService } from '../../shared/emitente.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './Emitente-edit.component.html',
    styles: ['./_styles.scss'],

})
export class EmitenteEditComponent implements OnInit {
    public isLoading: boolean;
    public emitente: EmitenteEditCommand;
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

    constructor(private service: EmitenteService,
        private serviceResolver: EmitenteResolveService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) {
    }
    public ngOnInit(): void {
        this.isLoading = true;
        this.formModel.addControl('empresa', this.formModelEmpresa);
        this.serviceResolver.onChanges.take(1).subscribe((emitente: Emitente) => {
            this.isLoading = false;
            this.emitente = emitente;
            this.setFormModelControls();
        });
    }

    public save(): void {
        this.isLoading = true;
        this.emitente = new EmitenteEditCommand(this.formModel.value);
        this.service.edit(this.emitente)
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
        if (this.emitente.cpf !== '') {
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
            id: this.emitente.id,
            nome: this.emitente.nome,
            isEmpresa: ehEmpresa,
            endereco: this.emitente.endereco,
            empresa: {
                cnpj: this.emitente.cnpj,
                razaoSocial: this.emitente.razaoSocial,
                inscricaoMunicipal: this.emitente.inscricaoMunicipal,
                inscricaoEstadual: this.emitente.inscricaoEstadual,
            },
            pessoa: {
                cpf: this.emitente.cpf,
            },
        };
    }
}
