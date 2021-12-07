import { BaseModel } from "./base.model";
import { ICheckpointModel, CheckpointModel } from "./checkpoint.model";

export class SubjectModel extends BaseModel {

    public id: string;
    public name: string;
    public isExam: boolean;
    public checkpoints: CheckpointModel[];

    constructor(data?: ISubjectModel) {
        super();
        if (data) {
            this.mapFromJson(data);

            if (data.checkpoints) {
                this.checkpoints = BaseModel.convertArray(CheckpointModel, data.checkpoints);
            }
        }
    }

}

export interface ISubjectModel {
    id: string;
    name: string;
    isExam: boolean;
    checkpoints: ICheckpointModel[];
}

export class CreateSubjectModel extends BaseModel {

    public name: string;
    public isExam: boolean;

}
