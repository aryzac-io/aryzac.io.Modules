export interface ClientDto {
    id: string;
    firstName: string;
    lastName: string;
    otherNames?: string;
    titleId: string;
    receivePromotions: boolean;
    notes: string;
}