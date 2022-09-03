This repository hosts a sample on how to run automated acceptance tests using SpecFlow simultaneously on different BrowserStack configurations.

To run the samples:

* Clone the repository to your PC
* Create a trial account on BrowserStack
* Go to Account => Automate and copy the UserName and Value into the app.config
* Open a command prompt and run 

    powershell -file build.ps1
* Check out [this blog](https://www.kenneth-truyers.net/2015/01/03/running-specflow-acceptance-tests-in-parallel-on-browserstack/) for more information.