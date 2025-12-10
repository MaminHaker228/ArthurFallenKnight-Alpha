# Arthur: Fallen Knight - Alpha

**Dark Fantasy 2D pixel-art game** inspired by *Katana Zero*, set in the universe of "Fallen Knight"

## 🎮 Quick Start

### Requirements
- Unity 2022.3+ 
- .NET 6.0+
- Git

### Setup
```bash
git clone https://github.com/MaminHaker228/ArthurFallenKnight-Alpha.git
cd ArthurFallenKnight-Alpha
```

Open the project in Unity Hub → Play in Editor

### Controls
- **A/D** - Walk
- **Space** - Dash
- **J** - Attack
- **K** - Block/Parry
- **I** - Inventory
- **E** - Interact

---

## 📋 Features (Alpha)

### ✅ Implemented
- [x] Player controller with movement & dash
- [x] Combat system (attack/block/parry)
- [x] Enemy AI (patrol, chase, attack patterns)
- [x] Mini-boss fight (Twisted Knight - 2 phases)
- [x] Dialogue system with localization (RU/EN)
- [x] Inventory & item system
- [x] Particle effects (slashes, dashes, particles)
- [x] Camera shake & screen effects
- [x] Level design (Cursed Forest)
- [x] Cinematic scenes (Timeline + Cinemachine)
- [x] UI system (Health, Stamina, Inventory)

### 🔶 In Progress
- [ ] Additional enemy types (3 base types designed)
- [ ] More cutscenes (3 major cinematic scenes planned)
- [ ] Audio system (music & SFX slots ready)
- [ ] Advanced particle effects

### 📅 Roadmap (Beta/Release)
- Expanded level design (Village, Forest Hut, Parallel dimensions)
- Additional mini-bosses
- Skill tree & ability progression
- New dialogue branches
- Full soundtrack & voice acting
- Steam integration

---

## 🎨 Art Style

**32×32 & 48×48 pixel sprites** in dark fantasy aesthetic:
- Sprite-based character animations
- Parallax backgrounds (5-6 layers)
- Particle fog, ash, sparks
- Screen effects (bloom, chromatic aberration)

---

## 🏗️ Project Structure

```
Assets/
├── Scripts/
│   ├── Player/
│   │   ├── PlayerController.cs
│   │   ├── PlayerCombat.cs
│   │   └── PlayerState.cs
│   ├── Enemies/
│   │   ├── EnemyAI.cs
│   │   ├── MiniBoss.cs
│   │   └── EnemyPatrol.cs
│   ├── Systems/
│   │   ├── DialogueManager.cs
│   │   ├── InventoryManager.cs
│   │   ├── LocalizationManager.cs
│   │   └── AudioManager.cs
│   ├── Effects/
│   │   ├── ParticleEffects.cs
│   │   └── CameraShake.cs
│   └── UI/
│       ├── InventoryUI.cs
│       └── DialogueUI.cs
├── Scenes/
│   ├── MainMenu.unity
│   ├── Level_CursedForest.unity
│   └── MiniBoss_Arena.unity
├── Prefabs/
│   ├── Player.prefab
│   ├── Enemies/
│   ├── UI/
│   └── Effects/
├── Resources/
│   ├── Localization/
│   │   ├── dialogue_ru.json
│   │   ├── dialogue_en.json
│   │   └── items.json
│   ├── Audio/
│   └── Sprites/
└── Documentation/
    └── GDD.md
```

---

## 🎮 Gameplay

### Combat System
- **Attack combos** - chain hits for increased damage
- **Blocking** - reduce incoming damage
- **Parrying** - counter with perfect timing
- **Dash** - invulnerable movement ability

### Enemy Types
1. **Shadow Warrior** - melee, patrol + attack
2. **Corrupted Archer** - ranged, dodge patterns
3. **Void Entity** - teleportation, AoE attacks

### Mini-Boss: Twisted Knight
- **Phase 1** - Basic combos, wave attacks
- **Phase 2** - Enhanced speed, dash rushes, shockwaves
- **Rewards** - Twisted Knight Trophy (inventory item)

---

## 🎬 Cinematics

Integrated Timeline + Cinemachine for:
1. **Prologue** - Forest intro, Arthur's backstory
2. **Eileen Appears** - Character introduction
3. **Boss Finale** - Twisted Knight encounter

---

## 🗣️ Dialogue & Localization

### Supported Languages
- 🇷🇺 Russian
- 🇬🇧 English

### Features
- Character portraits
- Dialogue branching
- Arthur's internal monologue
- Enemy dialogue (whispers of ancient darkness)
- Auto language switching via system settings

---

## 💼 Inventory System

### Mechanics
- Add/remove items
- Equip system (weapon/armor/artifacts)
- Item rarity (Common/Rare/Legendary)
- Item descriptions & stats

### Starting Items
- Memory Fragment (x1)
- Healing Potion (x3)
- Dark Artifact (x1)
- Blade Shard (x1)

---

## 🔧 CI/CD Pipeline

**GitHub Actions** automation:
- ✅ Auto-build on push (Windows/Linux/macOS)
- ✅ Auto-generate releases
- ✅ Auto-test project integrity
- ✅ Auto-package as ZIP

See `.github/workflows/` for config.

---

## 📖 Game Design Document

Full GDD available in `Documentation/GDD.md` with:
- Complete lore & worldbuilding
- Character profiles
- Enemy design specs
- Level layouts
- Progression systems
- Audio direction
- Technical architecture

---

## 🛠️ Development Notes

### Code Structure
- **MVC pattern** for UI
- **State machine** for player/enemy behaviors
- **Event-driven** dialogue system
- **JSON configuration** for localization & items

### Performance
- Object pooling for effects
- Layer-based rendering
- Sprite batching
- Optimized collision detection

---

## 🎵 Audio (Placeholder System)

Audio slots ready for:
- Background music (explored/boss/intro)
- SFX (attack, parry, damage, death)
- Ambient sounds (forest, wind, whispers)
- Voice acting support

---

## 🤝 Contributing

This is the **alpha build**. Contributions welcome for:
- Sprite art improvements
- Music & sound design
- Level design
- Dialogue writing
- Bug reports

---

## 📄 License

MIT License - Free for modification & distribution

---

## 👥 Credits

**Design & Development:**
- Combat system: Katana Zero-inspired
- Universe: "Fallen Knight" lore
- Alpha build: Complete from scratch

**Assets:** Sprites & audio ready for professional artists

---

## 📬 Contact & Support

- **GitHub Issues:** [Report bugs](https://github.com/MaminHaker228/ArthurFallenKnight-Alpha/issues)
- **Discussions:** [Join the community](https://github.com/MaminHaker228/ArthurFallenKnight-Alpha/discussions)

---

**Status:** 🟡 ALPHA (Core gameplay functional, art/audio placeholders)

**Last Updated:** December 10, 2025