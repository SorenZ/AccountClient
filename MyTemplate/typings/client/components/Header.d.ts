import * as React from 'react';
export interface IHeaderProps {
    styles: React.CSSProperties;
    onSidebarToggle: (event: React.MouseEvent) => void;
}
export default function Header({ styles, onSidebarToggle }: IHeaderProps): JSX.Element;
