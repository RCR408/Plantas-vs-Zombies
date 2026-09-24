# Tower Defense Game

A tower-defense game built in Unity, where the player manages a resource economy to place defenders and survive waves of enemies.

## Features
- Resource ("sun") economy: earn currency over time and spend it to place defenders
- 4 defender types with different roles (ranged attacker, ranged attacker with a freeze effect, melee/blocker, and a resource generator)
- Timed enemy waves synced to a day/night cycle
- A freeze effect that swaps an enemy's material and slows its movement speed
- Win/lose state handling and a refill-based UI for placing defenders

## Tech Stack
- **Engine:** Unity
- **Language:** C#

## How It Works
Defenders are placed on a grid-based lawn. Enemies spawn in timed waves and move toward the player's base; each defender type applies a different effect (damage, slow, or blocking) to stop them. A day/night cycle changes which enemies appear.

## Status
Personal Unity project built to practice game economy design, wave-based spawning, and status-effect systems — built with a teammate under a tight deadline.
