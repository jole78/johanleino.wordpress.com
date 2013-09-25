
function Invoke-NUnit {
	$arguments = @()
	
	$arguments += "/labels"
	$arguments += "/out=TestResult.txt"
	$arguments += "/xml=TestResult.xml"
	
	$exe = $(Get-NUnitPackage).Exe
	
	Invoke-Executable $exe $arguments
}

function Invoke-Executable {
	param(
		[String]$Exe,
		[String[]]$Parameters
	)
	
	& $Exe $Parameters | Out-Null

}

function Get-NUnitPackage {
	throw "I'm not implemented yet..."
}

Export-ModuleMember -Function Invoke-NUnit

