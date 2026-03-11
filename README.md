# Github User Activity CLI

A simple .NET CLI application that fetches and displays the recent activity of a GitHub user using the GitHub public API.

This project was built as a practice project to work with:

- HTTP requests
- JSON deserialization
- CLI applications in .NET
- Clean project structure

## Features

- Fetch recent activity of any GitHub user
- Display activity in a readable format
- Handle invalid usernames or API errors
- Simple command-line interface

## Tech Stack

- .NET
- C#
- GitHub REST API
- System.Text.Json
- HttpClient

## Installation

Clone the repository:

```
git clone https://github.com/VuongNguyen2393/GithubUserActivity.git
```

Navigate to the project:

```
cd GithubUserActivity
```

Build the project:

```
dotnet build
```

Run the application:

```
dotnet run
```

## Usage

Run the CLI and enter a GitHub username:

```
dotnet run <username>
```
