import { BaseModel } from "./base.model";

export class CheckpointModel extends BaseModel {

    public id: string;
    public date?: Date;
    public name: string;
    public maxPoint: number;
    public currentPoint?: number;

    constructor(data?: ICheckpointModel) {
        super();
        if (data) {
            this.mapFromJson(data);
        }
    }

}

export interface ICheckpointModel {
    date?: Date;
    name: string;
    maxPoint: number;
    currentPoint?: number;
}
