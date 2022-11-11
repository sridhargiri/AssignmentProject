using AssignmentRepository.Abstractions;
using AssignmentRepository.Implementations;
using AssignmentService.Abstractions;
using AssignmentService.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAssignmentBookService, AssignmentBookService>();
            services.AddScoped<IAssignmentBookRepository, AssignmentBookRepository>();
        }
    }
}
