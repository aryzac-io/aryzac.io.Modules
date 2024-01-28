import { ClientsService } from "@/services/clients-service.proxy";

export const useClientsServiceProxy = () => {

  const clientsServices = new ClientsService();

  return { 
    changeNameClientCommand : clientsServices.changeNameClientCommand,
    changeTitleClientCommand : clientsServices.changeTitleClientCommand,
    createClientCommand : clientsServices.createClientCommand,
    deleteClientCommand : clientsServices.deleteClientCommand,
    getClientByIdQuery : clientsServices.getClientByIdQuery,
    getClientsQuery : clientsServices.getClientsQuery,
    changeNoteClientCommand : clientsServices.changeNoteClientCommand,
    changeReceivePromotionClientCommand : clientsServices.changeReceivePromotionClientCommand,
    };
}
