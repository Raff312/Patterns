/* eslint-disable @typescript-eslint/no-explicit-any */
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable, NgZone } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";

@Injectable()
export class ApiClient {

    constructor(
        protected http: HttpClient,
        protected router: Router,
        protected zone: NgZone
    ) { }

    public get(url: string, silent?: boolean, full: boolean = false): Promise<any> {
        const observable = this.http.get(`/${url}`, { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent, full);
    }

    public delete(url: string, silent?: boolean): Promise<any> {
        const observable = this.http.delete(`/${url}`, { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    public post(url: string, data: any, silent?: boolean): Promise<any> {
        const observable = this.http.post(`/${url}`, JSON.stringify(data), { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    public put(url: string, data: any, silent?: boolean): Promise<any> {
        const observable = this.http.put(`/${url}`, JSON.stringify(data), { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    protected getHeaders(): HttpHeaders {
        return new HttpHeaders({ "content-type": "application/json", "cache-control": "no-cache" });
    }

    protected getCredentialsOption(): boolean | undefined {
        return undefined;
    }

    protected subscribe(observable: Observable<object>, url: string, silent?: boolean, full: boolean = false): Promise<any> {
        const promise = new Promise((resolve, reject) => {
            observable.subscribe({
                next: r => {
                    setTimeout(() => {
                        this.zone.run(() => {
                            if (full) {
                                resolve(r);
                            } else {
                                resolve(r["body"]);
                            }
                        });
                    });
                },
                error: r => {
                    if (silent) {
                        if (r.status === 500) {
                            resolve({ code: "500" });
                        } else {
                            resolve(r.error || null);
                        }
                    } else {
                        if (r.status === 400) {
                            resolve(r.error || null);
                        }
                        if (r.status === 402) {
                            reject(r);
                            return;
                        }
                        if (r.status === 403) {
                            resolve(null);
                        }
                        resolve(null);
                    }
                }
            });
        });

        return promise;
    }

}
