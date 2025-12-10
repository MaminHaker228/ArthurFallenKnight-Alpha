# Arthur: Fallen Knight - Architecture Documentation

## Overview

This document describes the technical architecture of Arthur: Fallen Knight.

## Design Principles

1. **Modularity** - Each system is independent and reusable
2. **Clarity** - Code is readable and maintainable
3. **Performance** - Efficient resource usage
4. **Extensibility** - Easy to add new features

## Core Systems

### 1. Player System

**Components:**
- `PlayerController.cs` - Movement and input handling
- `PlayerCombat.cs` - Attack/block logic and hitbox detection
- `PlayerState.cs` - Health, stamina, and death states

**Data Flow:**
```
Input (A/D/Space/J/K)
  ↓
PlayerController (determines movement)
  ↓
Rigidbody2D (applies physics)
  ↓
PlayerCombat (processes attacks)
  ↓
EnemyAI (receives damage)
```

**Key Methods:**
- `HandleInput()` - Reads keyboard input
- `HandleMovement()` - Applies velocity
- `Attack()` - Creates hitbox and damages enemies
- `Block()` - Reduces incoming damage
- `TakeDamage()` - Updates health state

### 2. Enemy AI System

**Components:**
- `EnemyAI.cs` - Base enemy behavior
- `MiniBoss.cs` - Boss-specific logic
- `EnemyPatrol.cs` - Patrol waypoint management

**State Machine:**
```
Patrol → Chase → Attack → Retreat/Die
  ↑                      ↓
  ←←←←←←←←← (Out of range)
```

**Enemy Types:**
1. **Shadow Warrior** - Melee, patrol + chase
2. **Corrupted Archer** - Ranged, dodge pattern
3. **Void Entity** - Teleport, AoE attacks
4. **Twisted Knight** - Boss, 2 phases

### 3. Dialogue System

**Architecture:**
```
DialogueManager
  ↓
JSON Configuration
  ↓ (Parsed at runtime)
LocalizedDialogues (RU/EN)
  ↓
UI Display
  ↓
PlayerInput (Continue)
```

**Data Structure:**
```json
{
  "key": [
    "Character: First line",
    "Character: Second line",
    ...
  ]
}
```

**Features:**
- Auto language detection
- Type-writer animation
- Portrait system ready
- Branching support (framework ready)

### 4. Inventory System

**Architecture:**
```
InventoryManager (Singleton)
  ↓
Item Collection
  ↓
InventoryUI Display
  ↑
Player Input (I key)
```

**Data Structure:**
```csharp
class Item {
    string itemId;
    string itemName;
    string description;
    Rarity rarity;      // Common, Rare, Legendary
    int quantity;
    bool isEquipped;
}
```

**Features:**
- Add/remove items
- Equipment system
- Rarity tiers
- Stackable items

### 5. Localization System

**Architecture:**
```
LocalizationManager (Singleton)
  ↓
JSON Files (RU/EN)
  ↓
Dictionaries (In Memory)
  ↓
UI Elements (GetText)
```

**Language Support:**
- Russian (РУ)
- English (EN)
- Expandable to more languages

**Usage:**
```csharp
string text = LocalizationManager.Instance.GetText("ui_health");
```

### 6. Audio System

**Architecture:**
```
AudioManager (Singleton)
  ↓
Audio Sources (Music/SFX)
  ↓
Clip Playback
```

**Features:**
- Background music management
- SFX pooling
- Volume control (ready)
- Playlist support (ready)

### 7. Effects System

**Particle Effects:**
- Slash effect (attack visual)
- Dash effect (movement trail)
- Destruction effect (enemy death)
- Expandable to more effects

**Camera Effects:**
- Screen shake on impact
- Chromatic aberration (ready)
- Bloom (ready)

## Data Flow Diagrams

### Combat Flow
```
Player Presses J
  ↓
PlayerCombat.Attack()
  ↓
Create Hitbox at position
  ↓
Detect overlapping enemies
  ↓
For each enemy:
  - Calculate damage (with combo)
  - Enemy.TakeDamage()
  - Create hit effect
  - Camera shake
```

