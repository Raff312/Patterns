import { BaseModel } from "./base.model";

export class UserModel extends BaseModel {

    public id: string;
    public firstName: string;
    public secondName: string;
    public middleName: string;
    public username: string;
    public password: string;
    public subjectIds?: string[];
    public subjectPoints?: Map<string, Map<string, number>>;

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
    subjectIds?: string[];
    subjectPoints?: Map<string, Map<string, number>>;
}

export class CreateUserModel {

    public firstName: string;
    public secondName: string;
    public middleName: string;
    public username: string;
    public password: string;
    public userType: UserType;

}

export enum UserType {
    Admin, Teacher, Student
}
