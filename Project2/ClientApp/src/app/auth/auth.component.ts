import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AppState } from "../app.state";
import { UserService } from "../services/user.service";

@Component({
    selector: "auth",
    templateUrl: "./auth.component.html",
    styleUrls: ["./auth.component.scss"]
})
export class AuthComponent implements OnInit {

    public username: string = null;
    public password: string = null;
    public noUser = false;

    constructor(
        private readonly appState: AppState,
        private readonly userService: UserService,
        private readonly router: Router
    ) { }

    public ngOnInit(): void {
        if (this.appState.initComplete) {
            this.router.navigate(["/subjects"]);
        }
    }

    public async signIn(): Promise<void> {
        if (!this.username || !this.password) {
            return;
        }

        const user = await this.userService.getByUsername(this.username);
        if (!user || user.password !== this.password) {
            this.noUser = true;
            return;
        }

        this.appState.initComplete = true;
        this.router.navigate(["/subjects"]);
    }

}
