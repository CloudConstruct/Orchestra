using System.IO;

namespace Orchestra.Service
{
    public class RecordService
    {
        private RecordServiceConfiguration _configuration;

        public RecordService(RecordServiceConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetRecordFilename(string streamName)
        {
            return Path.Combine(_configuration.RecordPath, _configuration.FilenameFormat.Replace("{streamName}", streamName));
        }

    }
}
