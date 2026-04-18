# Config Schema v0.1

## 1. mode_profile
Required
- profile_name: string
- max_duration_sec: integer
- capture_enabled: boolean

Optional
- max_decisions: integer|null
- notes: string

## 2. battle_config
Required
- movement.max_speed: number
- movement.acceleration: number
- movement.deceleration: number
- movement.stop_epsilon: number

- aim.turn_rate_deg_per_sec: number
- aim.keep_target_rule: string
- aim.lose_target_rule: string

- weapon.windup_sec: number
- weapon.recovery_sec: number
- weapon.projectile_speed: number
- weapon.projectile_lifetime: number

Recommended
- weapon.spread_deg: number
- combat.friendly_fire_enabled: boolean
- combat.team_size: integer
- map.allow_limited_random_layout: boolean
- map.seed_strategy: string
- logging.save_battle_results: boolean
- logging.save_summary: boolean
- logging.save_diagnostic_mechanics: boolean

## 3. reward_config
Required
- reward_stage: string   # R0, R1, R2, R3
- preset_name: string
- outcome.win: number
- outcome.loss: number
- outcome.draw: number

- terms.damage: number
- terms.kill: number
- terms.survival: number
- terms.self_damage: number
- terms.friendly_fire: number
- terms.line_of_fire: number

Recommended
- metrics.save_time_to_first_shot: boolean
- metrics.save_mean_shot_interval: boolean
- metrics.save_path_length: boolean

## 4. Notes
- mode_profile is separate from battle_config and reward_config.
- notes fields are documentation fields, not behavior fields.
- Any field that changes behavior must eventually participate in config hashing.
