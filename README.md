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

The backend API should now be running at `https://localhost:{portNumber}`.
The portNumber should be shown when running dotnet run. To run correctly the port number should be set to 7212. I hardcoded the baseURL to this since that was the port it grabbed for me when I created this. The port number will either need to be set to 7212 or the services folders in the angular project need to be set to the port number that is assigned when running dotnet run.

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
