# Game Design Document
## Arthur: Fallen Knight - ALPHA

---

# 1. EXECUTIVE SUMMARY

**Title:** Arthur: Fallen Knight
**Genre:** 2D Dark Fantasy Action-Adventure
**Platform:** PC (Windows/Linux/macOS)
**Engine:** Unity 2022.3+
**Target Audience:** Fans of dark fantasy, fast-paced combat (Katana Zero, Hollow Knight)
**Status:** Alpha (Core gameplay functional)

---

# 2. HIGH CONCEPT

A dark, atmospheric 2D action game where the player controls **Arthur**, a cursed knight, through the **Cursed Forest** of the "Fallen Knight" universe. The game features **fast-paced combat** similar to Katana Zero, with a focus on timing, positioning, and combo-based attacks.

**Core Loop:**
1. Navigate through dark environments
2. Encounter enemies (patrol, chase, attack)
3. Engage in combat using attack/block/parry mechanics
4. Defeat mini-boss (Twisted Knight)
5. Uncover story through dialogue and cinematics
6. Manage inventory and equipment

---

# 3. UNIVERSE & LORE

## 3.1 Setting: The Fallen Knight Universe

In a world consumed by ancient darkness, **knights** were cursed to become its servants. Arthur was once a noble warrior, but fell victim to the curse. Now, caught between humanity and corruption, he must survive the **Cursed Forest** and confront the source of his suffering.

## 3.2 Key Locations
- **Cursed Forest** - Primary level, dense with fog, dead trees, and dark entities
- **Forest Hut** - Shelter where Eileen waits (future expansion)
- **Burned Village** - Ruins of civilization (future expansion)
- **Twisted Dimension** - Boss arena (future expansion)

## 3.3 Factions
- **The Corrupted** - Former humans twisted by darkness (enemies)
- **The Remnants** - Survivors seeking redemption (Eileen, NPCs)
- **Ancient Darkness** - Sentient force consuming the world (antagonist)

---

# 4. CHARACTERS

## 4.1 Arthur (Player Character)
- **Role:** Protagonist, cursed knight
- **Goal:** Survive and resist the darkness consuming him
- **Personality:** Quiet, haunted, determined
- **Abilities:** Sword combat, dashing, blocking
- **Arc:** From despair → finding purpose with Eileen

## 4.2 Eileen
- **Role:** Support character, Arthur's connection to humanity
- **Goal:** Save Arthur from the curse
- **Personality:** Brave, empathetic, mysterious
- **Appearance:** Silhouette (hidden face, future reveal)
- **Role in Alpha:** Dialogue trigger for cinematic

## 4.3 Twisted Knight (Mini-Boss)
- **Role:** First major obstacle, embodiment of the curse
- **Goal:** Eliminate Arthur and spread corruption
- **Personality:** Rage, hunger, monstrously distorted
- **Origin:** Once a great warrior, now fully consumed
- **Lore:** Serves as a warning of Arthur's potential fate

## 4.4 Ancient Darkness (Sentient Force)
- **Role:** Main antagonist (unseen in Alpha)
- **Goal:** Consume all light and free will
- **Manifestation:** Whispers, shadows, the curse itself

---

# 5. GAMEPLAY MECHANICS

## 5.1 Movement & Mobility
- **Walk:** A/D keys (variable speed based on input)
- **Dash:** Spacebar (invulnerable dash, 15 units/sec, 0.2s duration, 0.5s cooldown)
- **Direction:** Automatically faces enemy or input direction

## 5.2 Combat System

### 5.2.1 Attack
- **Input:** J key
- **Damage:** 10 base + combo multiplier (1.0x to 3.0x)
- **Hitbox:** 1x1 unit, 0.5 offset (extends in facing direction)
- **Cooldown:** 0.3 seconds
- **Animation:** Auto-plays (3 combo stages)

### 5.2.2 Block & Parry
- **Input:** K key
- **Effect:** Reduces incoming damage by 50%
- **Duration:** 0.5 seconds
- **Cooldown:** Minimal (resets combo)
- **Visual:** Shield animation

