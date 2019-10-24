# log4net-newline-replacer

Custom log4net pattern layout that replaces new-line characters before sending log messages to the appenders.

This library is based on the solution provided by [avalanchis](https://github.com/avalanchis) to the problem in [StackOverflow](https://stackoverflow.com/a/32256947). The purpose of this library is provide a common solution to .NET developers suffering the same problem.

## Why `log4net-newline-replacer`

Any time you log and exception using Log4net the whole stacktrace of the exception will be logged in separate lines. However it is very common for logging aggregators to treat separate lines as different log entries. Docker, Kubernetes, Promtail, Grafana Loki, Fluentd, fluent-bit, filebit, or Logstash typically work better if your log entries are single-lined. Some of these systems allow you to parse multi-line log entries via configurable regular expressions. However those solutions cause very heavy processing load and are difficult to configure.

`log4net-newline-replacer` provides a different approach. Instead of having to parse complex multi-line logs, it allows you to render single-lined log messages from start. In order to do so it provides a custom PatternLayout that replaces new-line characters with the text `"\n"` or `"\r"`. This way you are able to see when the new line characters where originally placed, but the log entry will contain a single line.

## Usage

You can install `log4net-newline-replacer` via Nuget:

```bash
dotnet add package log4net-newline-replacer
```

In your log4net configuration file you can reference this pattern layout:

```xml
<appender name="SomeAppender" type"...">
    ...
    <layout type="Log4netNewlineReplacer.NewLineReplacerPatternLayout, YourAssemblyName">
      <conversionPattern value="%date %-5level %logger %replaced_message %newline" />
    </layout>
</appender>
```
