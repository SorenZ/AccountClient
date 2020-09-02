/// <reference types="react" />
export interface ILoginPageProps {
    onAuthenticated: () => void;
}
export default function LoginPage({ onAuthenticated }: ILoginPageProps): JSX.Element;