### 5.2.3 Combo System
- **Chain Requirement:** Attack within cooldown windows
- **Stages:** 1x (10 dmg), 2x (11 dmg), 3x (13 dmg)
- **Reward:** Higher damage + visual feedback
- **Reset:** Block breaks combo

## 5.3 Health & Stamina

### Health System
- **Max HP:** 100 (player adjustable)
- **Damage Feedback:** Screen tint, camera shake
- **Death State:** Game over, restart level

### Stamina (Not yet implemented in Alpha)
- **Max Stamina:** 100
- **Regeneration:** 5 units/sec (passive)
- **Future Use:** Ability gating, special moves

## 5.4 Inventory & Equipment
- **Inventory Limit:** 20 slots (upgradeable)
- **Item Types:** Consumables, weapons, artifacts, quest items
- **Rarity Tiers:** Common, Rare, Legendary
- **Equip System:** One active weapon, armor, artifact
- **UI Access:** I key toggles inventory

## 5.5 Dialogue & Story
- **Trigger:** Environmental collision or event script
- **Display:** Text box with character portraits (future)
- **Branching:** Linear in Alpha, expandable
- **Localization:** Russian & English (JSON-driven)

---

# 6. LEVEL DESIGN

## 6.1 Alpha Level: Cursed Forest

### Layout
- **Start Zone:** Forest clearing (player spawn)
- **Exploration Zone:** Dense trees, fog, parallel paths
- **Hut Zone:** Shelter with cinematic trigger
- **Boss Arena:** Open clearing (Twisted Knight fight)

### Enemies
- **Shadow Warriors:** 3-4 patrolling (melee)
- **Corrupted Archers:** 1-2 ranged (rooftop positions)
- **Void Entities:** 1-2 (teleporting, AoE)

### Environmental Features
- **Fog:** Parallax layers, atmospheric fog particles
- **Destructibles:** Dead trees (aesthetic, no interaction in Alpha)
- **Platforms:** Ground-only (2D side-scroller)
- **Checkpoints:** 2 (mid-level, boss entrance)

## 6.2 Level Progression
1. **Zone 1:** Explore, encounter first Shadow Warrior
2. **Zone 2:** Mid-level cinematic (Eileen appears)
3. **Zone 3:** Boss arena, fight Twisted Knight
4. **Conclusion:** Victory cutscene (planned for Beta)

---

# 7. ENEMY DESIGN

## 7.1 Shadow Warrior
- **HP:** 30
- **Damage:** 5
- **Behavior:** Patrol → Chase → Melee attack
- **Abilities:** Basic combo, knockback
- **Loot:** Memory fragments, common items

## 7.2 Corrupted Archer
- **HP:** 25
- **Damage:** 7
- **Behavior:** Patrol (ranged position) → Shoot → Dodge
- **Abilities:** Arrow attack (AoE impact), dodge pattern
- **Loot:** Rare items, crafting materials

## 7.3 Void Entity
- **HP:** 40
- **Damage:** 8
- **Behavior:** Teleport → AoE attack → Summon shadows
- **Abilities:** Blink teleport, shockwave, temporary summons
- **Loot:** Artifacts, dark essence

## 7.4 Twisted Knight (Mini-Boss)

### Phase 1 (HP: 100-150)
- **Attacks:** Sword combo, wave slash
- **Speed:** 4 units/sec
- **Behavior:** Chase player, attack on proximity

### Phase 2 (HP: <75)
- **Enhanced Attacks:** Faster combos, shockwave
- **Dash Rush:** Invulnerable charge attack
- **Speed:** 4.8 units/sec (20% boost)
- **Cooldown Reduction:** 0.96s (20% faster)

---

# 8. ART & AUDIO

## 8.1 Art Direction

### Sprite Style
- **Resolution:** 32x32 / 48x48 pixel sprites
- **Aesthetic:** Dark fantasy pixel art (inspired by Hollow Knight, Celeste)
- **Color Palette:** Dark greens, blacks, blood reds, ghostly blues
- **Animation Frames:** 4-6 frames per action (walk, attack, damage)

