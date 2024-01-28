import { TitlesService } from "@/services/titles-service.proxy";

export const useTitlesServiceProxy = () => {

  const titlesServices = new TitlesService();

  return { 
    changeCodeTitleCommand : titlesServices.changeCodeTitleCommand,
    changeDescriptionTitleCommand : titlesServices.changeDescriptionTitleCommand,
    changeNameTitleCommand : titlesServices.changeNameTitleCommand,
    createTitleCommand : titlesServices.createTitleCommand,
    deleteTitleCommand : titlesServices.deleteTitleCommand,
    getTitleByIdQuery : titlesServices.getTitleByIdQuery,
    getTitlesQuery : titlesServices.getTitlesQuery,
    };
}