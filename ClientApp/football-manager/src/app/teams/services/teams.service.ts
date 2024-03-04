import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Team } from "../models/team";

@Injectable()
export class TeamsService {
    constructor(private http:HttpClient){}

    getTeams$(){
        return this.http.get<Team[]>('https://localhost:7041/api/teams');
    }
}