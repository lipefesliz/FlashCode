import {Pipe, PipeTransform} from '@angular/core';

@Pipe({name: 'nddDocMask'})
export class DocPipe implements PipeTransform{

    public transform (value: string): any {
       const cpfLength: number = 11;
       const cnpjLength: number = 14;
       const dois: number = 2;
       const tres: number = 3;
       const cinco: number = 5;
       const seis: number = 6;
       const oito: number = 8;
       const nove: number = 9;
       const doze: number = 12;

       if (value) {
            value = value.toString();
            if (value.length === cpfLength) {
                return value.substring(0, tres).concat('.')
                                     .concat(value.substring(tres, seis))
                                     .concat('.')
                                     .concat(value.substring(seis, nove))
                                     .concat('-')
                                     .concat(value.substring(nove, cpfLength));
            } else if (value.length === cnpjLength) {
                return value.substring(0, dois).concat('.')
                                     .concat(value.substring(dois, cinco))
                                     .concat('.')
                                     .concat(value.substring(cinco, oito))
                                     .concat('/')
                                     .concat(value.substring(oito, doze))
                                     .concat('-')
                                     .concat(value.substring(doze, cnpjLength));
            } else {
                return 'formato inválido';
            }
        }

        return value;
    }
}
