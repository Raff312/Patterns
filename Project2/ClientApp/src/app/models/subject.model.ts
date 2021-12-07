import { BaseModel } from "./base.model";
import { ICheckpointModel, CheckpointModel } from "./checkpoint.model";

export class SubjectModel extends BaseModel {

    public id: string;
    public name: string;
    public isExam: boolean;
    public targets: CheckpointModel[];

    constructor(data?: ISubjectModel) {
        super();
        if (data) {
            this.mapFromJson(data);

            if (data.targets) {
                this.targets = BaseModel.convertArray(CheckpointModel, data.targets);
            }
        }
    }

}

export interface ISubjectModel {
    id: string;
    name: string;
    isExam: boolean;
    targets: ICheckpointModel[];
}

export class CreateSubjectModel extends BaseModel {

    public name: string;
    public isExam: boolean;

}
