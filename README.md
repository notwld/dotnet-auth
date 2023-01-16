# .NET Core Authentication
Authentication with JWT in Dotnet Core

# Getting Started

Clone this repository on your local machine using,

```bash
git clone https://github.com/notwld/dotnet-auth
```

Run the application on your localhost and test the APIs on Postman or RapidAPI or ThunderClient

## API Reference

#### Login

```http
  POST /api/Login
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Username` | `string` | **Required**. Your Username. |
| `Password` | `string` | **Required**. Your Password. |

#### Admin Endpoint

```http
  GET /api/User/Admin
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Bearer`      | `string` | **Required**. Bearer Token generated when logged in. |

`Note: This endpoint is accessable to CEO only`

#### BA Endpoint

```http
  GET /api/User/BA
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Bearer`      | `string` | **Required**. Bearer Token generated when logged in. |

`Note: This endpoint is accessable to BA only`

#### BA Endpoint

```http
  GET /api/User/Manager
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Bearer`      | `string` | **Required**. Bearer Token generated when logged in. |

`Note: This endpoint is accessable to Manager only`


