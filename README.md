# netcore-api

net core api requests demo

This is a `.net core` project (2.1.300)

## run project

clone repository

```git clone https://github.com/fesaza/netcore-api.git```

Build and run

```dotnet build```

```dotnet run```

## test

test the following urls, the browser will display a login window. user: `my_user` password: ``my_password`

Get articles list

```http://localhost:5000/api/services/articles```

Get stores list

```http://localhost:5000/api/services/stores```

Get articles by store id

```http://localhost:5000/api/services/articles/stores/1```
