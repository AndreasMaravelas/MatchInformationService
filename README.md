# Match Information Service

## About

This is the Match information REST API.

## Deploy

In order to run, you will need to change the connection string at appsettings, with the connection string for your SQL Server.

## Tools Used

- EF Core
- XUnit
- MediatR
- AutoMapper

## Functionality

We have impelemnted two controllers.
- MatchController
- MatchOddsController

MatchController provides crud opperations for the MatchDto object.
MatchOddsController provides crud opperations for the MatchOddsDto object.

## Tests

For the tests we have added just a single test for the Application service.

### Things to improve :
- Add tests for all classes, methods, cases.
- Add functional tests
- Add more validations
- Handle exceptions

