This tool can be accessed from both the command line of visual studio. 
To run the tool from the command line a command of the following format has to be generated:

genmodel <ICD file>  -ied  <ied-name> -ap <access-point-name> -out <output-name> -modelprefix <model-prefix>

The values in <> have to be replaced with the values corresponding to an arbitrary ICD file. 
To run this command completely the command should look like this: 

ModelGeneratorExample.exe/(dotnet ModelGeneratorExample.dll) genmodel <ICD file>  -ied  <ied-name> -ap <access-point-name> -out <output-name> -modelprefix <model-prefix>

Example: 

ModelGeneratorExample.exe ICDFiles/simpleIO_smv.icd -ied simpleIO -ap accessPoint1 -out  static_model -modelprefix iedModel

or 

dotnet ModelGeneratorExample.dll ICDFiles/simpleIO_smv.icd -ied simpleIO -ap accessPoint1 -out  static_model -modelprefix iedModel