using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data;
using NHibernate;
using Hangfire;
namespace Commands.ResourceCommands
{
    public class UploadResourceCommandHandler : ICommandHandler<UploadResourceCommand>
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        public UploadResourceCommandHandler(IBackgroundJobClient backgroundJobsClient) 
        {
            _backgroundJobClient = backgroundJobsClient;
        }
       
        public Task HandleAsync(UploadResourceCommand command)
        {

            _backgroundJobClient.Enqueue(() => Console.WriteLine("Adding Resource"));
            using (ISession session = NHibernateInitializer.GetSessionFactory().OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(command.Resource);
                  
                    foreach (var file in command.ResourceFiles) 
                    {
                        session.Save(file);
                    }
                    transaction.Commit();
                } 
            }
            return  Task.CompletedTask;
        }
            
        

        
    }
}
