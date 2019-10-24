# Log4netNewlineReplacer

Custom log4net pattern layout that replaces new-line characters before sending log messages to the appenders.

[![NuGet Version](https://buildstats.info/nuget/Log4netNewlineReplacer?includePreReleases=true)](https://www.nuget.org/packages/Log4netNewlineReplacer)

This library is based on the solution provided by [avalanchis](https://github.com/avalanchis) to the problem of multi-line log messages at [StackOverflow](https://stackoverflow.com/a/32256947). The purpose of this library is provide a common solution to .NET developers suffering the same problem.

## Why Log4netNewlineReplacer

Any time you log and exception using Log4net the whole stacktrace of the exception will be logged in separate lines. However it is very common for logging aggregators to treat separate lines as different log entries. Docker, Kubernetes, Promtail, Grafana Loki, Fluentd, fluent-bit, filebit, or Logstash typically work better if your log entries are single-lined. Some of these systems allow you to parse multi-line log entries via configurable regular expressions. However those solutions cause very heavy processing load and are difficult to configure.

`Log4netNewlineReplacer` provides a different approach. Instead of having to parse complex multi-line logs, it allows you to render single-lined log messages from start. In order to do so it provides a custom PatternLayout that replaces new-line and carriage-return characters with the text `"\n"` and `"\r"` respectively. This way you are able to see when the new line characters where originally placed, but the log entry will contain a single line.

## Usage

You can install `Log4netNewlineReplacer` via Nuget:

```bash
dotnet add package Log4netNewlineReplacer
```

In your log4net configuration file you can reference this pattern layout:

```xml
<appender name="SomeAppender" type"...">
    ...
    <layout type="Log4netNewlineReplacer.NewLineReplacerPatternLayout, log4net-newline-replacer">
      <conversionPattern value="%utcdate %level %logger %replaced_message %newline" />
    </layout>
</appender>
```

Be aware that the processed message with replaced new-line characters can be injected in your log pattern via the `%replaced_message` variable.
