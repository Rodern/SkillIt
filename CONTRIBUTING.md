# Contributing to SkillIT

First off, thank you for considering contributing to SkillIT! It's people like you that make SkillIT such a great tool for African tech education.

## Code of Conduct

This project and everyone participating in it is governed by our Code of Conduct. By participating, you are expected to uphold this code.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the issue list as you might find out that you don't need to create one. When you are creating a bug report, please include as many details as possible:

* **Use a clear and descriptive title**
* **Describe the exact steps which reproduce the problem**
* **Provide specific examples to demonstrate the steps**
* **Describe the behavior you observed after following the steps**
* **Explain which behavior you expected to see instead and why**
* **Include screenshots if possible**

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, please include:

* **Use a clear and descriptive title**
* **Provide a step-by-step description of the suggested enhancement**
* **Provide specific examples to demonstrate the steps**
* **Describe the current behavior and explain which behavior you expected to see instead**
* **Explain why this enhancement would be useful**

### Pull Requests

* Fill in the required template
* Do not include issue numbers in the PR title
* Follow the C# coding style guide
* Include XML documentation comments
* Add unit tests for new features
* Update the README.md with details of changes if needed
* Update the CHANGELOG.md

## Development Process

### Setting Up Development Environment

1. Fork the repository
2. Clone your fork: `git clone https://github.com/your-username/SkillIt.git`
3. Create a branch: `git checkout -b feature/my-new-feature`
4. Set up user secrets (see SETUP_USER_SECRETS.md)
5. Run the database migrations
6. Make your changes
7. Run tests: `dotnet test`
8. Commit your changes: `git commit -am 'Add some feature'`
9. Push to the branch: `git push origin feature/my-new-feature`
10. Submit a pull request

### Coding Style

* Follow Microsoft's C# Coding Conventions
* Use meaningful variable and method names
* Add XML documentation comments for public APIs
* Keep methods focused and small
* Use async/await for I/O operations
* Handle exceptions appropriately
* Use dependency injection
* Follow SOLID principles

### Commit Messages

* Use the present tense ("Add feature" not "Added feature")
* Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
* Limit the first line to 72 characters or less
* Reference issues and pull requests liberally after the first line

### Branch Naming

* `feature/` - New features
* `bugfix/` - Bug fixes
* `hotfix/` - Urgent fixes for production
* `refactor/` - Code refactoring
* `docs/` - Documentation changes
* `test/` - Adding or updating tests

## Testing

* Write unit tests for all new features
* Ensure all tests pass before submitting PR
* Aim for >80% code coverage
* Use meaningful test names that describe what is being tested

## Documentation

* Update README.md for new features
* Add XML comments to public APIs
* Update API_DOCUMENTATION.md for API changes
* Keep CHANGELOG.md up to date

## Questions?

Feel free to create an issue with your question, or reach out to the maintainers directly.

## Recognition

Contributors will be recognized in the project README.md.

Thank you for contributing to SkillIT! 🎉
