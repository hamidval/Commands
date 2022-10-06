using Data;
using NHibernate;
using Queries.ResourceQueries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.ResourceCommands
{
    public class EditResourceCommandHandler : ICommandHandler<EditResourceCommand>
    {
        private readonly IResourceQuery _resourceQuery;
        public EditResourceCommandHandler(IResourceQuery resourceQuery) 
        {
            _resourceQuery = resourceQuery;
        }

        public Task HandleAsync(EditResourceCommand command)
        {
            var resource = _resourceQuery.GetResources(command.ResourceId).FirstOrDefault();
            var newResource = command.Resource;

            resource.ResourceTitle = newResource.ResourceTitle;
            resource.Price = newResource.Price;
            resource.AccessType = newResource.AccessType;
            resource.Subject = newResource.Subject;
            resource.Level = newResource.Level;
            resource.ExamBoard = newResource.ExamBoard;
            resource.IsExamPractice = newResource.IsExamPractice;
            resource.IsExercise = newResource.IsExercise;
            resource.CreatedBy = newResource.CreatedBy;
            resource.ResourceStatus = newResource.ResourceStatus;
            resource.Description = newResource.Description;
            resource.ResourceType = newResource.ResourceType;


            using (ISession session = NHibernateInitializer.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(resource);
                    transaction.Commit();
                }
            }
            return Task.CompletedTask;
        }
    }
}
