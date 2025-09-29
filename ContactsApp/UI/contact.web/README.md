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

- Core CRUD enhancements
  - Edit contact: Add an edit button to load a contact into the form and update it via PUT/PATCH.
  - Toggle favourite: Click the star to toggle favourite without opening a form (optimistic update).
  - Confirm delete: Show a confirmation dialog; optionally support Undo for a few seconds.
  - Inline validation: Required, email format, and phone pattern; show helpful messages.

- Discoverability and organization
  - Search: Client-side search box filtering by name, email, or phone.
  - Filters: Show only favourites; filter by first letter; custom filters.
  - Sorting: Sort by name, email, or favourite. Preserve sort and filter state in the URL.
  - Pagination/virtual scroll: For large lists; server-side pagination support if backend allows.

- Data richness
  - Extra fields: Address, company, job title, notes, tags/labels, birthday.
  - Avatars: Initials-based avatars or user-uploaded photos.
  - Groups/labels: Create and assign contacts to groups; filter by group.
  - Birthdays and reminders: Optional notification/reminder integration.

- Import/Export and bulk operations
  - Import: CSV/Excel import with mapping preview and duplicate detection.
  - Export: CSV/Excel export of selected or filtered contacts.
  - Bulk actions: Select multiple contacts to delete, label, or favourite in one step.

- UX polish
  - Loading and empty states: Spinners/skeletons and friendly empty-state prompts.
  - Toast notifications: Success and error toasts for add/update/delete.
  - Responsive layout: Ensure table/form layout stacks nicely on small screens.
  - Dark mode toggle.
  - Keyboard shortcuts: e.g., "N" for new contact, "/" to focus search.

- Reliability and performance
  - Retry and error handling: Graceful error UI with retry button for network failures.
  - Optimistic UI for quick feedback with rollback on failure.
  - Caching: Cache contacts list; incremental updates after mutations.
  - Environment configs: Use environment.ts for API URLs, feature flags.

- Accessibility (a11y)
  - Semantic markup and ARIA roles for table and form controls.
  - Proper label/for/id associations and focus management on dialog open/close.
  - Color contrast and keyboard navigability.

- Testing and quality
  - Unit tests for services and components (form validators, HTTP calls).
  - Integration/E2E tests for key flows (add, edit, delete, search, filter).
  - Linting and formatting: Enforce with ESLint and Prettier.

- Progressive features
  - PWA: Add service worker for offline viewing and basic add/edit queueing.
  - Internationalization (i18n): Translate labels and messages; RTL support.

Implementation tips
- Start with small wins: search, filters, edit, confirmation dialogs, and toasts.
- Keep UI state (search, filters, sort) in query params to enable deep links.
- Extract HTTP calls into a ContactsService to simplify components and testing.
- Consider a model interface update (IContact) when adding new fields.
