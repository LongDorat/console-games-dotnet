# Console Games .NET 9.0

A collection of nostalgic console-based games built with the latest .NET 9.0 framework. Experience classic gaming directly in your terminal with modern implementations of timeless favorites.

## Table of Contents

- [Overview](#overview)
- [Games Collection](#games-collection)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Overview

This project aims to bring back classic games as console-based applications using .NET 9.0. Each of the game might have its own experimental feature both in funtionality and code structure. This project provided educational purpose to demonstrate how to implement games in console applications using modern C# features and practices.

## Games Collection

| Game | Description | Difficulty | Status |
|------|-------------|------------|--------|
| Minesweeper | Classic mine-clearing puzzle game where players must uncover cells while avoiding hidden mines | Easy | Working |
| Snake | Navigate a growing snake to collect food without hitting walls or itself | N/A | Coming Soon |
| Tetris | Arrange falling blocks to create complete lines | N/A | Coming Soon |

## Installation

### Requirements

- .NET 9.0 SDK or Runtime (Download from [.NET website](https://dotnet.microsoft.com/download/dotnet/9.0))
- Any terminal that supports Unicode characters for best experience

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/LongDorat/console-games-dotnet.git
   ```
2. Navigate to the project directory:
   ```bash
   cd console-games-dotnet
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the solution:
   ```bash
   dotnet build
   ```


## Usage

### Visual Studio

1. Open the solution in Visual Studio 2022 or later
2. Select the game you want to play from Solution Explorer
3. Right-click on the project and select "Set as Startup Project"
4. Press F5 or click the "Start" button to launch the game

### Command Line

1. Navigate to the game project directory
	```bash
	cd Projects/Minesweeper
	```
2. Run the game using:
   ```bash
   dotnet run
   ```

## Contributing

Contributions make this project better! Here's how you can contribute:

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Guidelines

- Follow the existing code style and patterns
- Update documentation as needed

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
