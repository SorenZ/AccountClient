declare class Auth {
    url: string;
    signIn(username: string, password: string): Promise<void>;
    signOut(): void;
    getAccessToken(): string;
    hasAccessToken(): boolean;
}
declare const _default: Auth;
export default _default;
