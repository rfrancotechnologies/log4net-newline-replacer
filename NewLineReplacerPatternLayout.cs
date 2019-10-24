using log4net.Layout;
using log4net.Util;

namespace Log4netNewlineReplacer
{
    public class NewLineReplacerPatternLayout : PatternLayout
    {
        public NewLineReplacerPatternLayout()
        {
            AddConverter(new ConverterInfo { Name = "replaced_message", Type = typeof(NewLineReplacerPatternConverter) });
        }
    }
}