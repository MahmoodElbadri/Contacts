# Contacts App (Angular)

A simple Contacts management web app built with Angular. It lists contacts in a table and lets you add and delete contacts using a reactive form. This README provides everything needed to install, configure, run, test, and extend the project.

Last updated: 2025-09-29

## Overview

- List contacts in a responsive table.
- Add a new contact via a reactive form (name, email, phone, favourite).
- Delete existing contacts from the list.
- Data is loaded and persisted via a REST API whose base URL is configured in environment files (`environment.apiUrl`).

The UI uses Bootstrap classes and Bootstrap Icons for basic styling.

## Tech Stack

- Angular 16
- RxJS, Angular Forms (Reactive Forms)
- HttpClient
- Bootstrap + Bootstrap Icons (CSS classes used in templates)

## Prerequisites

- Node.js 18+ and npm
- Angular CLI (globally):
  - npm install -g @angular/cli
- A running backend with a REST endpoint for contacts, configured by `environment.apiUrl`

## Getting Started

1) Clone and install
- git clone <repo-url>
- cd UI/contact.web
- npm install

2) Configure API URL
- Set the backend base URL in `src/environments/environment.ts` (and `environment.prod.ts` as needed):
  - export const environment = { apiUrl: 'http://localhost:3000/contacts', production: false };
- The app expects the API to support:
  - GET    {apiUrl}              -> returns IContact[]
  - POST   {apiUrl}              -> adds a contact
  - DELETE {apiUrl}/{id}         -> deletes a contact by id

IContact model (`src/app/models/icontact.ts`) defines the TypeScript shape used by the app.

3) Run the app
- npm start
- Open http://localhost:4200

Alternative: use Angular CLI directly
- ng serve

## Build

- Production build: ng build
- Output goes to dist/

## Scripts

- npm start          -> ng serve
- npm run build      -> ng build
- npm test           -> ng test (if tests are added)
- npm run lint       -> ng lint (if ESLint is configured)

## Configuration Details

- API base URL is read from `environment.apiUrl` in `src/environments/*`.
- AppComponent performs HTTP operations in-place (a future improvement is to extract a ContactsService).
- Reactive form is defined in `app.component.ts` and bound in `app.component.html`.

## Project Structure (key files)

- src/app/app.component.ts        -> Fetch, add, and delete contacts; reactive form
- src/app/app.component.html      -> Table + form layout
- src/app/app.component.scss      -> Styles for layout
- src/app/models/icontact.ts      -> IContact interface
- src/environments/*              -> environment variables (apiUrl)

## Usage

- Add a contact: Fill out the form and click "Add Contact". The list refreshes automatically.
- Delete a contact: Click the trash icon in the row. A simple alert appears after deletion.

## Known Limitations

- No edit functionality yet.
- No search/filter/sort or pagination.
- Minimal validation on the form.
- Deletion has no confirmation dialog.
