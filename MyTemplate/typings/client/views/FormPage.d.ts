import * as React from 'react';
import { IDotnetifyVM, RouteType } from 'dotnetify';
declare class EmployeeModel {
    Id: string;
    Name: string;
    Route: RouteType;
}
declare class FormPageModel {
    Employees: EmployeeModel[];
    Id: string;
    FirstName: string;
    LastName: string;
}
declare class FormPageState extends FormPageModel {
    dirty: boolean;
}
export default class FormPage extends React.Component<any, FormPageState> {
    state: FormPageState;
    vm: IDotnetifyVM;
    dispatch: (state: any) => void;
    routeTo: (route: RouteType) => void;
    constructor(props: any);
    componentWillUnmount(): void;
    render(): JSX.Element;
}
export {};
