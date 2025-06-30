# Step 7 - Generate Jwt Token

A simple .NET CLI tool to **generate** and **validate** JWT tokens for sellers.  
Useful for testing and debugging token-based authentication workflows in your systems.

## 🔧 Features

- Generate JWT tokens with a seller's ID and email
- Validate existing JWT tokens
- Works via CLI or interactive terminal mode

---

## 🧪 Requirements

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or newer

---

## 🚀 Usage

### Build the project

``` bash
dotnet build
```

### Run the tool

#### Show options

``` bash
dotnet run -- --help
```

---

## 🔐 Generate a Token

### Option 1: CLI Mode

``` bash
dotnet run -- generate <sellerId> <email> <secretKey>
```

**Example:**

``` bash
dotnet run -- generate b0dbee3c-2d9c-4b57-bdcf-29c7d7d9d321 seller@example.com mysecretkey123
```

---

### Option 2: Interactive Mode

``` bash
dotnet run
```

Follow the prompts to enter:

- Seller ID
- Email
- Secret Key

---

## ✅ Validate a Token

### Option 1: CLI Mode

```bash
dotnet run -- validate <token> <secretKey>
```

**Example:**

```bash
dotnet run -- validate eyJhbGciOi... mysecretkey123
```

---

### Option 2: Interactive Mode

``` bash
dotnet run
```

Choose **"2 - Validate token"** and follow the prompts.

---

## 📁 Project Structure

``` bash
.
├── Program.cs
├── Extensions/JwtExtensions.cs        # Extension method for validating JWT
├── Payloads/WebComponentJwtPayload.cs # Model and logic for token generation
└── ...
```

---

## 🔒 Important Notes

- This tool is intended for **testing and development only**
- Do not use hardcoded secrets
