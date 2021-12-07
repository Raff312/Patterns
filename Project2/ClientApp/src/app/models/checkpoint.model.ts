import { BaseModel } from "./base.model";

export class CheckpointModel extends BaseModel {

    public id: string;
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
    id: string;
    name: string;
    maxPoint: number;
    currentPoint?: number;
}
