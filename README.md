# Crypto Exchange
Simple application for depicting a trading platform. 
It consists of 4 projects - Common, Common.Tests, CryptoExchangeConsoleApp, CryptoExchangeWebApp

# Common
It consists of a simple implementation of reading json files, ordering the data by type and generating corresponding output.
For simplicity when buying/selling crypto the orders are sorted by price and are "taken" until the number of BTC is reached.
The number if BTC is set to integer in order to reduce the code complexity.

# Common.Tests
In this project is demostrated how to unit test different services from the Common project.
For testing it is used NUint, NSubstitute & FluentAssertions.

# Crypto Exchange Console App
To reduce complexity DI support is added to the console application. The common services are added from the Common project.
Additionally, there is a launchSettings.json file where one can define the source folder path of the input json files.
The output is logged in the console in from of json.

# Crypto Exchange Web App
This is a small web application that is run under docker. 
For demonstation purposes one can use docker-compose to build and run the application. 
For simplicity the input data is added to the project (InputData folder) so that it gets copied to the docker container automatically.
In the appsettings.json under "Settings" one can specify the source path.
Trading of BTC is done using: 
http://localhost:5555/Trading/Buy/1 (controller/action/numberOfBtc)
The output is visualized as a json object.

