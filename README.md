# [Kiota](https://github.com/HavenDV/Kiota/) 

### [![NuGet](https://img.shields.io/nuget/dt/Kiota.svg?style=flat-square&label=Kiota)](https://www.nuget.org/packages/Kiota/)
```
Install-Package Kiota
```
Currently not working (waiting for release of netstandard version of Kiota.Builder)

### Usage
The generator generates code based on any .yml/.yaml/.json file in the AdditionalFiles ItemGroup.
```xml
<ItemGroup>
  <AdditionalFiles Include="openapi.yml" />
</ItemGroup>
```

### Global options
```xml
<PropertyGroup>
  <Kiota_NamespaceName>Namespace</Kiota_NamespaceName>
  <Kiota_ClassName>ClassName</Kiota_ClassName>
</PropertyGroup>
```

### Contacts
* [mail](mailto:havendv@gmail.com)
