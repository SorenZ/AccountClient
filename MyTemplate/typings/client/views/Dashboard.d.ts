import * as React from 'react';
import { IDotnetifyVM } from 'dotnetify';
import { ActivityModel } from '../components/dashboard/RecentActivities';
declare class DashboardModel {
    Download: string;
    Upload: string;
    Latency: string;
    Users: number;
    Traffic: number[];
    ServerUsage: number[];
    ServerUsageLabel: string[];
    Utilization: number[];
    UtilizationLabel: string[];
    RecentActivities: ActivityModel[];
}
export default class Dashboard extends React.Component<any, DashboardModel> {
    vm: IDotnetifyVM;
    state: DashboardModel;
    dispatch: (state: DashboardModel) => void;
    constructor(props: any);
    componentWillUnmount(): void;
    render(): JSX.Element;
}
export {};
