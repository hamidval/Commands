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
    public class UnArchiveResourceCommandHandler : ICommandHandler<UnArchiveResourceCommand>
    {
       
        private readonly IResourceQuery _resourceQuery;
        public UnArchiveResourceCommandHandler(IResourceQuery resourceQuery)
        {
            _resourceQuery = resourceQuery;
        }
        public Task HandleAsync(UnArchiveResourceCommand command)
        {
            var resource = _resourceQuery.GetResources(command.ResourceId).FirstOrDefault();

            if (resource != null) 
            {
                resource.ResourceStatus = ResourceStatus.Live;
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
