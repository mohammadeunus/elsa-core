using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elsa.Server.Api.Endpoints.WorkflowDefinitions
{
    public partial class Import
    {
        public class ImportWorkflowDefinitionRequest
        {
            public IFormFile? File { get; set; }
        }
    }
}
