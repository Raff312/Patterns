import { Component } from "@angular/core";

@Component({
    selector: "nav-menu",
    templateUrl: "./nav-menu.component.html",
    styleUrls: ["./nav-menu.component.scss"]
})
export class NavMenuComponent {

    public isExpanded = false;

    public collapse() {
        this.isExpanded = false;
    }

    public toggle() {
        this.isExpanded = !this.isExpanded;
    }

}
