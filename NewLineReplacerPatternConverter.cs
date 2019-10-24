using System.IO;
using log4net.Util;

namespace Log4netNewlineReplacer
{
    public class NewLineReplacerPatternConverter : PatternConverter
    {
        protected override void Convert(TextWriter writer, object state)
        {
            var loggingEvent = state as log4net.Core.LoggingEvent;

            if (loggingEvent == null)
                return;

            writer.Write(loggingEvent.RenderedMessage.Replace("\r", "\\r").Replace("\n", "\\n"));
        }
    }
}
