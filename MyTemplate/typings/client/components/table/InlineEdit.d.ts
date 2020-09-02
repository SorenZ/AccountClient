import * as React from 'react';
export interface IInlineEditProps {
    children: React.ReactNode;
    onChange: (value: string) => void;
}
declare class InlineEditState {
    hover: boolean;
    edit: boolean;
    value: string;
}
export default class InlineEdit extends React.Component<IInlineEditProps, InlineEditState> {
    state: InlineEditState;
    constructor(props: IInlineEditProps);
    render(): JSX.Element;
}
export {};
