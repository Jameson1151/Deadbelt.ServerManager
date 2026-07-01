# ADR-0009: Desktop Branding Strategy

## Status

Accepted

## Context

Deadbelt has an established visual identity built around the segmented hexagonal "D" logo and the approved green, gray, black, and white color palette.

As the desktop application becomes usable, the app should visually reflect the Deadbelt brand instead of appearing like a default WPF application.

The project needs a consistent branding strategy for desktop UI, GitHub, Discord, documentation, installer assets, and future website usage.

## Decision

DOP will use a single canonical Deadbelt logo asset as the primary desktop branding mark.

The logo will be used in:

* Main application header
* Dialog headers
* Application icon
* GitHub organization/profile assets
* Discord server profile
* Documentation
* Installer assets
* Future website assets

The desktop application will use a dark-theme-first visual style aligned with the approved Deadbelt palette.

The initial runtime logo display uses an `ImageBrush` with a WPF pack URI because this rendered reliably at runtime while the direct `Image.Source` approach displayed in the Visual Studio designer but did not appear consistently when the application launched.

## Alternatives Considered

### Text-Only Branding

Rejected because the application did not visually reflect the project identity.

### Multiple Logo Variations

Rejected for the MVP because it risks inconsistent branding across GitHub, Discord, desktop, documentation, and installer assets.

### Direct Image Control Only

Deferred because the image appeared in the designer but did not render reliably at runtime during initial testing.

## Consequences

### Positive

* Desktop application now visually reflects the Deadbelt brand.
* Screenshots are more polished and recognizable.
* Future UI work has a stronger visual foundation.
* A single canonical logo reduces branding inconsistency.
* Branding can be reused across app, repository, Discord, documentation, and installer assets.

### Negative

* Branding assets must be maintained carefully.
* Future changes to the canonical logo may require updates across multiple surfaces.
* WPF image resource handling requires careful configuration.

## Related Documents

* docs/architecture/design-principles.md
* docs/architecture/technology-stack.md
* docs/adr/ADR-0007-WPF-Desktop-For-Initial-Client.md
* docs/README.md
