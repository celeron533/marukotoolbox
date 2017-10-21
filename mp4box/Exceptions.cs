using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace mp4box
{
    public class ToolsDirectoryNotFoundException : System.IO.DirectoryNotFoundException
    {
        public ToolsDirectoryNotFoundException()
        {
        }

        public ToolsDirectoryNotFoundException(string message) : base(message)
        {
        }

        public ToolsDirectoryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ToolsDirectoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
