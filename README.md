Ensure the following are installed on your system:

- **.NET 9 SDK or later**: [Download .NET SDK](https://dotnet.microsoft.com/download)
- **Node.js (v14 or later)**: [Download Node.js](https://nodejs.org/)
- **Angular CLI**: Install globally using `npm install -g @angular/cli`
- **SQLite**: [Download SQLite](https://www.sqlite.org/download.html) (if not already installed)

## 📁 Project Structure

```
AtmApp/
├── AtmApp/                # ASP.NET Core backend
└── stargate-ui/      # Angular frontend
```

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/pgbaeten/AtmApp.git
```

### 2. Setup the Backend

Navigate to the backend project directory:

```bash
cd AtmApp
```

Restore dependencies:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

The backend API is configured to run at https://localhost:7212. This port was assigned by default when the project was initially created, and the Angular project’s service files currently reference this hardcoded base URL.

When running the API with dotnet run, ensure that it uses port 7212 for compatibility. If a different port is assigned, you will need to either:

Reconfigure the backend to run on port 7212, or

Update the base URLs in the Angular project's service files to match the new port.

### 3. Setup the Frontend
This is an Angular project setup under the folder StargateUI

Open a new terminal window and navigate to the frontend directory:

```bash
cd stargate-ui
```

Install dependencies:

```bash
npm install
```

Start the Angular development server:

```bash
ng serve
```

The frontend should now be accessible at `http://localhost:4200`.

**I used ChatGPT and Copilot to help with this coding excercise in a few ways below:
**

Generate and refine this README file

Help implement parts of the Angular UI (HTML templates)

Assist in debugging and resolving various issues during development
