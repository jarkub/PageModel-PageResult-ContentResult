# PageModel-PageResult-ContentResult

https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#web
| Templates | Short name | Language | Tags | Introduced |
| :--------- | :---------- | :-------- | :---- | ----------: |
| ASP.NET Core Empty | web | [C#], F# | Web/Empty | 1.0 |

## web

- `--exclude-launch-settings`

Excludes launchSettings.json from the generated template.

- `-f|--framework <FRAMEWORK>`

Specifies the framework to target. Option not available in .NET Core 2.2 SDK.

The following table lists the default values according to the SDK version number you're using:

| SDK version | Default value |
| ----------- | ------------- |
| 9.0         | net9.0        |
| 8.0         | net8.0        |
| 7.0         | net7.0        |

To create a project that targets a framework earlier than the SDK that you're using, see `--framework` for console projects earlier in this article.

- `--no-restore`

Doesn't execute an implicit restore during project creation.

- `--no-https`

Turns off HTTPS.

- `--kestrelHttpPort`

Port number to use for the HTTP endpoint in launchSettings.json.

- `--kestrelHttpsPort'

Port number to use for the HTTPS endpoint in launchSettings.json. This option is not applicable when the parameter no-https is used (but no-https is ignored when an individual or organizational authentication setting is chosen for --auth).

- `--use-program-main`

If specified, an explicit Program class and Main method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: false.
