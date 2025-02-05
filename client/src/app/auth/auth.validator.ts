import { AbstractControl } from "@angular/forms";

export class AuthValidator {
  static hasLowerCase(control: AbstractControl) {
    if (/[a-z]/.test(control.value))
      return null;

    return { doesNotContainLowerCase: true };
  }

  static hasUpperCase(control: AbstractControl) {
    if (/[A-Z]/.test(control.value))
      return null;

    return { doesNotContainUpperCase: true };
  }

  static hasNumber(control: AbstractControl) {
    if (/[0-9]/.test(control.value))
      return null;

    return { doesNotContainNumber: true };
  }

  static hasSpecial(control: AbstractControl) {
    if (/[!@#$%&*]/.test(control.value))
      return null;

    return { doesNotContainSpecialCharacter: true };
  }
}
