# CMSIS.Pack
.NET Library for working with [CMSIS-Pack](http://www.keil.com/pack/doc/cmsis/Pack/html/index.html) component packaging for embedded devices

This library is still in the early stages of development and includes a robust SemanticVersion parser that can handle the non-conformant real world pack description files. Unfortunately the official CMSIS-Pack documentation specifies a relaxed syntax for SemanticVersion numbers, furthermore there are world PDSC files published that don't fully conform to the published XSD. In addition, the official HTML documentation included with CMSIS itself is not consistent with the officially published Pack.XSD file. Thus, this library has to do some dancing to resolve such ambiguities and can't just rely on a validating XML parser with the official schema and a standard SemanticVersion parser.

## Current State
At this point in time it can parse all of the currently published PDSC files, there is a simple application "netmfpackinstaller" that can show all the packs along with some basic information. 

More refactoring work is needed to make the classes originally generated via XSD.exe more normal .NET style, including specifying default values that are defined in the documentation but not in the schema.
