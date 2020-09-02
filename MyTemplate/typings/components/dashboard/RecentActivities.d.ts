/// <reference types="react" />
import { IDotnetifyVM, RouteType } from 'dotnetify';
export declare class ActivityModel {
    PersonName: string;
    Status: string;
    Route: RouteType;
}
export interface IRecentActivitiesProps {
    vm: IDotnetifyVM;
    data: ActivityModel[];
}
export default function RecentActivities({ vm, data }: IRecentActivitiesProps): JSX.Element;
