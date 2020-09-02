import * as React from 'react';
export interface IPaginationProps {
    pages: number[];
    select: number;
    style: React.CSSProperties;
    onSelect: (page: any) => void;
}
export default function Pagination(props: IPaginationProps): JSX.Element;
