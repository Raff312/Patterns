import { Injectable } from "@angular/core";
import { UserModel } from "./models/user.model";
import { UserService } from "./services/user.service";

@Injectable()
export class AppState {

    public currentUser: UserModel;
    public initComplete = true;

    constructor(private readonly userService: UserService) { }

}
