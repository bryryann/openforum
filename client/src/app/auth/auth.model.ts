export type AuthView = 'login' | 'register' | undefined;

export function isAuthView(val: string | undefined): val is AuthView {
  return ['login', 'register', undefined].indexOf(val) !== -1;
}
