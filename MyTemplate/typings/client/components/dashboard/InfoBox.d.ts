import * as React from 'react';
export interface IInfoBoxProps {
    icon: React.ComponentType;
    color: string;
    title: string;
    value: any;
}
export default function InfoBox({ icon, color, title, value }: IInfoBoxProps): JSX.Element;
