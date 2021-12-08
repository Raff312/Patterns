import { Injectable } from "@angular/core";
import { UserModel } from "./models/user.model";

@Injectable()
export class AppState {

    public currentUser: UserModel;
    public initComplete = false;

}
