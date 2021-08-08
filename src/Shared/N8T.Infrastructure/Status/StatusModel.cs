using System.Collections.Generic;

namespace N8T.Infrastructure.Status
{
    public class StatusModel
    {
        public string AppName { get; set; } = default!;
        public string AppVersion { get; set; } = default!;
        public string OsArchitecture { get; set; } = default!;
        public string OsDescription { get; set; } = default!;
        public string ProcessArchitecture { get; set; } = default!;
        public string BasePath { get; set; } = default!;
        public string RuntimeFramework { get; set; } = default!;
        public string FrameworkDescription { get; set; } = default!;
        public string HostName { get; set; } = default!;
        public string IpAddress { get; set; } = default!;
        public IDictionary<string, object> Envs { get; set; } = new Dictionary<string, object>();
    }
}
