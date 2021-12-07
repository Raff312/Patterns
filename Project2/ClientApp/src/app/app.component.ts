import { Component, OnInit } from "@angular/core";
import { AppState } from "./app.state";
import { CreateUserModel, UserType } from "./models/user.model";
import { UserService } from "./services/user.service";

@Component({
    selector: "root",
    templateUrl: "./app.component.html"
})
export class AppComponent implements OnInit {

    constructor(
        public readonly appState: AppState,
        private readonly userService: UserService
    ) { }

    public async ngOnInit(): Promise<void> {
        // await this.createAdminUser();
    }

    private async createAdminUser(): Promise<void> {
        const createAdminUser = new CreateUserModel();
        createAdminUser.firstName = "Admin";
        createAdminUser.username = "admin";
        createAdminUser.password = "admin";
        createAdminUser.userType = UserType.Admin;
        await this.userService.create(createAdminUser);
    }

}