### Background
- **Parallax Layers:** 5-6 moving layers
- **Parallax Speed:** Layer 1 (closest) = 0.8x, Layer 6 (distant) = 0.2x
- **Atmosphere:** Fog particles, falling leaves, distant lightning

### UI
- **Style:** Minimal, readable, dark theme
- **Fonts:** Monospace for health, serif for dialogue
- **Colors:** High contrast (white text on dark backgrounds)

## 8.2 Audio Direction

### Music
- **Exploration:** Ambient, haunting, minor keys (80-100 BPM)
- **Boss Fight:** Intense, orchestral, percussion-heavy (120+ BPM)
- **Menu:** Quiet, mysterious, single instrument

### SFX
- **Attack:** Metallic swish, impact sound (layered)
- **Block:** Shield chime (high-pitched)
- **Dash:** Whoosh with air displacement
- **Damage:** Impact thud, blood splatter (wet sound)
- **Enemy Death:** Scream + dissipation sound
- **Dialogue:** Subtle whispers (background layer)

### Voice Acting (Planned)
- Arthur: Deep, weary voice (EN & RU dub)
- Eileen: Warm, determined voice
- Twisted Knight: Demonic, distorted voice

---

# 9. UI/UX DESIGN

## 9.1 HUD (In-Game)

### Health Bar
- **Position:** Top-left
- **Format:** Numeric (50/100) + visual bar
- **Color:** Red gradient
- **Update:** Real-time

### Stamina Bar
- **Position:** Below health
- **Format:** Numeric + visual bar
- **Color:** Blue gradient
- **Visibility:** Shows during active usage

### Combo Counter
- **Position:** Center-bottom
- **Format:** "COMBO x3"
- **Color:** Gold/yellow (highlights with each hit)
- **Fade:** Disappears after 2 seconds of no attacks

### Minimap (Planned for Beta)
- **Position:** Top-right
- **Zoom:** 1:4 ratio
- **Icons:** Player (white), enemies (red), objectives (blue)

## 9.2 Menu UI

### Main Menu
- Start Game
- Settings (Audio, Graphics, Language)
- Credits
- Quit

### Pause Menu
- Resume
- Settings
- Exit to Main Menu

### Inventory UI
- Item list (name, rarity, icon)
- Selected item details (description, stats)
- Buttons: Use, Equip, Drop

### Dialogue Box
- Speaker name (character)
- Portrait (placeholder)
- Dialogue text (auto-scroll)
- Continue button

## 9.3 Localization
- **Supported Languages:** Russian, English
- **Auto-Detection:** System language preference
- **Manual Switch:** Settings menu
- **Text Format:** JSON files (loaded at runtime)

---

# 10. PROGRESSION & DIFFICULTY

## 10.1 Difficulty Settings (Planned)
- **Easy:** 50% damage taken, 1.5x damage dealt
- **Normal:** 1.0x all damage
- **Hard:** 1.5x damage taken, 0.7x damage dealt

## 10.2 Progression Arc
1. **Introduction:** Learn controls in safe zone
2. **Exploration:** Encounter first enemies, practice combat
3. **Escalation:** Stronger enemy types, combo requirements
4. **Boss Fight:** All skills tested against Twisted Knight
5. **Conclusion:** Story resolution, credits roll

## 10.3 Skill Gates
- **Basic Combat:** Required for all zones
- **Dash Timing:** Needed to dodge archer attacks
- **Parry:** Optional but effective against melee
- **Inventory Management:** Potion usage in boss fight

---

# 11. TECHNICAL ARCHITECTURE

## 11.1 Code Structure

### Core Systems
- **PlayerController.cs** - Input handling, movement
- **PlayerCombat.cs** - Attack/block logic, hitbox detection
- **PlayerState.cs** - Health, death state, signals
- **EnemyAI.cs** - Patrol, chase, attack patterns
- **MiniBoss.cs** - Extended AI with phases

### Management Systems
- **DialogueManager.cs** - Display and sequence dialogues
- **InventoryManager.cs** - Item storage, equipment
- **LocalizationManager.cs** - Language switching
- **AudioManager.cs** - Music and SFX playback
- **CameraShake.cs** - Screen shake effects

