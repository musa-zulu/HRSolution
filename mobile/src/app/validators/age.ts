import { FormControl, ValidatorFn } from '@angular/forms';

export class AgeValidator {

    static isValid(control: FormControl): any {

        
        if (isNaN(control.value)) {
            return {
                "not a number": true
            };
        }
        
        if (control.value % 1 !== 0) {
            return {
                "not a whole number": true
            };
        }
        const isValidAge: number  = (new Date()).getFullYear() - (new Date(control.value)).getFullYear();

        if (isValidAge < 18) {
            return {
                "too young": true
            };
        }

        if (isValidAge > 120) {
            return {
                "not realistic": true
            };
        }

        return null;
    }

}