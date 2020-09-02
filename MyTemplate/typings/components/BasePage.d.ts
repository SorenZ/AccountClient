import React from 'react';
export interface IBasePageProps {
    title: string;
    navigation: string;
    children: React.ReactNode;
}
export default function BasePage({ title, navigation, children }: IBasePageProps): JSX.Element;
