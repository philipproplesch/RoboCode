# RoboCode

## Prerequisites

The following MUST be installed on your machine:

- [robocode](http://sourceforge.net/projects/robocode/files/robocode/)
- robocode.dotnet

## Build

Run `build.bat` and grab the artifacts from the `out` directory.

## Debugging

It is very important to add the output directory (`bin/Debug` or `bin/Release`) of your robot [to the development options of Robocode](http://robowiki.net/wiki/Robocode/.NET/Create_a_.NET_robot_with_Visual_Studio#Running_the_robot_in_Robocode).

### Manual approach

You can find some information on this topic in the [Robocode wiki](http://robowiki.net/wiki/Robocode/.NET/Debug_a_.NET_robot_in_Visual_Studio).

#### Start external program
`C:\Program Files (x86)\Java\jre7\bin\java.exe` (you should change this path if necessary)

#### Command line arguments
`-Ddebug=true -Xmx1024M -Dsun.io.useCanonCaches=false -cp libs/robocode.jar;libs/jni4net.j-0.8.6.0.jar robocode.Robocode`

#### Working directory
`C:\robocode\` (you should change this path if necessary)

### RoboCode.Runner

    <add key="robocode:path" value="C:\robocode" />
    <add key="robocode:robots" value="sample.RamFire, PP.FooRobot" />
    <add key="robocode:rounds" value="5" />
    <add key="robocode:gui" value="true" />
    <add key="robocode:width" value="800" />
    <add key="robocode:height" value="600" />    