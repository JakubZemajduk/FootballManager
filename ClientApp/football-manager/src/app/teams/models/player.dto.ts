export interface PlayerDto{
    id: number;
    name: string;
    surname: string;
    year: number;
    position: Positions;
}
export enum Positions{
    Goalkeeper,
    Defender,
    Midfielder,
    Striker
}