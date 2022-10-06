using Data;
using Domain.Enums;
using NHibernate;
using Queries.ResourceQueries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.ResourceCommands
{
    public class ArchiveResourceCommandHandler : ICommandHandler<ArchiveResourceCommand>
    {
       
        private readonly IResourceQuery _resourceQuery;
        public ArchiveResourceCommandHandler(IResourceQuery resourceQuery)
        {
            _resourceQuery = resourceQuery;
        }
        public Task HandleAsync(ArchiveResourceCommand command)
        {
            var resource = _resourceQuery.GetResources(command.ResourceId).FirstOrDefault();

            if (resource != null) 
            {
                resource.ResourceStatus = ResourceStatus.Archived;
                using (ISession session = NHibernateInitializer.GetSessionFactory().OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(resource);
                        transaction.Commit();
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
