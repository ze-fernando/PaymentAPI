## Starting
### About
This api was inspired by the "pagar.me" challenge ([Documentacion here]()), made to work on my programming logic, api, database and orm.

### API
**Routes**
[{localhost}/v1/cash-in]()
- For you send your transactions from body
  
[{localhost}/v1/transactions]()
- Return all transactions for you

[{localhost}/v1/transactions/{card}]()
- Return transactions that have the card number passed in the url

### Run

Requeriments:
- Dotnet
-  Git

`git clone https://github.com/ze-fernando/PaymentAPI`

`cd PaymentAPI`

`dotnet clean`

`dotnet watch run`


<img align='center' alt='C#' src='https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white'/>
<img align='center' alt='SQLite3' src='https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white'/>
