using NUnit.Framework;

// By default NUnit does not run tests in parallel
// https://docs.nunit.org/articles/nunit/writing-tests/attributes/parallelizable.html

// You can configure NUnit on assembly level to let all SpecFlow features run in parallel with each other
[assembly: Parallelizable(ParallelScope.Fixtures)]


// Note: SpecFlow does not support scenario level parallelization with NUnit (when scenarios from the same feature execute in parallel).
// If you configure a higher level NUnit parallelization than "Fixtures" your tests will fail with runtime errors.
// E.g. [assembly: Parallelizable(ParallelScope.Children)] will not work.
