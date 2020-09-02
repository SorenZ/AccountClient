import * as React from 'react';
import { IDotnetifyVM } from 'dotnetify';
declare class EmployeeModel {
    Id: string;
    FirstName: string;
    LastName: string;
}
declare class TablePageModel {
    Employees: EmployeeModel[];
    Pages: number[];
    SelectedPage: number;
    ShowNotification: boolean;
    Add: string;
}
declare class TablePageState extends TablePageModel {
    addName: string;
}
export default class TablePage extends React.Component<any, TablePageState> {
    state: TablePageState;
    vm: IDotnetifyVM;
    dispatch: (state: any) => void;
    constructor(props: any);
    componentWillUnmount(): void;
    render(): JSX.Element;
}
export {};
