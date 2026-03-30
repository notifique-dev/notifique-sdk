# Contributing Guide

Thanks for contributing to Notifique SDK.

## Branch and PR policy

- Never push directly to `main`.
- Create a feature branch from `main`.
- Open a pull request and wait for approval(s).
- All required checks must pass before merge.

## Commit standard

Use Conventional Commits whenever possible:

- `feat: ...`
- `fix: ...`
- `refactor: ...`
- `docs: ...`
- `test: ...`
- `chore: ...`

## Development basics

- Install dependencies: `npm ci`
- Run test suite: `npm test`
- Keep changes scoped and small per PR.
- Update docs when public API behavior changes.

## Multi-SDK changes

When changing API contracts, verify impacted SDKs:

- Node/TypeScript
- Python
- Go
- Java
- .NET
- PHP
- Elixir

## Security and secrets

- Never commit secrets, tokens, private keys, or `.env` files.
- Use GitHub Security Advisories for vulnerability disclosure (see `SECURITY.md`).
