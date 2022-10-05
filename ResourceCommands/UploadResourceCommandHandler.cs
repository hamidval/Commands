using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data;
using NHibernate;
namespace Commands.ResourceCommands
{
    public class UploadResourceCommandHandler : ICommandHandler<UploadResourceCommand>
    {
       
        public Task HandleAsync(UploadResourceCommand command)
        {
            using (ISession session = NHibernateInitializer.GetSessionFactory().OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(command.Resource);
                    transaction.Commit();
                } 
            }
            return  Task.CompletedTask;
        }
            
        

        
    }
}
