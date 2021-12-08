import { Component } from "@angular/core";
import { AppState } from "../app.state";

@Component({
    selector: "nav-menu",
    templateUrl: "./nav-menu.component.html",
    styleUrls: ["./nav-menu.component.scss"]
})
export class NavMenuComponent {

    public isExpanded = false;

    constructor(public readonly appState: AppState) { }

    public collapse() {
        this.isExpanded = false;
    }

    public toggle() {
        this.isExpanded = !this.isExpanded;
    }

}
