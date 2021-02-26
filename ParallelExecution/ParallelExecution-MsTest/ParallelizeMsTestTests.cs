using Microsoft.VisualStudio.TestTools.UnitTesting;

// By default MsTest does not run tests in parallel
// https://devblogs.microsoft.com/devops/mstest-v2-in-assembly-parallel-test-execution/

// You can configure on assembly level to run SpecFlow features in parallel with each other
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]


// Note: SpecFlow does not support scenario level parallelization with MsTest within the same process (when scenarios from the same feature execute in parallel).
// https://github.com/SpecFlowOSS/SpecFlow/issues/1535
// If you configure a higher level MsTest parallelization than "ClassLevel" your tests will fail with runtime errors.
// E.g. [assembly: Parallelize(Scope = ExecutionScope.MethodLevel)] will not work.
