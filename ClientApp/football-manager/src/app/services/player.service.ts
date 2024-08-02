import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { PlayerDto } from "../teams/models/player.dto";

@Injectable()
export class PlayerService {
    constructor(private http:HttpClient){}

    getPlayers$(){
        return this.http.get<PlayerDto[]>('https://localhost:7041/api/Players');
    }

    addPlayer$(player: PlayerDto){
        return this.http.post('https://localhost:7041/api/Players', player);
    }
}