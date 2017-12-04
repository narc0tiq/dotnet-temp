# dotnet-temp
A temporary repo for reproducing a .net bug

Reference: <https://github.com/Microsoft/dotnet/issues/435>

Also referencing <https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed#net_b>, mentioned in the issue.

## Steps to reproduce

For ConsoleConfigThing:
1. Run it on a machine with .NET Framework 460798 (.NET Framework 4.7)
2. (optional) Check out its app.config after it ran. Notice the System.Windows.Forms.ApplicationConfigurationSection stub.
3. Copy the whole thing (including app.config) to a machine with .NET framework 394271 (.NET Framework 4.6.1)
4. Execute it -- and observe the fault.

For DotnetConfigThing:
1. Run it on a machine with .NET Framework 460798 (.NET Framework 4.7)
2. Press the button on the main window that says "Mess with app.config" (or press Alt+A if the window has focus).
3. Close the main window.
4. (optional) Check out its app.config after it ran. Notice the System.Windows.Forms.ApplicationConfigurationSection stub.
5. Copy the whole thing (including app.config) to a machine with .NET framework 394271 (.NET Framework 4.6.1)
6. Execute it -- and observe the fault.

Please note, both of these projects are targeting .NET 4.5.2! The broken configuration section is not present even in 4.6.1!

## Sample exception

```
---------------------------
It all went horribly wrong!
---------------------------
System.Windows.Markup.XamlParseException: 'The invocation of the constructor on type 'DotnetConfigThing.MainWindow' that matches the specified binding constraints threw an exception.' Line number '5' and line position '9'. ---> System.Configuration.ConfigurationErrorsException: Configuration system failed to initialize ---> System.Configuration.ConfigurationErrorsException: Unrecognized configuration section System.Windows.Forms.ApplicationConfigurationSection. (D:\Temp\_Deleteme\DotnetConfigThing.exe.Config line 7)
   at System.Configuration.ConfigurationSchemaErrors.ThrowIfErrors(Boolean ignoreLocal)
   at System.Configuration.BaseConfigurationRecord.ThrowIfParseErrors(ConfigurationSchemaErrors schemaErrors)
   at System.Configuration.BaseConfigurationRecord.ThrowIfInitErrors()
   at System.Configuration.ClientConfigurationSystem.EnsureInit(String configKey)
   --- End of inner exception stack trace ---
   at System.Configuration.ConfigurationManager.PrepareConfigSystem()
   at System.Configuration.ConfigurationManager.GetSection(String sectionName)
   at System.Configuration.PrivilegedConfigurationManager.GetSection(String sectionName)
   at System.Net.Configuration.SettingsSectionInternal.get_Section()
   at System.Net.Sockets.Socket.InitializeSockets()
   at System.Net.Dns.GetHostName()
   at DotnetConfigThing.MainWindow..ctor() in D:\src\vs2017\DotnetConfigThing\DotnetConfigThing\MainWindow.xaml.cs:line 17
   --- End of inner exception stack trace ---
   at System.Windows.Markup.WpfXamlLoader.Load(XamlReader xamlReader, IXamlObjectWriterFactory writerFactory, Boolean skipJournaledProperties, Object rootObject, XamlObjectWriterSettings settings, Uri baseUri)
   at System.Windows.Markup.WpfXamlLoader.LoadBaml(XamlReader xamlReader, Boolean skipJournaledProperties, Object rootObject, XamlAccessLevel accessLevel, Uri baseUri)
   at System.Windows.Markup.XamlReader.LoadBaml(Stream stream, ParserContext parserContext, Object parent, Boolean closeStream)
   at System.Windows.Application.LoadBamlStreamWithSyncInfo(Stream stream, ParserContext pc)
   at System.Windows.Application.LoadComponent(Uri resourceLocator, Boolean bSkipJournaledProperties)
   at System.Windows.Application.DoStartup()
   at System.Windows.Application.<.ctor>b__1_0(Object unused)
   at System.Windows.Threading.ExceptionWrapper.InternalRealCall(Delegate callback, Object args, Int32 numArgs)
   at System.Windows.Threading.ExceptionWrapper.TryCatchWhen(Object source, Delegate callback, Object args, Int32 numArgs, Delegate catchHandler)
---------------------------
OK   
---------------------------
```
