import { Component, OnInit } from "@angular/core";
import { AppState } from "./app.state";
import { CreateUserModel } from "./models/user.model";
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
        // await this.createStudentUser();
    }

    private async createAdminUser(): Promise<void> {
        const createAdminUser = new CreateUserModel();
        createAdminUser.firstName = "Admin";
        createAdminUser.username = "admin";
        createAdminUser.password = "admin";
        createAdminUser.userType = 0;
        await this.userService.create(createAdminUser);
    }

    private async createStudentUser(): Promise<void> {
        const createStudentUser = new CreateUserModel();
        createStudentUser.firstName = "Rafik";
        createStudentUser.secondName = "Bikmaev";
        createStudentUser.middleName = "Ravilevich";
        createStudentUser.username = "rafik";
        createStudentUser.password = "rafik";
        createStudentUser.userType = 2;
        await this.userService.create(createStudentUser);
    }

}
