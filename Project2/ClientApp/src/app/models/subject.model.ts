import { BaseModel } from "./base.model";
import { ITargetModel, TargetModel } from "./target.model";

export class SubjectModel extends BaseModel {

    public id: string;
    public name: string;
    public isExam: boolean;
    public targets: TargetModel[];

    constructor(data?: ISubjectModel) {
        super();
        if (data) {
            this.mapFromJson(data);
        }
    }

}

export interface ISubjectModel {
    id: string;
    name: string;
    isExam: boolean;
    targets: ITargetModel[];
}