### Enemy Detection Flow
```
Enemy Update()
  ↓
Calculate distance to player
  ↓
IF distance < detectionRange
  ↓
  Chase player
    ↓
    IF distance < attackRange
      ↓
      Attack()
  ↓
ELSE
  ↓
  Patrol pattern
```

## Design Patterns Used

### 1. Singleton Pattern
- `DialogueManager`
- `InventoryManager`
- `LocalizationManager`
- `AudioManager`
- `CameraShake`

```csharp
public static T Instance { get; private set; }

private void Awake() {
    if (Instance == null) {
        Instance = this;
    } else {
        Destroy(gameObject);
    }
}
```

### 2. State Machine Pattern
- Player states (idle, moving, attacking, blocking, dashing)
- Enemy states (patrol, chase, attack, dead)
- Boss phases (phase 1, phase 2)

### 3. Observer Pattern
- `OnHealthChanged` delegate
- `OnInventoryChanged` delegate
- Event-driven dialogue triggers

### 4. Configuration Pattern
- JSON-based dialogue
- JSON-based item definitions
- JSON-based enemy specs

## Dependency Management

### Direct Dependencies
```
PlayerController
  ↓
PlayerCombat, PlayerState, Animator

EnemyAI
  ↓
PlayerController (to find target), Animator, Rigidbody2D

InventoryUI
  ↓
InventoryManager

DialogueUI
  ↓
DialogueManager
```

### Loose Coupling
- Systems use Singletons rather than direct references
- No circular dependencies
- Each script has single responsibility

## Performance Considerations

### Optimization Techniques

1. **Object Pooling** (Planned)
   - Reuse enemy instances
   - Reuse particle effects
   - Reuse bullets/projectiles

2. **Collision Detection**
   - Use layer masks for efficient queries
   - OverlapBoxAll instead of RayCasts when possible
   - Spatial hashing for large numbers of enemies

3. **Memory Management**
   - Load levels on demand
   - Unload unused resources
   - Cache frequently accessed data

### Profiling Points
- Enemy AI Update loops
- Dialogue text generation
- Particle spawning
- Collision detection calls

## File Organization

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
├── Resources/
│   ├── Localization/
│   ├── Config/
│   └── Audio/
├── Scenes/
├── Prefabs/
└── Sprites/
```

## Extension Points

### Adding a New Ability

1. Add method to `PlayerCombat.cs`
2. Add input check to `PlayerController.cs`
3. Create visual effect in `ParticleEffects.cs`
4. Add sound effect to `AudioManager.cs`
5. Update GDD.md

### Adding a New Enemy Type

1. Extend `EnemyAI.cs` or create new class
2. Define enemy type in `enemies.json`
3. Create prefab with correct components
4. Add spawn points to level
5. Test AI behavior

### Adding a New Level

1. Create new scene
2. Add player spawn point
3. Place enemy spawn points
4. Set up dialogue triggers
5. Configure checkpoint system
6. Test level flow

## Testing Strategy

### Manual Testing
- Play through each level
- Test all combat scenarios
- Verify enemy AI behavior
- Check dialogue display
- Confirm inventory works

### Automated Testing (Ready for implementation)
- Unit tests for damage calculations
- AI behavior verification
- Localization coverage
- Save/load functionality

## Documentation Standards

All public methods should have XML comments:

```csharp
/// <summary>
/// Deals damage to this enemy and applies knockback.
/// </summary>
/// <param name="damageAmount">Damage to apply</param>
/// <param name="knockbackDirection">Direction of knockback (-1, 0, or 1)</param>
/// <remarks>
/// The damage is reduced by 50% if currently blocking.
/// </remarks>
public void TakeDamage(float damageAmount, int knockbackDirection) { }
```

## Future Architecture Improvements

1. **Event System** - Use Unity Events for decoupling
2. **Service Locator** - For finding managers at runtime
3. **Object Pooling** - Reduce GC pressure
4. **Scriptable Objects** - Data-driven design
5. **Asset Bundles** - Efficient asset loading

---

**Last Updated:** December 10, 2025
**Architecture Version:** 1.0
