import { ClientsService } from "@/services/clients-service.proxy";

export const useClientsServiceProxy = () => {

  const clientsServices = new ClientsService();

  return { 
    changeNameClient : clientsServices.changeNameClient,
    createClient : clientsServices.createClient,
    deleteClient : clientsServices.deleteClient,
    getClientById : clientsServices.getClientById,
    getClients : clientsServices.getClients,
    };
}
