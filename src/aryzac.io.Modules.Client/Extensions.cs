using Aryzac.IO.Modules.Client.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryzac.IO.Modules.Client
{
    public static class Extensions
    {
        public static string GetPath(this TableModel table)
        {
            var pathSegments = new List<string>();
            var currentNode = table.InternalElement;

            var skippedSpecializationTypes = new List<string>()
            {
                ComponentViewModel.SpecializationTypeId,
                SectionModel.SpecializationTypeId,
                TableModel.SpecializationTypeId,
            };

            while (currentNode != null)
            {
                if (currentNode.SpecializationTypeId == ComponentsModel.SpecializationTypeId)
                {
                    break;
                }

                if (!skippedSpecializationTypes.Contains(currentNode.SpecializationTypeId))
                {
                    pathSegments.Add(currentNode.Name);
                }

                currentNode = currentNode.ParentElement;
            }

            pathSegments.Reverse(); // Reverse the order of the path segments

            var path = "/" + string.Join("/", pathSegments); // Join the path segments with '/'

            return path;
        }

        public static string GetPath(this SelectModel select)
        {
            var pathSegments = new List<string>();
            var currentNode = select.InternalElement;

            var skippedSpecializationTypes = new List<string>()
            {
                ComponentViewModel.SpecializationTypeId,
                SectionModel.SpecializationTypeId,
                SelectModel.SpecializationTypeId,
            };

            while (currentNode != null)
            {
                if (currentNode.SpecializationTypeId == ComponentsModel.SpecializationTypeId)
                {
                    break;
                }

                if (!skippedSpecializationTypes.Contains(currentNode.SpecializationTypeId))
                {
                    pathSegments.Add(currentNode.Name);
                }

                currentNode = currentNode.ParentElement;
            }

            pathSegments.Reverse(); // Reverse the order of the path segments

            var path = "/" + string.Join("/", pathSegments); // Join the path segments with '/'

            return path;
        }

        public static string GetPath(this HeadingModel select)
        {
            var pathSegments = new List<string>();
            var currentNode = select.InternalElement;

            var skippedSpecializationTypes = new List<string>()
            {
                ComponentViewModel.SpecializationTypeId,
                SectionModel.SpecializationTypeId,
                HeadingModel.SpecializationTypeId,
            };

            while (currentNode != null)
            {
                if (currentNode.SpecializationTypeId == ComponentsModel.SpecializationTypeId)
                {
                    break;
                }

                if (!skippedSpecializationTypes.Contains(currentNode.SpecializationTypeId))
                {
                    pathSegments.Add(currentNode.Name);
                }

                currentNode = currentNode.ParentElement;
            }

            pathSegments.Reverse(); // Reverse the order of the path segments

            var path = "/" + string.Join("/", pathSegments); // Join the path segments with '/'

            return path;
        }

        public static string GetPath(this LabelModel select)
        {
            var pathSegments = new List<string>();
            var currentNode = select.InternalElement;

            var skippedSpecializationTypes = new List<string>()
            {
                ComponentViewModel.SpecializationTypeId,
                SectionModel.SpecializationTypeId,
                LabelModel.SpecializationTypeId,
            };

            while (currentNode != null)
            {
                if (currentNode.SpecializationTypeId == ComponentsModel.SpecializationTypeId)
                {
                    break;
                }

                if (!skippedSpecializationTypes.Contains(currentNode.SpecializationTypeId))
                {
                    pathSegments.Add(currentNode.Name);
                }

                currentNode = currentNode.ParentElement;
            }

            pathSegments.Reverse(); // Reverse the order of the path segments

            var path = "/" + string.Join("/", pathSegments); // Join the path segments with '/'

            return path;
        }
    }
}
