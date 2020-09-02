/// <reference types="react" />
import { IDotnetifyVM } from 'dotnetify';
export interface ISidebarProps {
    vm: IDotnetifyVM;
    logoTitle: string;
    open: boolean;
    userName: string;
    userAvatarUrl: string;
    menus: any[];
}
export default function Sidebar({ vm, logoTitle, open, userName, userAvatarUrl, menus }: ISidebarProps): JSX.Element;
