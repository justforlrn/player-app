import { TDSSafeAny } from "tds-ui/shared/utility";

export interface CoreUserInitDTO {
    id: TDSSafeAny;
    name: string;
    email: string;
    phoneNumber: string;
    address?: string;
    dateOfBirth?: TDSSafeAny;
    avatar?: string;
    language: string;
    branchId: TDSSafeAny;
    departmentId: TDSSafeAny;
}