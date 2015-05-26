# .NetOracleLogger
### 該還得還是要還
受惠於網路已久，很多的資料、技術、問題都是靠網路解決，最近遇到一個大問題，追了很久，當下就決定，假如能解決，就貢獻整個專案 ... 所以，我來了!!!

### 這次的問題主要是糾結在
1. .Net frameowrk 不能用太新，公司的 IIS 版本有點舊，4.0 ...
2.  Oracle 有點舊，10g ....
3.  log4net 版本會因為一些理由衝突，所以必須用 1.2.11.0，但我上傳到 GitHub 的是 1.2.13.0
4.  log4net 對於 Oracle 存取，有問題不會主動報錯!!! 這就是最大的問題!!! 一定要設置 log4net.Internal.Debug 才會看到!!! 
... 所以，找到開啟 internal debug 的方式後，終於知道問題所在，也一一解決了 ...

### 源起
公司的系統對外有五台在做 Load balance，但很蠢的是，各自寫 log 在各自的主機上 ...
那發生問題時，尤其是客人操作出問題時，只能一台一台找，找五份 log ...
因此我覺得要統一寫到  table 才是王道
這是之一

另外就是  Web API 化
因為我們需要行動化，所以很多接口要改成 web service 的型態，別的系統就算了，假如是自己的系統，當然會希望 App 寫 log 時，直接 Post 到某個 Web API 就好，所以我就順便改寫了 log 機制

pss. 順便了解 ASP.NET MVC 架構 ... 
psss. 這樣可以方便做系統監控，例如每個小時 loggin 的人數、警告 log 的提醒機制、嚴重 log 的 回報機制
pssss. 本人英文很爛，基本上我會盡量用英文說明，但會用中文補齊

## Enviroment Remark
- Visual Studio 2013
- Log in Oracle database 10g with log4net
- .Net Framework 4.0 tested
- MVC WebAPI project
- log4net version 1.2.13.0

我用 VS 2013 (.net 4.0) 建了一個 MVC 4.0 的 Web API 專案
引用了 log4net，注意: 沒有引用 System.Data.Oracle.Client


## Setup Instructions
* Open project
* Reference to Logger/log4net.config for table schema, then modify connectionString and commandText for the table
* check Web.config for key="log4net.Internal.Debug" must true
* (install Chrome extension : Postman 2.0, not 1.x, for test Web API)

connectionString，請改成自家的 oracle 設定
table schema 在 log4net.config 裡
parameter 要與 commandText 裡的名稱、數量一樣，要不會無法寫入
可以安裝 Google Extension: Postman 做為測試



## Test step
* run the proejct
* Post a message to .../api/logs in Postman, example: Post to http://localhost:59115/api/logs/ with data: { logger: "Appantasy.com", message: "Arthur" } in JSON formate
* check Table, there will be two records, one is for normal info, Arthur and Appantasy.com, another is an exception loggin sample

因為我新增了 LogsController，稍微修改 Post 函式 接入參數為 LogRequestMessage
所以用 postman POST 的資料，JSON 格式要對，要不會有錯



## Note
* bufferSize has been modifed as a general number in log4net.config, like 128

請根據自家系統判斷 bufferSize，其定義是當 log 累積數量到達 bufferSize 設定數量時，就會寫入資料庫
這問題也是搞了我很久!!!!!!
因為一開始設定 128，結果發現資料庫沒有資料，以為沒有設定成功
其實是因為還沒到達 bufferSize !


## Reference
* http://stackoverflow.com/questions/1057464/log4net-doesnt-log-or-error Debug mode
* https://decoding.wordpress.com/2008/07/13/using-log4net-with-oracle-10g/  VB Sample
* http://blog.csdn.net/kkkkkxiaofei/article/details/12946913 sample
* http://www.programering.com/a/MTM5ADMwATc.html C# sample
