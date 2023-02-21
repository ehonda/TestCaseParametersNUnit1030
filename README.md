# Demo for a NUnit1030 false positive

## False positive with `TestCaseParameters`

⚠ If you've run the demo from the [`TestCaseData`-section](#no-false-positive-with-testcasedata), run
`sed -i 's/IEnumerable<TestCaseData>/IEnumerable<TestCaseParameters>/g' TestCaseParametersNUnit1030/Tests.cs` first to
make these work as intended.

To produce the false positive, run the following from the root directory, to enable `NUnit1030` and then run the tests
(file paths replaced by `<...>` in sample output):

```console
$ sed -i 's/^#pragma/\/\/ #pragma/g' TestCaseParametersNUnit1030/Tests.cs && dotnet test -v q
<error location>: error NUnit1030: The TestCaseSource provides type 'NUnit.Framework.Internal.TestCaseParameters', but the Test method expects type 'int' for parameter 'n' <csproj path>
```

To demonstrate that tests run fine if we disable `NUnit1030`, run the following from the root directory, to disable
`NUnit1030` and then run the tests (file paths replaced by `<...>` in sample output):

```console
$ sed -i 's/\/\/ #pragma/#pragma/g' TestCaseParametersNUnit1030/Tests.cs && dotnet test -v q
Test run for <dll path> (.NETCoreApp,Version=v7.0)
Microsoft (R) Test Execution Command Line Tool Version 17.4.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 8 ms - TestCaseParametersNUnit1030.dll (net7.0)
```

## No false positive with `TestCaseData`

If we use `TestCaseData` instead of `TestCaseParameters` for our `TestCaseSource`, we don't get an error from
`NUnit1030`. To demonstrate, run the following from the root directory, to enable `NUnit1030`, use `TestCaseData` for
the source and then run the tests (file paths replaced by `<...>` in sample output):

```console
$ sed -i 's/\/\/ #pragma/#pragma/g' TestCaseParametersNUnit1030/Tests.cs && sed -i 's/IEnumerable<TestCaseParameters>/IEnumerable<TestCaseData>/g' TestCaseParametersNUnit1030/Tests.cs && dotnet test -v q
Test run for <dll path> (.NETCoreApp,Version=v7.0)
Microsoft (R) Test Execution Command Line Tool Version 17.4.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 14 ms - TestCaseParametersNUnit1030.dll (net7.0)
```