### UI Controllers
- **InventoryUI.cs** - Inventory display and interaction
- **DialogueUI.cs** - Dialogue box rendering
- **UIManager.cs** - Menu navigation

## 11.2 Data Structures

### Player State
```
class PlayerState {
    float health;
    float maxHealth;
    float stamina;
    int comboCount;
    bool isBlocking;
    Vector2 position;
}
```

### Enemy Type
```
class EnemyData {
    float health;
    float damage;
    float moveSpeed;
    float detectionRange;
    EnemyType type;
}
```

### Item
```
class Item {
    string itemId;
    string itemName;
    Rarity rarity;
    int quantity;
    bool isEquipped;
}
```

## 11.3 File Structure
```
Assets/
├── Scripts/
│   ├── Player/
│   ├── Enemies/
│   ├── Systems/
│   ├── Effects/
│   └── UI/
├── Resources/
│   ├── Localization/
│   ├── Config/
│   └── Audio/
├── Scenes/
├── Prefabs/
└── Sprites/
```

---

# 12. DEVELOPMENT PIPELINE

## 12.1 CI/CD (GitHub Actions)

**Automated Builds:**
- Windows (.exe)
- Linux (.x86_64)
- macOS (.app)

**On Every Commit:**
- Unity project validation
- Compile C# scripts
- Build all platforms
- Generate release ZIP
- Upload to GitHub Releases

## 12.2 Build Configuration
- Player settings:
  - Resolution: 1920x1080 (adjustable)
  - Aspect ratio: 16:9
  - V-sync: ON
  - Anti-aliasing: 4x

---

# 13. ROADMAP

## Phase 1: ALPHA (Current - December 2025)
✅ Core gameplay mechanics
✅ Player controller & combat
✅ Enemy AI & patterns
✅ Mini-boss fight
✅ Dialogue system
✅ Inventory system
✅ Localization (RU/EN)
✅ Cinematic scenes
✅ One playable level
⏳ Placeholder graphics & audio

## Phase 2: BETA (Planned - Q1 2026)
- [ ] Full sprite art implementation
- [ ] Background music & SFX
- [ ] Additional enemy types
- [ ] Level 2 (Village)
- [ ] Skill tree system
- [ ] Expanded dialogue
- [ ] Performance optimization
- [ ] Bug fixes & balancing

## Phase 3: RELEASE (Planned - Q2 2026)
- [ ] Level 3 (Parallel Dimension)
- [ ] Additional mini-bosses
- [ ] Voice acting
- [ ] Full soundtrack
- [ ] Steam integration
- [ ] Achievements & leaderboards
- [ ] Final polish

---

# 14. BALANCE & TUNING

## 14.1 Combat Balance
- **Player vs Single Enemy:** 5-10 seconds optimal fight time
- **Player vs Group:** 15-20 seconds (with strategic play)
- **Player vs Boss:** 45-90 seconds (2-3 phases)

## 14.2 Damage Values
| Source | Damage | Notes |
|--------|--------|-------|
| Player Attack (1x combo) | 10 | Base |
| Player Attack (3x combo) | 13 | +30% |
| Shadow Warrior | 5 | Single hit |
| Corrupted Archer | 7 | Ranged |
| Void Entity | 8 | AoE |
| Boss Phase 1 | 8 | Single |
| Boss Phase 2 | 12 | Enhanced |

## 14.3 Resource Management
- **Health Potion:** +50 health, carries 3 max
- **Stamina:** 100 max, regenerates 5/sec
- **Dash Cooldown:** 0.5 seconds (core escape tool)

---

# 15. REFERENCES & INSPIRATION

**Visual Style:**
- Hollow Knight (atmosphere, pixel art)
- Celeste (tight controls, challenge)
- Dead Cells (combat, enemy variety)

**Gameplay:**
- Katana Zero (fast-paced, one-hit death emphasis)
- Dark Souls (dark fantasy, boss fights)
- Hades (isometric perspective, dialogue system)

**Story:**
- Dark Souls lore structure
- Berserk manga (cursed protagonist)
- Fallen London (dark atmosphere, choice)

---

## Document Version: 1.0
## Last Updated: December 10, 2025
## Status: ALPHA

---