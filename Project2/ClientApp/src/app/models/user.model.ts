import { BaseModel } from "./base.model";

export class UserModel extends BaseModel {

    public id: string;
    public firstName: string;
    public secondName: string;
    public middleName: string;
    public username: string;
    public password: string;
    public userType: UserType;
    public subjectIds?: string[];
    public checkpointPoints?: Map<string, number>;

    constructor(data?: IUserModel) {
        super();
        if (data) {
            this.mapFromJson(data);
        }
    }

}

export interface IUserModel {
    id: string;
    firstName: string;
    secondName: string;
    middleName: string;
    username: string;
    password: string;
    userType: UserType;
    subjectIds?: string[];
    checkpointPoints?: Map<string, number>;
}

export class CreateUserModel {

    public firstName: string;
    public secondName: string;
    public middleName: string;
    public username: string;
    public password: string;
    public userType: UserType;
    public subjectIds?: string[];

}

export enum UserType {
    Admin, Teacher, Student
}
