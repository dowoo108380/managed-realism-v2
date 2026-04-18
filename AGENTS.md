# AGENTS.md

## Default environment
- Primary OS: Windows
- Preferred shell: PowerShell 7
- Unity project root is repository root

## Project rules
- Keep train/eval/demo profiles separated.
- Do not change mode durations without updating docs and configs together.
- Do not implement free aim, slow projectile lead aiming, reload, or multi-weapon features in the current semester scope.
- Prefer small, reviewable changes.
- Leave reproducible artifacts and logs for every meaningful step.

## Expected repo structure
- artifacts/, configs/, runs/, models/, batches/, reports/, docs/

## Near-term goal
- Finish BL-001, BL-002, BL-003 before RL training work.