# Running the Application Locally

## Prerequisites

*   .NET SDK (version 7 or higher)
*   Node.js (version 16 or higher)
*   npm (Node Package Manager)

## Backend Setup (C# .NET)

1.  Navigate to the `backend` directory:

    ```bash
    cd backend
    ```

2.  Restore dependencies:

    ```bash
    dotnet restore
    ```

3.  Run the application:

    ```bash
    dotnet run
    ```

    The backend will start on `http://localhost:5000` (or a similar port).

## Frontend Setup (React)

1.  Navigate to the `frontend` directory:

    ```bash
    cd frontend
    ```

2.  Install dependencies:

    ```bash
    npm install
    ```

3.  Start the development server:

    ```bash
    npm start
    ```

    The frontend will be accessible at `http://localhost:3000`.

## Notes

*   Ensure the backend is running before starting the frontend.
*   The frontend is configured to communicate with the backend at `http://localhost:5000`.  Adjust the `API_URL` environment variable in `.env` if necessary.
*   If you encounter any issues, ensure all dependencies are installed correctly and that the backend and frontend are running on the correct ports.