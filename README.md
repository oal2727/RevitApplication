# Revit Application 

### First Course : 
https://knowledge.autodesk.com/search-result/caas/simplecontent/content/lesson-1-the-basic-plug.html

### Notes:
1. References Libraries define "False"
2. Required compilation solution constantly , the execution load file ".dll"
3. The File .addin create on root project
Example:
``
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
``

Note Extra:
1. Required File .addin and .dll copy and paste to file AddIn directory
