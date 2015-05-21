# .NetOracleLogger

## Enviroment Remark
- Log in Oracle database 10g with log4net
- .Net Framework 4.0 tested
- MVC WebAPI project
- log4net version 1.2.13.0


## Instructions
* Open project
* Reference to Logger/log4net.config for table schema, then modify connectionString and commandText for the table
* check Web.config for key="log4net.Internal.Debug" must true
* (install Chrome extension : Postman 2.0, not 1.x, for test Web API)


## Test step
* run the proejct
* Post a message to .../api/logs in Postman, example: Post to http://localhost:59115/api/logs/ with data: { logger: "Appantasy.com", message: "Arthur" } in JSON formate
* check Table, there will be two records, one is for normal info, Arthur and Appantasy.com, another is an exception loggin sample


