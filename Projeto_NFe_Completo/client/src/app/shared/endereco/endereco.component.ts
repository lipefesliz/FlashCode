import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'ndd-app-address',
    templateUrl: './endereco.component.html',
})
export class EnderecoComponent {
    @Input() public formModel: FormGroup;

}
