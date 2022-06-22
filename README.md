# Revit Application 

### First Course : 
https://knowledge.autodesk.com/search-result/caas/simplecontent/content/lesson-1-the-basic-plug.html

## External Comand and Application:

[EXTERNAL COMMAND](https://knowledge.autodesk.com/fr/support/revit/troubleshooting/caas/CloudHelp/cloudhelp/2014/FRA/Revit/files/GUID-C84BA0A2-2637-46B0-8BA7-3B0A982485A1-htm.html)
------------------
[EXTERNAL APPLICATION](https://knowledge.autodesk.com/fr/support/revit/troubleshooting/caas/CloudHelp/cloudhelp/2014/FRA/Revit/files/GUID-CEF0F9C9-046E-46E2-9535-3B9620D8A170-htm.html)
-------------------
[ADDINS](https://knowledge.autodesk.com/es/support/revit/troubleshooting/caas/CloudHelp/cloudhelp/2014/ESP/Revit/files/GUID-4FFDB03E-6936-417C-9772-8FC258A261F7-htm.html) 



### 1-Notes To External Command:
1. References Libraries define "False"
2. Required compilation solution constantly , the execution load file ".dll"
3. The File .addin create on root project
Example:
[project_selection](https://knowledge.autodesk.com/search-result/caas/simplecontent/content/lesson-1-the-basic-plug.html)

```
<?xml version="1.0" encoding="utf-8"?>
<RevitAddIns>
	<AddIn Type="Command">
		<Name>AppPlugin</Name>
		<FullClassName>AppPlugin.Class1</FullClassName>
		<Text>AppPlugin</Text>
		<Description>Places the Group at Particular Point</Description>
		<VisibilityMode>AlwaysVisible</VisibilityMode>
		<Assembly>file.dll</Assembly>
		<AddInId>502fe383-2648-4e98-adf8-5e6047f9dc34</AddInId>
		<VendorId>ADSK</VendorId>
		<VendorDescription>Autodesk, Inc, www.autodesk.com</VendorDescription>
	</AddIn>
</RevitAddIns>
```

Note Extra:
1. Required File "file.addin" and "file.dll" copy and paste to file AddIn directory
2. Use implements "IExternalCommand" working with functions : Execute

### 2-Notes To External Application:
1. References Libraries define "False"
2. Required compilation solution constantly , the execution load file ".dll"
3. The File .addin create on root project

```
<RevitAddIns>
	<AddIn Type="Application">
		<Name>AppExternalUIRevit</Name>
		<Assembly>AppExternalUIRevit.dll</Assembly>
		<AddInId>5087D63A-02BC-4C8B-8C7C-E44B650831B9</AddInId>
		<FullClassName>AppExternalUIRevit.Application</FullClassName>
		<VendorId>ADSK</VendorId>
		<VendorDescription>Autodesk, www.autodesk.com</VendorDescription>
	</AddIn>
</RevitAddIns>
```

Note Extra:
1. Required File "file.addin" and "file.dll" copy and paste to file AddIn directory
2. Use implements "IExternalApplication" working with functions : OnShutdown(close) and onStartUp(initialize)


## 3. Difference IExternalApplication and  IExternalCommand: 
- IExternalApplication : add application extern on revit
- IExternalCommand : add command extern on revit

### 4.Transactions Attributes (IExternalCommand)
1. TransactionMode.Automatic 
2. TransactionMode.Manual
3. TransactionMode.ReadOnly
Example :
```[Transaction(TransactionMode.Automatic)]```

### 5.Attributes register of diary (IExternalCommand)
1. JournalMode.NoCommandData
2. JournalMode.UsingCommandData 
Example :
```[Journaling(JournalingMode.UsingCommandData)]```

### EXTRA ! .Execution Methods
#### Method 1 :
1. copy files "file.addin" and "file.dll" on directory AddIn
2. Define Execution Compilation VsCode
=> Properties Execution Project:
2.1. Depurar : ${Directory}\Revit.exe
2.2. Event Compilation: 
```
"if exist "$(AppData)\Autodesk\Revit 2021\Addins" copy "$(ProjectDir)*.addin" "$(AppData)\Autodesk\Revit 2021\Addins"
```

Example Directory AddIn In My Case:
```
C:\Users\josel\AppData\Roaming\Autodesk\Revit\Addins\2021
```