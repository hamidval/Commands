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
    public class DeleteResourceCommandHandler : ICommandHandler<DeleteResourceCommand>
    {
        private readonly IResourceQuery _resourceQuery;

        public DeleteResourceCommandHandler(IResourceQuery resourceQuery) 
        {
            _resourceQuery = resourceQuery;
        }

        public Task HandleAsync(DeleteResourceCommand command)
        {
            var resource = _resourceQuery.GetResources(command.ResourceId).FirstOrDefault();
            using (ISession session = NHibernateInitializer.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(resource);                 
                    transaction.Commit();
                }
            }
            return Task.CompletedTask;    
        }

   
    }
}
