# Changelog

All notable changes to Arthur: Fallen Knight will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.0-alpha] - 2025-12-10

### Added
- **Core Game Systems**
  - Player controller with A/D movement and spacebar dash
  - Combat system with attack/block/parry mechanics
  - Combo counter system (1-3 hit combinations)
  - Health and stamina tracking
  - Particle effect framework
  - Camera shake system
  - Basic animation state machine

- **Enemy AI**
  - Patrol behavior with waypoints
  - Chase behavior when player detected
  - Melee and ranged attack patterns
  - Dynamic target prioritization
  - Death animation and loot dropping

- **Mini-Boss**
  - Twisted Knight boss with 2 phases
  - Phase 1: Basic combo attacks and wave slashes
  - Phase 2: Enhanced speed, dash rushes, shockwaves
  - Health threshold-based phase transitions
  - Special attack patterns and telegraphs

- **Dialogue System**
  - JSON-based dialogue management
  - Text typing animation
  - Portrait system (ready for artwork)
  - Branching dialogue support
  - Auto-language detection

- **Inventory & Equipment**
  - RPG-style inventory management
  - Item rarity system (Common/Rare/Legendary)
  - Equipment slots (weapon/armor/artifact)
  - Item descriptions and metadata
  - Starting items included

- **Localization**
  - Russian localization (dialogue, UI, items)
  - English localization (dialogue, UI, items)
  - LocalizationManager for dynamic switching
  - JSON configuration files
  - UI text system ready

- **Level Design**
  - Cursed Forest main level
  - Multiple enemy spawn zones
  - Environmental hazards layout
  - Boss arena
  - Checkpoint system
  - Parallax background preparation

- **Documentation**
  - Complete Game Design Document (GDD)
  - Architecture and code documentation
  - README with quick-start guide
  - Development roadmap
  - This changelog

- **CI/CD Pipeline**
  - GitHub Actions build workflow
  - Automatic project validation
  - Release automation
  - Build artifact generation
  - Platform-specific builds (Windows/Linux/macOS)

### Technical Details

- **Language:** C# (.NET 6.0)
- **Framework:** Unity 2022.3
- **Architecture:** MVC pattern for UI, State machine for AI
- **Code Organization:** Modular scripts with clear separation of concerns
- **Testing:** Manual testing, ready for automated test suite

### Known Issues

- Placeholder sprites (32x32 and 48x48 pixel art needed)
- No audio implementation (system ready, audio files needed)
- Limited visual effects (particle system ready for enhancement)
- Single playable level
- No save system (structure ready for implementation)
- Animation states are basic (need full sprite sets)

### Placeholders Requiring Artwork

- [ ] Player character sprites (8 directions, 6 animation states)
- [ ] Enemy sprites (3 types × 4 animation states)
- [ ] Boss sprites (2 phases × 5 animation states)
- [ ] Background artwork (6 parallax layers)
- [ ] UI icons and assets
- [ ] Particle textures

### Audio Placeholders

- [ ] Background music tracks (exploration, boss, menu)
- [ ] Sound effects (combat, movement, UI)
- [ ] Voice acting (Arthur, Eileen, Enemies)
- [ ] Ambient sounds (forest, wind, whispers)

### Next Steps (Beta 0.2)

1. **Art Implementation**
   - Commission or create pixel art sprites
   - Design UI mockups and graphics
   - Create background artwork

2. **Audio Implementation**
   - Compose background music
   - Record sound effects
   - Arrange voice acting

3. **Content Expansion**
   - Design Level 2 (Burned Village)
   - Create additional enemy types
   - Write expanded dialogue

4. **Performance Optimization**
   - Profile and optimize scripts
   - Implement object pooling
   - Optimize renderer

5. **Feature Enhancement**
   - Skill tree system
   - Advanced AI behaviors
   - Save/load system

---

## [Unreleased]

### Planned for Future Releases

- Controller/gamepad support
- Save system
- Settings menu (full implementation)
- Advanced graphics options
- Achievements system
- Leaderboards
- Multiple difficulty modes
- Speedrun timer
- Photo mode

---

**Current Version:** 0.1.0-alpha  
**Last Updated:** December 10, 2025  
**Status:** Development active
