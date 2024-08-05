import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TransferDto } from "../model/transfer.dto";

@Injectable()
export class TransferService {
    constructor(private http:HttpClient){}

    addTransfer$(transfer: TransferDto){
        return this.http.post('https://localhost:7041/api/Players/transfer', transfer);
    }
}