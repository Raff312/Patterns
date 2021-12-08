import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { SubjectListComponent } from "./subject-list/subject-list.component";
import { SubjectComponent } from "./subject/subject.component";
import { ApiClient } from "./services/api.client";
import { SubjectService } from "./services/subject.service";
import { UserService } from "./services/user.service";
import { AppState } from "./app.state";
import { AuthComponent } from "./auth/auth.component";
import { UsersComponent } from "./users/users.component";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        SubjectListComponent,
        SubjectComponent,
        AuthComponent,
        UsersComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            {
                path: "", component: AuthComponent
            },
            {
                path: "subjects",
                children: [
                    { path: "", component: SubjectListComponent },
                    { path: ":subjectId", component: SubjectComponent }
                ]
            },
            {
                path: "users", component: UsersComponent
            }
        ])
    ],
    providers: [
        ApiClient,
        SubjectService,
        UserService,
        AppState
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
