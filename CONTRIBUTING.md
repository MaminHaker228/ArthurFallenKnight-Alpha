# Contributing to Arthur: Fallen Knight

Thank you for your interest in contributing! This document provides guidelines and instructions.

## Types of Contributions

### Code Contributions
- Bug fixes
- New gameplay features
- Performance optimizations
- Code refactoring
- Test coverage improvements

### Content Contributions
- Sprite artwork (32x32 pixel style)
- Background music
- Sound effects
- Voice acting
- Dialogue writing

### Documentation
- Typo fixes
- Clarifications
- New guides
- Examples
- Translations

## Getting Started

1. **Fork the repository**
   ```bash
   git clone https://github.com/YOUR-USERNAME/ArthurFallenKnight-Alpha.git
   cd ArthurFallenKnight-Alpha
   ```

2. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Make your changes**
   - Follow code style guidelines (see below)
   - Write descriptive commit messages
   - Add comments for complex logic

4. **Test your changes**
   - Play through affected levels
   - Check for bugs and edge cases
   - Verify no regressions

5. **Submit a pull request**
   - Describe what you changed and why
   - Reference related issues
   - Include screenshots if applicable

## Code Style Guidelines

### C# Conventions
```csharp
// Class names: PascalCase
public class PlayerController : MonoBehaviour
{
    // Private fields: camelCase with underscore prefix
    private float _moveSpeed = 5f;
    
    // Public properties: PascalCase
    public float MaxHealth { get; set; }
    
    // Methods: PascalCase
    public void Attack(int direction)
    {
        // Implementation
    }
    
    // Local variables: camelCase
    float attackDamage = 10f;
}
```

### Naming Conventions
- Classes: `PlayerController`, `EnemyAI`, `InventoryManager`
- Methods: `GetHealth()`, `TakeDamage()`, `UpdateAnimation()`
- Fields: `_health`, `maxStamina`, `isBlocking`
- Constants: `MAX_SPEED`, `DASH_COOLDOWN`

### Comments
```csharp
// Use clear, concise comments
// Bad: increment counter
counter++;

// Good: increase combo counter for damage multiplier
comboCounter++;

// Use XML comments for public methods
/// <summary>
/// Calculates damage with combo multiplier applied.
/// </summary>
/// <param name="baseDamage">Base attack damage</param>
/// <returns>Calculated damage with multiplier</returns>
public float CalculateDamage(float baseDamage)
{
    return baseDamage * (0.8f + comboCount * 0.1f);
}
```

## Commit Messages

Use clear, descriptive commit messages:

```
Add enemy patrol feature

- Enemies now patrol between waypoints
- Patrol direction changes at boundaries
- Detection range triggers chase behavior

Fixes #123
```

**Format:**
- First line: 50 characters or less, describe the change
- Blank line
- Detailed explanation (if needed)
- Reference issues with "Fixes #123" or "Related to #456"

## Pull Request Process

1. **Update Documentation**
   - Update README if adding features
   - Update CHANGELOG.md
   - Add code comments for complex logic

2. **Testing**
   - Test in Unity Editor
   - Play through affected levels
   - Check for any warnings/errors

3. **Code Review**
   - Address feedback promptly
   - Keep commits clean and logical
   - Update your branch with main if behind

4. **Merge**
   - PR will be merged after approval
   - Delete your feature branch after merge

## Asset Submission

### Sprites
- **Format:** PNG with transparency
- **Size:** 32x32 or 48x48 pixels (pixel-perfect)
- **Style:** Dark fantasy aesthetic, matching existing art
- **Animations:** Multiple frames in single files or separate files
- **Naming:** `character_action_frame.png`

### Audio
- **Format:** WAV or MP3 (high quality)
- **Sampling:** 44.1 kHz minimum
- **Location:** `Assets/Resources/Audio/`
- **Naming:** `music_exploration.wav`, `sfx_attack_01.wav`

### Dialogue
- **Format:** JSON with proper encoding
- **Language:** Both RU and EN versions
- **Location:** `Assets/Resources/Localization/`

## Reporting Issues

When reporting bugs:

1. **Use a clear title**
   - "Combat: Attack doesn't hit enemies to the left"
   - NOT "Game broken"

2. **Describe the issue**
   - What happens
   - What should happen
   - Steps to reproduce

3. **Include details**
   - Unity version
   - Platform (Windows/Linux/macOS)
   - Screenshots or video

4. **Example format**
   ```markdown
   # Bug: Player takes damage while blocking
   
   ## Description
   When blocking with K key, player still takes full damage from enemy attacks.
   
   ## Steps to Reproduce
   1. Start Level_CursedForest
   2. Walk toward Shadow Warrior
   3. Press K to block
   4. Let enemy attack while blocking
   
   ## Expected Behavior
   Damage should be reduced by 50% while blocking
   
   ## Actual Behavior
   Player takes full damage
   
   ## Environment
   - Unity: 2022.3.0f1
   - Platform: Windows 10
   ```

## Feature Requests

Have an idea for a new feature? 

1. **Check existing issues** to avoid duplicates
2. **Create a detailed proposal** including:
   - What the feature is
   - Why it would improve the game
   - How it would work
   - Any potential impact on existing code

3. **Example format**
   ```markdown
   # Feature: Double-jump ability
   
   ## Description
   Allow Arthur to perform a double-jump by pressing Space twice quickly.
   
   ## Use Cases
   - Dodge attacks more effectively
   - Reach higher platforms (future levels)
   - Add player expression in movement
   
   ## Implementation Details
   - Track air state (grounded/airborne)
   - Count space presses
   - Apply velocity on second press
   - Visual effect for clarity
   
   ## Concerns
   - May break level design (check collision)
   - Needs animation frames
   ```

## Community Guidelines

- Be respectful and constructive
- Avoid spam or self-promotion
- Help others when you can
- Credit others' contributions
- Ask questions politely

## Contact

- **Issues:** Use GitHub issues for bugs and features
- **Discussions:** Use GitHub discussions for questions
- **Questions:** Ask in pull request comments

## License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

## Recognizing Contributions

Contributors will be recognized in:
- CONTRIBUTORS.md file
- GitHub contributors page
- In-game credits (for significant contributions)

Thank you for making Arthur: Fallen Knight better!
